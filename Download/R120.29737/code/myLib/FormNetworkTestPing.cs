using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUtilities;
using TcpIpInterface;

namespace LogTerminal
{
    public partial class FormNetworkTestPing : Form
    {
        #region Public Enumerations
        public enum DgvTestColumns { Enable, Delay, IPAddress, DeviceName, Timeout, Fail, Pass, Reset };
        #endregion

        #region Delegates
        private readonly MyDelegates.TraceTCPMsgDelegate _traceAppMsg;
        #endregion

        #region Local Variables
        public static string TraceClass;
        readonly Color _defaultColor = Color.Empty;
        readonly Color _activeColor = Color.LightSeaGreen;
        #endregion

        #region Classes
        // Create an instance of classes
        readonly NetworkUtil _networkUtil = new NetworkUtil();
        readonly MyVar _myVar = new MyVar();
        readonly MyDgv _myDgv = new MyDgv();
        public MySharedData _sharedData;
#pragma warning disable
        private static FrmTerminal s_parentForm;
#pragma warning restore
        #endregion // Classes

        #region Constructor
        public FormNetworkTestPing(FrmTerminal parent,
                                    MySharedData mySharedData,
                                    MyDelegates.TraceTCPMsgDelegate traceAppMsg)
        {
            TraceClass = GetType().Name; // Assign the class name to the static variable
            s_parentForm = parent;
            _sharedData = mySharedData;
            _traceAppMsg = traceAppMsg;

            InitializeComponent();
            InitializeTestDataGridView();
            InitializeReleaseUI();
        }
        #endregion

        #region Local Properties
        public bool FormEnable
        {
            set
            {
                cbLoopEn.Enabled = value;
                cbTestEnable.Checked = false;
                cbTestEnable.Enabled = value;
            }
        }
        public CheckBox ChallengeEnableCheckbox // Expose to parent form
        {
            get { return cbTestEnable; }
            set { cbTestEnable = value; }
        }
        #endregion

        #region Local Methods

        /// <summary>
        /// Hide all Debug UI</summary>
        private void InitializeReleaseUI()
        {
#if !DEBUG
            BtnDeveloperTest.Visible = false;
#endif
        }

        private void InitializeTestDataGridView()
        {
            // Initialize Events
            dgvTest.RowsAdded += DgvTest_RowsAdded;
            dgvTest.CellContentClick += DgvTest_CellContentClick; // fix for checkbox changes
            dgvTest.CellMouseUp += DgvTest_OnCellMouseUp; // fix for fast checkbox changeclick by Changhong

            foreach (DataGridViewRow row in dgvTest.Rows) // stint to address defaule value = null
            {
                row.Cells[(int)DgvTestColumns.Enable].Value = true;
                row.Cells[(int)DgvTestColumns.Delay].Value = 0;
                row.Cells[(int)DgvTestColumns.IPAddress].Value = "";
                row.Cells[(int)DgvTestColumns.DeviceName].Value = "";
                row.Cells[(int)DgvTestColumns.Timeout].Value = 0;
                row.Cells[(int)DgvTestColumns.Fail].Value = 0;
                row.Cells[(int)DgvTestColumns.Pass].Value = 0;
                row.Cells[(int)DgvTestColumns.Reset].Value = "Reset";
            }
        }
        /// <summary> When enabled proceed to start sending list of messages with delays and check for response</summary>
        private async Task ProcessTestAsync()
        {
            const int TestDefaultScore = 0;
            const int TestDelay = 250;
            const int TestTimeout = 1000;
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif

            if (cbTestEnable.Checked && gbPingTest.Enabled && dgvTest.Rows.Count > 1)
            {
                _traceAppMsg(LogMsgType.MsgFromApp, $"", $"", $"Start Task Device Ping Test");
                // _serialTestActive(); // Notify Parent of Active Test
                while (cbTestEnable.Checked && gbPingTest.Enabled)
                {
                    var dataErrorCounter = 0;
                    var continueLoop = true;

                    foreach (DataGridViewRow row in dgvTest.Rows)
                    {
                        // Access data in each cell
                        var challenge = row.Cells[(int)DgvTestColumns.IPAddress].Value?.ToString();
                        var enableCellValue = (bool)(row.Cells[(int)DgvTestColumns.Enable].Value);

                        if (!string.IsNullOrEmpty(challenge) && 
                            _myVar.TryParseIpAddress(challenge, out var ipAddress) &&
                            enableCellValue)
                        {
                            // Verify and replace invalid data
                            row.Cells[(int)DgvTestColumns.Delay].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Delay], TestDelay);
                            var delay = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Delay], TestDelay);

                            row.Cells[(int)DgvTestColumns.Timeout].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Timeout], TestTimeout);
                            var timeout = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Timeout], TestTimeout);

                            row.Cells[(int)DgvTestColumns.Delay].Style.BackColor = _activeColor;
                            await Task.Delay(delay);
                            row.Cells[(int)DgvTestColumns.Delay].Style.BackColor = _defaultColor;

                            if (!cbTestEnable.Checked)
                            {
                                _traceAppMsg(LogMsgType.MsgFromApp, "", "", "User Cancelled Task");
                                continueLoop = false;
                                break;
                            }

                            // Start of Ping Test
                            row.Cells[(int)DgvTestColumns.Timeout].Style.BackColor = _activeColor;

                            try
                            {
                                if (await _networkUtil.PingSingleTimeoutAsync(ipAddress, timeout))
                                {
                                    row.Cells[(int)DgvTestColumns.Pass].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Pass], TestDefaultScore) + 1;
                                }
                                else
                                {
                                    row.Cells[(int)DgvTestColumns.Fail].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Fail], TestDefaultScore) + 1;
                                    _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"Test Failed: row = {row.Index}, ipaddress = {ipAddress}\n");
                                }
                            }
                            catch (Exception ex)
                            {
                                row.Cells[(int)DgvTestColumns.Fail].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvTestColumns.Fail], TestDefaultScore) + 1;
                                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"Exception during ping: row = {row.Index}, ipaddress = {ipAddress}, error = {ex.Message}\n");
                            }

                            row.Cells[(int)DgvTestColumns.Timeout].Style.BackColor = _defaultColor;

                            if (!cbTestEnable.Checked)
                            {
                                _traceAppMsg(LogMsgType.MsgFromApp, "", "", "User Cancelled Task");
                                continueLoop = false;
                                break;
                            }
                        }
                        else
                        {
                            dataErrorCounter++;
                        }
                    }

                    if (!cbLoopEn.Checked)
                    {
                        continueLoop = false;
                    }

                    if (dataErrorCounter >= dgvTest.RowCount)
                    {
                        _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"Ping Test Configuration Error Counter = '{dataErrorCounter}'");
                        continueLoop = false;
                    }

                    if (!continueLoop)
                    {
                        _traceAppMsg(LogMsgType.MsgFromApp, "", "", "Ending Task Ping Test");
                        cbTestEnable.Checked = false;
                        break;
                    }
                }
            }
            else
            {
                _traceAppMsg(LogMsgType.MsgFromApp, $"", $"", $"Ending Ping Test. No tests present");
                cbTestEnable.Checked = false; // Unchecked the Enable box
            }
        }

        private async Task FillDeviceNameWithHost()
        {
            var tasks = new List<Task>();

            foreach (DataGridViewRow row in dgvTest.Rows)
            {
                // Access data in each cell and if we have a valid IP and device name field is empty
                var challenge = row.Cells[(int)DgvTestColumns.IPAddress].Value?.ToString();
                if (!string.IsNullOrEmpty(challenge) &&
                    (row.Cells[(int)DgvTestColumns.DeviceName].Value?.ToString() == "" || row.Cells[(int)DgvTestColumns.DeviceName].Value == null) &&
                    _myVar.TryParseIpAddress(challenge, out var ipAddress))
                {
                    row.Cells[(int)DgvTestColumns.DeviceName].Style.BackColor = _activeColor;

                    // Create a task for scanning the device
                    tasks.Add(Task.Run(async () =>
                    {
                        await _networkUtil.ScanSingleAsync(ipAddress, 1000, false);
                        if (_networkUtil.listActiveNetworkDevices.TryGetValue(ipAddress, out var hostname))
                        {
                            // Update UI on the main thread
                            Invoke(new Action(() =>
                            {
                                row.Cells[(int)DgvTestColumns.DeviceName].Value = hostname;
                                row.Cells[(int)DgvTestColumns.DeviceName].Style.BackColor = _defaultColor;
                            }));
                        }
                        else
                        {
                            // Update UI on the main thread if no device found
                            Invoke(new Action(() =>
                            {
                                row.Cells[(int)DgvTestColumns.DeviceName].Style.BackColor = _defaultColor;
                            }));
                        }
                    }));
                }
            }
            await Task.WhenAll(tasks);
            _networkUtil.ClearActiveNetworkDevices();
        }
        #endregion

        #region Event Handlers > Form Change
        private void FormNetworkTestPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbTestEnable.Checked = false; // We will stop tests.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the form closing
                Hide(); // Hide the form instead
            }
        }

        private void DgvTest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Address issue with default checkbox value being "NULL" dispite a null value being set as true.
            for (var i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.Enable].Value = true;
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.Delay].Value = 0;
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.IPAddress].Value = "";
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.DeviceName].Value = "";
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.Timeout].Value = 0;
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.Fail].Value = 0;
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.Pass].Value = 0;
                dgvTest.Rows[i].Cells[(int)DgvTestColumns.Reset].Value = "Reset";
            }
        }

        private void DgvTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTest.CommitEdit(DataGridViewDataErrorContexts.Commit);

            // Check if the clicked cell is in the button column and is not a header
            if (e.ColumnIndex == (int)DgvTestColumns.Reset && e.RowIndex >= 0)
            {
                dgvTest.Rows[e.RowIndex].Cells[(int)DgvTestColumns.Fail].Value = 0;
                dgvTest.Rows[e.RowIndex].Cells[(int)DgvTestColumns.Pass].Value = 0;
            }
        }

        private void DgvTest_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == (int)DgvTestColumns.Enable && e.RowIndex != -1)
            {
                dgvTest.EndEdit();
            }
        }

        private void CbTestEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTestEnable.Checked)
            {
               // _serialTestActive();
                _ = ProcessTestAsync();
            }
        }

        #endregion // Event Handlers > Form Change

        #region Events Handlers > Tool Strip Button Click

        private void TsBtnOpenFile_Click(object sender, EventArgs e)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            dgvTest.RowsAdded -= DgvTest_RowsAdded;

            // Call the method to open the file and add rows
            _myDgv.OpenTxtFileToDgvDialog(dgvTest);

            // This is a stint to handle issue where after opening file, it appear cannot capture the Bool Value of first column
            // The work around is to capture the cast string value and then re-assign the bool value.
            // Added Try for event where user press Cancel instead of open.
            foreach (DataGridViewRow row in dgvTest.Rows)
            {
                try
                {
                    if ((string)row.Cells[(int)DgvTestColumns.Enable].Value == "True")
                    {
                        row.Cells[(int)DgvTestColumns.Enable].Value = true;
                    }
                    else
                    {
                        row.Cells[(int)DgvTestColumns.Enable].Value = false;
                    }
                }
                catch (Exception)
                {
                    Trace.WriteLine($"Error Exception {e}");// Handle the case where tvRemoteForm is disposed (closed)
                }
                row.Cells[(int)DgvTestColumns.Reset].Value = "Reset";

            }
            // Reattach the event handler
            dgvTest.RowsAdded += DgvTest_RowsAdded;

            // This stint assigns default values for the "automatic new row" the dgv creates after the file is open.
            // This will resolve issue if Save is used again.
            if (dgvTest.Rows.Count > 0)
            {
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.Enable].Value = true;
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.Delay].Value = 0;
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.IPAddress].Value = "";
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.DeviceName].Value = "";
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.Timeout].Value = 0;
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.Fail].Value = 0;
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.Pass].Value = 0;
                dgvTest.Rows[dgvTest.Rows.Count - 1].Cells[(int)DgvTestColumns.Reset].Value = "Reset";
            }
        }

        private void TsBtnSaveFile_Click(object sender, EventArgs e)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    _myDgv.SaveDgvToTxtFile(dgvTest, filePath);
                }
            }
        }

        private void TsBtnEnableAll_Click(object sender, EventArgs e)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            foreach (DataGridViewRow row in dgvTest.Rows) // Access data in each cell
            {
                row.Cells[(int)DgvTestColumns.Enable].Value = true; //
            }
        }

        private void TsBtnDisableAll_Click(object sender, EventArgs e)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            foreach (DataGridViewRow row in dgvTest.Rows) // Access data in each cell
            {
                row.Cells[(int)DgvTestColumns.Enable].Value = false; //
            }
        }

        private void TsBtnResetAllResults_Click(object sender, EventArgs e)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            foreach (DataGridViewRow row in dgvTest.Rows) // Access data in each cell
            {
                // enable
                row.Cells[(int)DgvTestColumns.Fail].Value = 0; //
                row.Cells[(int)DgvTestColumns.Pass].Value = 0; //

            }
        }

        private void TsBtnClearAllTests_Click(object sender, EventArgs e)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            dgvTest.Rows.Clear();
        }

        private async void TsBtnAutoFillNames_Click(object sender, EventArgs e)
        {
            await FillDeviceNameWithHost();
        }
        #endregion

        #region Events Handlers > Form Button Click
        private void BtnDeveloperTest_Click(object sender, EventArgs e)
        {

            if (_myVar.TryParseIpAddress3Octet(_sharedData.SourceIP, out var baseIpAddress))
            {
                var startRange = 1;
                var endRange = 254;

                for (var i = startRange; i <= endRange; i++)
                {
                    var newRowIdx = dgvTest.Rows.Add(); // Add a new row and get its index
                    var ipAddress = $"{baseIpAddress}.{i}";
                    var newRow = dgvTest.Rows[newRowIdx];

                    newRow.Cells[(int)DgvTestColumns.Enable].Value = true;
                    newRow.Cells[(int)DgvTestColumns.Delay].Value = 0;
                    newRow.Cells[(int)DgvTestColumns.IPAddress].Value = ipAddress;
                    newRow.Cells[(int)DgvTestColumns.DeviceName].Value = "";
                    newRow.Cells[(int)DgvTestColumns.Timeout].Value = 0;
                    newRow.Cells[(int)DgvTestColumns.Fail].Value = 0;
                    newRow.Cells[(int)DgvTestColumns.Pass].Value = 0;
                    newRow.Cells[(int)DgvTestColumns.Reset].Value = "Reset";
                }
            }
            else
            {
                _traceAppMsg(LogMsgType.MsgFromApp, $"", $"", $"Unable to Generate Test Address from base address = {_sharedData.SourceIP}");
            }

        }

        #endregion




    }
}

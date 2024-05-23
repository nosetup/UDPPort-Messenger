using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using MyUtilities;


namespace LogTerminal
{
    public partial class FormUDPAutomate : Form
    {
        public enum DgvScriptingColumns { Delay, Tx };
        public enum DgvAutoReplyColumns { Rx, Delay, Tx };

        #region Delegates
        private readonly MyDelegates.TraceTCPMsgDelegate _traceAppMsg;
        private readonly MyDelegates.GetConnectStateDelegate _getConnectState;
        private readonly MyDelegates.AutomateActiveDelegate _automateActiveDelegate;
        private readonly MyDelegates.TxDataDelegate _txData;
        #endregion

        #region Local Variables
        public static string TraceClass;
        #endregion

        #region Classes
        // Create an instance of classes
        #pragma warning disable
        private static FrmTerminal s_parentForm;
        #pragma warning restore
        public MySharedData _sharedData;
        readonly MyDgv _myDgv = new MyDgv();
        #endregion // Classes

        #region Constructor
        public FormUDPAutomate(FrmTerminal parent,
                                MySharedData mySharedData,
                                MyDelegates.GetConnectStateDelegate getConnectState,
                                MyDelegates.AutomateActiveDelegate automateActiveDelegate,
                                MyDelegates.TraceTCPMsgDelegate traceAppMsg,
                                MyDelegates.TxDataDelegate txData)
        {
            TraceClass = GetType().Name; // Assign the class name to the static variable
            s_parentForm = parent;
            _automateActiveDelegate = automateActiveDelegate;
            _getConnectState = getConnectState;
            _traceAppMsg = traceAppMsg;
            _txData = txData;
            _sharedData = mySharedData;

            InitializeComponent();

            // Initialize DataGridView
            InitializeScriptDataGridView();
            InitializeAutoReplyDataGridView();

        }
        #endregion // Constructor

        #region Local Properties

        public bool FormEnable
        {
            set
            {
                cbScriptLoop.Enabled = value;
                cbScriptEnable.Checked = false;
                cbScriptEnable.Enabled = value;
                cbAutoReplyEnable.Checked = false;
                cbAutoReplyEnable.Enabled = value;
            }
        }
        public CheckBox ScriptEnableCheckbox
        {
            get { return cbScriptEnable; }
            set { cbScriptEnable = value; }
        }
        public CheckBox AutoReplyEnableCheckbox
        {
            get { return cbAutoReplyEnable; }
            set { cbAutoReplyEnable = value; }
        }
        #endregion

        #region Local Methods

        private void InitializeScriptDataGridView()
        {
            // Set up columns
            dgvScripting.ColumnCount = 2;

            // Set column names
            dgvScripting.Columns[0].Name = "Delay (msec)";
            dgvScripting.Columns[1].Name = "Tx Data";

            // Set column widths
            dgvScripting.Columns[0].Width = 50; // Set the width of the first column
            dgvScripting.Columns[0].Frozen = true; // Make the second column a fixed size
            dgvScripting.Columns[0].Resizable = DataGridViewTriState.False;
            dgvScripting.Columns[1].Resizable = DataGridViewTriState.False;
            dgvScripting.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Allow the third column to fill the remaining space

            // Add a new row and set values in each column
            dgvScripting.Rows.Add("1000", "KNOCK KNOCK?");
        }
        private void InitializeAutoReplyDataGridView()
        {
            // Set up columns
            dgvAutoReply.ColumnCount = 3;

            // Set column names
            dgvAutoReply.Columns[0].Name = "Rx Data";
            dgvAutoReply.Columns[1].Name = "Delay (msec)";
            dgvAutoReply.Columns[2].Name = "Tx Data";

            // Set column widths
            dgvAutoReply.Columns[0].Width = 200; // Set the width of the second column
            dgvAutoReply.Columns[0].Resizable = DataGridViewTriState.False;
            dgvAutoReply.Columns[1].Width = 50; // Set the width of the first column
            dgvAutoReply.Columns[1].Frozen = true; // Make the second column a fixed size
            dgvAutoReply.Columns[1].Resizable = DataGridViewTriState.False;
            dgvAutoReply.Columns[2].Resizable = DataGridViewTriState.False;
            dgvAutoReply.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Allow the third column to fill the remaining space

            // Add a new row and set values in each column
            dgvAutoReply.Rows.Add("KNOCK KNOCK?", "0", "WHO IS THERE?");
        }

        /// <summary>
        /// DataGridView when enabled proceed to start sending list of messages with delays.</summary>
        private async Task ProcessScriptingAsync()
        {
            const int ScriptingDelay = 100;
            var defaultColor = Color.Empty;
            var activeColor = Color.LightSeaGreen;

            if (!_getConnectState())
            {
                cbScriptEnable.Checked = false;
                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Unable to Start Task Scripting, Not connected to any device.");
            }

            if (cbScriptEnable.Checked && gbScripting.Enabled && dgvScripting.Rows.Count > 1)
            {
                _automateActiveDelegate();
                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Start Async Task Scripting");

                if (cbScriptLoop.Checked && gbScripting.Enabled && dgvScripting.Rows.Count > 1)
                {
                    var dataErrorCounter = 0;
                    while (cbScriptEnable.Checked)
                    {
                        var continueLoop = true;
                        foreach (DataGridViewRow row in dgvScripting.Rows)
                        {
                            // Access data in each cell
                            var data = row.Cells[1].Value?.ToString(); // data column

                            // Check if data is not null before using them
                            if (!string.IsNullOrEmpty(data))
                            {
                                // Verify data in cell, set invalid data to default
                                row.Cells[(int)DgvScriptingColumns.Delay].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvScriptingColumns.Delay], ScriptingDelay);
                                var delay = _myDgv.VerifyReplaceIntInCell(row.Cells[(int)DgvScriptingColumns.Delay], ScriptingDelay);

                                row.Cells[(int)DgvScriptingColumns.Delay].Style.BackColor = activeColor;
                                await Task.Delay(delay * 1); // Proceed to process the delay
                                row.Cells[(int)DgvScriptingColumns.Delay].Style.BackColor = defaultColor;


                                if (cbScriptEnable.Checked)
                                {
                                    _txData(data);
                                }
                                else
                                {
                                    _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Aborting Async Task Scripting");
                                    break;
                                }
                            }
                            else dataErrorCounter++;
                        }
                        if (!cbScriptLoop.Checked) continueLoop = false;

                        if (dataErrorCounter >= dgvScripting.RowCount)
                        {
                            _traceAppMsg(LogMsgType.MsgFromApp,"","", $"Scripting Error Counter ='{dataErrorCounter}'");
                            continueLoop = false;
                        }
                        else dataErrorCounter = 0;

                        if (!continueLoop)
                        {
                            _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: End Async Task Scripting");
                            cbScriptEnable.Checked = false;
                        }
                    }
                }



            }
        }
        /// <summary>
        /// DataGridView determine if string exists to send response with delays as needed. </summary>
        public async Task ProcessAutoReplyAsync(string rxBuffer)
        {
#if DEBUG
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name}");
#endif
            const int AutoReplyDelay = 100;
            _automateActiveDelegate();
            if (!_getConnectState())
            {
                cbAutoReplyEnable.Checked = false;
                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Unable to Start Auto Reply, Not connected to any device.");
            }

            if (cbAutoReplyEnable.Checked)
            {
                foreach (DataGridViewRow row in dgvAutoReply.Rows)
                {
                    // Access data in each cell
                    var rxdata = row.Cells[0].Value?.ToString(); // Rx data column
                    var txdata = row.Cells[2].Value?.ToString(); // Tx data column

                    // Confirm Rx/Tx fields are not empty is not null before using them
                    if (!string.IsNullOrEmpty(rxdata) && !string.IsNullOrEmpty(txdata))
                    {
                        // Compare data
                        if (rxdata == rxBuffer)
                        {
                            row.Cells[1].Value = _myDgv.VerifyReplaceIntInCell(row.Cells[1], AutoReplyDelay);
                            var delay = _myDgv.VerifyReplaceIntInCell(row.Cells[1], AutoReplyDelay);
                            await Task.Delay(delay * 1);

                            if (cbAutoReplyEnable.Checked)
                            {
                                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Sending Auto Reply");
                                _txData(txdata);
                            }
                        }
                    }
                }
            }
        }

#endregion

        #region Event Handlers

        #region Event Handlers > Form Change
        private void FormUDPAutomate_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbScriptEnable.Checked = false;
            cbAutoReplyEnable.Checked = false;
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the form closing
                Hide(); // Hide the form instead
            }
        }

        private void CbScriptEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbScriptEnable.Checked)
            {
                _ = ProcessScriptingAsync();
            }
        }

        private void CbAutoReplyEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoReplyEnable.Checked)
            {
                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Auto Reply Scripting Enabled");
            }
            else
            {
                _traceAppMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Auto Reply Scripting Disabled");
            }
        }

        #endregion // Event Handlers > Form Change

        #region Event Handlers > Tool Strip Menu Item
        private void TsBtnScriptOpen_Click(object sender, EventArgs e)
        {
            _myDgv.OpenTxtFileToDgvDialog(dgvScripting);
        }

        private void TsBtnScriptSaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    _myDgv.SaveDgvToTxtFile(dgvScripting, filePath);
                }
            }
        }

        private void TsBtnAutoReplyOpen_Click(object sender, EventArgs e)
        {
            _myDgv.OpenTxtFileToDgvDialog(dgvAutoReply);
        }

        private void TsBtnAutoReplySaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    _myDgv.SaveDgvToTxtFile(dgvAutoReply, filePath);
                }
            }
        }
        #endregion // Event Handlers > Tool Strip Menu Item

        #endregion // Event Handlers
    }
}

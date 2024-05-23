using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MyUtilities;


namespace LogTerminal
{
    public partial class FormUDPLogWindow : Form
    {
        #region Delegates
        private readonly MyDelegates.GetConnectStateDelegate _getConnectState;
        private readonly MyDelegates.TxUDPDataDelegate _txUDPData;
        #endregion // Delegates

        #region Local Variables
        public static string TraceClass;
        private int _dgvLoglineCounter = 1;
        private readonly Color[] _logMsgTypeColor = {
            Color.DarkSlateGray,
            Color.Black,
            Color.Blue,
            Color.Black,
            Color.Orange,
            Color.Red }; // Various colors for logging info
        private readonly List<string> _messageHistory = new List<string>(); // Save Textbox history to list
        private readonly int _maxHistorySize = 10; // Set the maximum number of records in history
        private int _historyIndex = -1;         // Handles Textbox history
        #endregion // Local Variables

        #region Classes
        #pragma warning disable
        private static FrmTerminal s_parentForm;
        #pragma warning restore
        public MySharedData _sharedData;
        readonly MyVar _myVar = new MyVar();
        readonly MyDgv _myDgv = new MyDgv();
        readonly MyUi _myUi = new MyUi();
        #endregion // Classes

        #region Constructor

        public FormUDPLogWindow(FrmTerminal parent, 
                                MySharedData sharedData,
                                MyDelegates.GetConnectStateDelegate getConnectState,
                                MyDelegates.TxUDPDataDelegate txUDPData)
        {
            TraceClass = GetType().Name; // Assign the class name to the static variable
            s_parentForm = parent;
            _sharedData = sharedData;
            _getConnectState = getConnectState;
            _txUDPData = txUDPData;

            InitializeComponent();
            InitializeDataGridView();

            TbDestIP.KeyDown += TbDestIP_KeyDown;
            TbDestIP.Leave += TbDestIP_Leave;
            TbDestPort.KeyPress += TbDestPort_KeyPress;
            TbDestPort.KeyDown += TbDestPort_KeyDown;
            TbSearchData.GotFocus += TbSearchData_GotFocus;
            TbSearchData.KeyPress += TbSearchData_KeyPress;
            TbMessage.KeyDown += TbMessage_KeyDown;
            TbMessage.KeyPress += TbMessage_KeyPress;

            if (_sharedData.SourceIP != null || _sharedData.SourceIP != "")
            {
                TbDestIP.Text = _sharedData.SourceIP;
            }
        }
        #endregion // Constructor

        #region Local Properties

        public bool FormEnable
        {
            set 
            {
                BtnSendMessage.Enabled = value;
                TbMessage.Enabled = value;
                TbDestIP.Enabled = value;
                TbDestPort.Enabled = value;
            }
        }

        public string DestIP
        {
            get { return TbDestIP.Text; }
            set { TbDestIP.Text = value; }
        }
        
        public string DestPort
        {
            get { return TbDestPort.Text; }
            set { TbDestPort.Text = value;}
        }

        #endregion // Local Properties

        #region Local Methods

        private void InitializeDataGridView()
        {
            // Set up columns
            _dgvLoglineCounter = 1;
            dgvLogWindow.ColumnCount = 6;

            // Set column names
            dgvLogWindow.Columns[0].Name = "#";
            dgvLogWindow.Columns[1].Name = "HH:MM:SS";
            dgvLogWindow.Columns[2].Name = "<->";
            dgvLogWindow.Columns[3].Name = "Source IP";
            dgvLogWindow.Columns[4].Name = "Dest IP";
            dgvLogWindow.Columns[5].Name = "Message";

            // Set up Column Type
            dgvLogWindow.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvLogWindow.Columns[0].ValueType = typeof(int);
            dgvLogWindow.Columns[0].DefaultCellStyle.Format = "N0"; // Specify the numeric format if needed

            // Set column widths and make the second column fixed size
            dgvLogWindow.Columns[0].Width = 50; // Set the width of the first column
            dgvLogWindow.Columns[0].Frozen = true; // Make the second column a fixed size
            dgvLogWindow.Columns[0].Resizable = DataGridViewTriState.False;
            dgvLogWindow.Columns[1].Width = 75; // Set the width of the first column
            dgvLogWindow.Columns[1].Frozen = true; // Make the second column a fixed size
            dgvLogWindow.Columns[1].Resizable = DataGridViewTriState.False;
            dgvLogWindow.Columns[2].Width = 25; // Set the width of the second column
            dgvLogWindow.Columns[2].Frozen = true; // Make the second column a fixed size
            dgvLogWindow.Columns[2].Resizable = DataGridViewTriState.False;
            dgvLogWindow.Columns[3].Width = 120; // Set the width of the second column
            dgvLogWindow.Columns[3].Frozen = true; // Make the second column a fixed size
            dgvLogWindow.Columns[4].Width = 120; // Set the width of the second column
            dgvLogWindow.Columns[4].Frozen = true; // Make the second column a fixed size
            dgvLogWindow.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Allow the third column to fill the remaining space

            // Add a row with sample values
            LogMsg(LogMsgType.MsgFromApp, "", "", string.Format($"{_sharedData.SystemAppName}: Started at {DateTime.Now} "));
#if DEBUG
            LogMsg(LogMsgType.MsgFromApp, "", "", string.Format($"***** DEBUG BUILD *****"));
            Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name} : ***** DEBUG BUILD *****");
#endif
        }

        public void LogTx(LogMsgType msgtype, string src, string dest, string msg)
        {
            AddRowToDataGridView("Tx", src, dest, msg);
            _myDgv.SetFontColorForLastRow(dgvLogWindow, _logMsgTypeColor[(int)msgtype]);
        }

        /// <summary> Log Rx data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogRx(LogMsgType msgtype, string src, string dest, string msg)
        {
            if (!cbTermPauseRX.Checked)
            {
                AddRowToDataGridView("Rx", src, dest, msg);
                _myUi.InvokeIfRequired(dgvLogWindow, () => _myDgv.SetFontColorForLastRow(dgvLogWindow, _logMsgTypeColor[(int)msgtype]));
            }
        }

        /// <summary> Log system message to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogMsg(LogMsgType msgtype, string src, string dest, string msg)
        {
            AddRowToDataGridView("--", src, dest, msg);
            _myDgv.SetFontColorForLastRow(dgvLogWindow, _logMsgTypeColor[(int)msgtype]);
        }

        public void AddRowToDataGridView(string logMode, string logSrc, string logDest, string logMessage)
        {
            _myUi.InvokeIfRequired(dgvLogWindow, () =>
            {
                if (!dgvLogWindow.IsDisposed || dgvLogWindow != null && dgvLogWindow.ColumnCount != 0)
                {
                    dgvLogWindow.Rows.Add(
                        _dgvLoglineCounter.ToString(),
                        DateTime.Now.ToString("hh:mm:ss tt"),
                        logMode, logSrc, logDest, logMessage
                    );

                    _dgvLoglineCounter++;

                    if (cbTermAutoScroll.Checked)
                    {
                        _myDgv.ScrollToLastRecord(dgvLogWindow);
                    }
                }
            });
        }

        private void ValidateIPAddress()
        {
            if (!_myVar.TryParseIpAddress(TbDestIP.Text, out var _))
            {
                MessageBox.Show("Invalid IP address. Please enter a valid IP address.");
                TbDestIP.Text = _myVar.RemoveInvalidIPAddrChars(TbDestIP.Text);
                TbDestIP.SelectAll();
                TbDestIP.Focus();
            }
        }

        #endregion // Local Methods

        #region Event Handlers

        #region Event Handlers > Form Change

        private void FormUDPLogWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_myVar.TryParseIpAddress(TbDestIP.Text, out var _))
            {
                LogMsg(LogMsgType.MsgFromApp, "", "", string.Format($"Invalid IP Address : Setting to Default Address {_sharedData.SourceIP}"));
                TbDestIP.Text = _sharedData.SourceIP;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the form closing
                Hide(); // Hide the form instead
            }
        }

        private void TbDestIP_Leave(object sender, EventArgs e)
        {
            ValidateIPAddress();
        }
        
        private void TbDestIP_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow copy (Ctrl+C), paste (Ctrl+V), cut (Ctrl+X)
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                return;
            }

            // Allow Home, End, Left Arrow, and Right Arrow keys
            if (e.KeyCode == Keys.Home || e.KeyCode == Keys.End || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                return;
            }

            // Allow Enter key to trigger validation and move focus
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key press
                this.SelectNextControl((Control)sender, true, true, true, true);
                return;
            }
            // Allow only digit keys from the main keyboard and numeric keypad, period, backspace, and delete key
            if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                  e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal ||
                  e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TbDestPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and the delete key
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }

        private void TbDestPort_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow copy (Ctrl+C), paste (Ctrl+V), cut (Ctrl+X)
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                return;
            }
            // Allow only digit keys, backspace, and delete key
            if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                  e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Down)
                {
                    // Handle up arrow key press
                    e.Handled = true;

                    // If history is not empty, display the previous message from history
                    if (_messageHistory.Count > 0)
                    {
                        // Display the previous non-empty message from history
                        _historyIndex = (_historyIndex - 1 + _messageHistory.Count) % _messageHistory.Count;
                        TbMessage.Text = _messageHistory[_historyIndex];
                        TbMessage.SelectAll();
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    // Handle down arrow key press
                    e.Handled = true;

                    // If history is not empty, display the next message from history
                    if (_messageHistory.Count > 0)
                    {
                        // Display the next non-empty message from history
                        _historyIndex = (_historyIndex + 1) % _messageHistory.Count;
                        TbMessage.Text = _messageHistory[_historyIndex];
                        TbMessage.SelectAll();
                    }
                }
            }
        }

        private void TbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BtnSendMessage_Click(sender, e);
            }
        }

        private void TbSearchData_GotFocus(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => (sender as System.Windows.Forms.TextBox).SelectAll()));
        }

        private void TbSearchData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Handle Enter key press
                e.Handled = true;

                // Trigger the button click event (send the message)
                BtnDataSearch_Click(sender, e);
            }
        }

        #endregion // Event Handlers > Form Change

        #region Event Handlers > Tool Strip Button Click


        private void TsBtnOpen_Click(object sender, EventArgs e)
        {
            _myDgv.OpenTxtFileToDgvDialog(dgvLogWindow);
        }

        private void TsBtnSaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    _myDgv.SaveDgvToTxtFile(dgvLogWindow, filePath);
                }
            }
        }

        #endregion

        #region Events Handlers > Form Button Click

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            // verify the destination port address before sending messages
            var destPortAddr = _myVar.StringtoInt(TbDestPort.Text);
            if (_myVar.TryParseIpAddress(TbDestIP.Text, out _))
            {
                if (_getConnectState())
                {
                    _txUDPData(TbDestIP.Text, destPortAddr, TbMessage.Text);
                    LogTx(LogMsgType.Outgoing,
                        _sharedData.SourceIP + ":" + _sharedData.SourcePort,
                        TbDestIP.Text + ":" + destPortAddr,
                        TbMessage.Text);
                }
                else
                {
                    LogMsg(LogMsgType.MsgFromApp, "", "", string.Format($"{_sharedData.SystemAppName}: Device is not connected"));
                    Trace.WriteLine($"{TraceClass} : {MethodBase.GetCurrentMethod().Name} : Device is not connected");
                }

            }
            else
            {
                LogTx(LogMsgType.Error, "", "", $"{_sharedData.SystemAppName}: Invalid Dest IP Address : {TbDestIP.Text}");
            }

            // Save the current non-blank message to history
            var currentMessage = TbMessage.Text.Trim();

            if (!string.IsNullOrWhiteSpace(currentMessage))
            {
                // Check if the message is already in history and remove it
                _messageHistory.Remove(currentMessage);

                // Save the current message to history
                _messageHistory.Insert(0, currentMessage);
#if DEBUG
                    Trace.WriteLine($"Sent Message History counter='{_messageHistory.Count}',message='{currentMessage}'");
#endif
                // Limit the number of records in history
                if (_messageHistory.Count > _maxHistorySize)
                {
                    _messageHistory.RemoveAt(_messageHistory.Count - 1);
                }
            }

            // Clear the text box or take other actions as needed
            // TODO: Improvement: we may not want to clear textbox if fail to send.
            if (cbClearMsgAfterSend.Checked) TbMessage.Clear();

            // Reset history index for new messages
            _historyIndex = -1;
        }

        private void BtnDelSelRow_Click(object sender, EventArgs e)
        {
            _myDgv.DeleteSelectedRows(dgvLogWindow);
        }

        private void BtnTermClearAll_Click(object sender, EventArgs e)
        {
            // Clear all rows and columns
            // TODO: Improvement: add pop up to give a warning
            dgvLogWindow.Rows.Clear();
        }

        private void BtnTermReset_Click(object sender, EventArgs e)
        {
            dgvLogWindow.Rows.Clear();
            LogMsg(LogMsgType.MsgFromApp, "", "", $"{_sharedData.SystemAppName}: Resetting Log...");
            InitializeDataGridView();
        }

        private void BtnDataSearch_Click(object sender, EventArgs e)
        {
            _myDgv.SearchAndShowResults(dgvLogWindow, 5, TbSearchData.Text);
        }

        private void BtnDataShowAll_Click(object sender, EventArgs e)
        {
            _myDgv.UnhideAllRows(dgvLogWindow);
        }

        #endregion // Events Handlers > Form Button Click

        #endregion
    }
}

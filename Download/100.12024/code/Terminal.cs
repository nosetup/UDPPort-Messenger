#region Credits
/* 
 * simple UDP messenging app.
 * by N Diep
*/
#endregion
#region Namespace Inclusions
using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using TextBox = System.Windows.Forms.TextBox;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

#endregion
namespace LogTerminal
{
    #region Public Enumerations
    public enum LogMsgType { Incoming, Outgoing, MsgFromApp, Normal, Warning, Error };
    #endregion
    public partial class FrmTerminal : Form
    {
        private AboutBox _aboutBoxForm; // Declare the form at the class level
        private readonly Color[] _logMsgTypeColor = {
            Color.DarkSlateGray, 
            Color.Black, 
            Color.Blue, 
            Color.Black, 
            Color.Orange, 
            Color.Red }; // Various colors for logging info

        #region Local Variables
        public const string SystemAppName = "UDPPortMessengerApp";
        static UdpClient s_udpClient;
        static IPEndPoint s_localEndPoint;
        private Thread _receiveThread;
        private bool _exitRequested = false;
        private int _dgvLoglineCounter = 1;
        private readonly List<string> _messageHistory = new List<string>(); // Save Textbox history to list
        private readonly int _maxHistorySize = 10; // Set the maximum number of records in history
        private int _historyIndex = -1;         // Handles Textbox history
        #endregion
        #region Constructor
        public FrmTerminal()
        {
            // Build the form
            InitializeComponent();

            // Initialize DataGridView
            InitializeDataGridView();
            InitializeScriptDataGridView();
            InitializeAutoReplyDataGridView();

            cmbAdapterName.SelectedIndexChanged += CmbAdapterName_SelectedIndexChanged;
            ListActiveNetworkInterfaces();

            // Enable/disable controls based on the current state
            EnableControls();

            TbAnalyzeHexData.GotFocus += TbAnalyzeHexData_GotFocus;
            TbAnalyzeHexData.KeyPress += TbAnalyzeHexData_KeyPress;
            TbSrcPort.KeyPress += TbSrcPort_KeyPress;
            TbDestPort.KeyPress += TbDestPort_KeyPress;

            TbMessage.KeyDown += TbMessage_KeyDown;
            TbMessage.KeyPress += TbMessage_KeyPress;
        }
        #endregion
        #region Local Properties
        #endregion
        #region Local Methods

        /// <summary> Save the user's settings. </summary>
        public void SaveSettings()
        {
        }
        /// <summary> Enable/disable controls based on the app's current state. </summary>
        public void EnableControls()
        {
            BtnUDPConnect.Enabled = !IsUdpConnected();
            cmbAdapterName.Enabled = !IsUdpConnected();
            BtnUDPDisconnect.Enabled = IsUdpConnected();
            gbSendMessage.Enabled = IsUdpConnected();
            gbNetworkUtil.Enabled = IsUdpConnected();
            gbScripting.Enabled = IsUdpConnected();
            gbAutoReply.Enabled = IsUdpConnected();
        }
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
            LogMsg(LogMsgType.MsgFromApp, "", "", string.Format($"{SystemAppName}: Started at {DateTime.Now} "));
        }
        private void InitializeScriptDataGridView()
        {
            // Set up columns
            dgvScripting.ColumnCount = 2;

            // Set column names
            dgvScripting.Columns[0].Name = "Delay (sec)";
            dgvScripting.Columns[1].Name = "Tx Data";

            // Set column widths
            dgvScripting.Columns[0].Width = 50; // Set the width of the first column
            dgvScripting.Columns[0].Frozen = true; // Make the second column a fixed size
            dgvScripting.Columns[0].Resizable = DataGridViewTriState.False;
            dgvScripting.Columns[1].Resizable = DataGridViewTriState.False;
            dgvScripting.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Allow the third column to fill the remaining space

            // Add a new row and set values in each column
            dgvScripting.Rows.Add("00", "HELLO?");
        }
        private void InitializeAutoReplyDataGridView()
        {
            // Set up columns
            dgvAutoReply.ColumnCount = 3;

            // Set column names
            dgvAutoReply.Columns[0].Name = "Rx Data";
            dgvAutoReply.Columns[1].Name = "Delay (sec)";
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
            dgvAutoReply.Rows.Add("HELLO?", "0", "HELLO THIS IS UDP MESSENGER");
        }
        public void InvokeIfRequired(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action()));
            }
            else
            {
                action();
            }
        }
        /// <summary> Convert a string to int</summary>
        public int StringtoInt(string userInput)
        {
            // Using int.Parse
            try
            {
                var intValue = int.Parse(userInput);
                Console.WriteLine($"Parsed integer value: {intValue}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid integer format"); 
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: Invalid integer format");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The entered value is too large or too small for an integer");
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: The entered value is too large or too small for an integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: An unexpected error occurred: {ex.Message}");
            }

            // Using int.TryParse
            if (int.TryParse(userInput, out var parsedValue))
            {
                return parsedValue;
            }
            else
            {
                return 0;
            }


        }
        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public byte[] HexStringToByteArray(string s)
        {
            // Trim trailing spaces from the input string
            s = s.TrimEnd();
            // Remove spaces from the modified string
            s = s.Replace(" ", "");
            // If the input string is empty, return an empty byte array
            if (s.Length == 0)
            {
                return new byte[0];
            }
            var buffer = new byte[s.Length / 2];
            for (var i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public string ByteArrayToHexString(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 3);
            foreach (var b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));

            // Remove the trailing space using TrimEnd
            return sb.ToString().ToUpper().TrimEnd();
        }
        /// <summary> UDP Connect</summary>
        public void ConnectUdp()
        {
            try
            {
                // Set the local port for receiving messages
                var localPort = StringtoInt(TbSrcPort.Text);

                // Set the exit flag to true
                _exitRequested = false;

                // Set up the UDP client for sending and receiving
                s_udpClient = new UdpClient();

                // Create an endpoint for receiving messages on any available IP address
                s_localEndPoint = new IPEndPoint(IPAddress.Any, localPort);

                // Bind the UDP client to the local endpoint
                s_udpClient.Client.Bind(s_localEndPoint);

                // Start a new thread for receiving messages
                _receiveThread = new Thread(RxUdpMsg);
                _receiveThread.Start();

                EnableControls();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error, display a message)
                Console.WriteLine($"Error in Connect Udp: {ex.Message}");
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: Error in Connect Udp : {ex.Message}");
            }
        }
        /// <summary> UDP Connection status</summary>
        public bool IsUdpConnected()
        {
            // Check if the UDP client is initialized and the receiving thread is alive
            return s_udpClient != null && _receiveThread != null && _receiveThread.IsAlive;
        }
        /// <summary> UDP Disconnect</summary>
        public void DisconnectUdp()
        {
            // Set the exit flag to true
            _exitRequested = true;
            if (IsUdpConnected())
            {
                // Close the UDP client and the receiving thread
                s_udpClient.Close();
            }
            // If the receiving thread is still alive, wait for it to finish gracefully
            if (_receiveThread != null && _receiveThread.IsAlive)
            {
                _receiveThread.Join();
            }
            EnableControls();
        }
        /// <summary> UDP Recieve message</summary>
        public void RxUdpMsg()
        {
            while (!_exitRequested)
            {
                if (s_udpClient.Available > 0)
                {
                    // Receive a message and the endpoint it was sent from
                    var receivedBytes = s_udpClient.Receive(ref s_localEndPoint);

                    // Check if the message is not from the server itself
                    if (!s_localEndPoint.Address.Equals(IPAddress.Parse(TbSrcIP.Text)))
                    {
                        var receivedMessage = Encoding.ASCII.GetString(receivedBytes);

                        // Print the received message
                        LogRx(LogMsgType.Incoming, $"{s_localEndPoint}", "", $"{receivedMessage}");

                        if (cbAutoReplyEnable.Checked)
                        {
                            _ = ProcessAutoReplyAsync(receivedMessage);
                        }
                    }
                }
                else
                {
                    // Introduce a small delay if no data is available
                    Thread.Sleep(10); // Adjust the sleep duration as needed
                }
            }

        }
        /// <summary> UDP Send message</summary>
        static void TxUdpMsg(string ipaddress, int remotePort, string message)
        {
            // Convert the message to bytes and send it
            var messageBytes = Encoding.ASCII.GetBytes(message);

            // Specify the remote endpoint (replace with the actual values)
            var remoteIpAddress = IPAddress.Parse(ipaddress);
            var remoteEndPoint = new IPEndPoint(remoteIpAddress, remotePort);
            s_udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
        }
        /// <summary> Network show only active network interfaces</summary>
        public void ListActiveNetworkInterfaces()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            var ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            Console.WriteLine("List of available network interfaces:");

            cmbAdapterName.Items.Clear();

            foreach (var networkInterface in networkInterfaces)
            {
                // Filter based on type and status
                if ((networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                     networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    Console.WriteLine($"  Adapter Name: {networkInterface.Name}");
                    Console.WriteLine($"  Enabled: {networkInterface.OperationalStatus == OperationalStatus.Up}");
                    Console.WriteLine($"  Interface: {networkInterface.Description}");
                    Console.WriteLine($"    ID: {networkInterface.Id}");
                    Console.WriteLine($"    Type: {networkInterface.NetworkInterfaceType}");
                    Console.WriteLine($"    Status: {networkInterface.OperationalStatus}");
                    Console.WriteLine($"    Speed: {networkInterface.Speed} bps");

                    // Display IPv4 addresses
                    var ipv4Addresses = networkInterface.GetIPProperties().UnicastAddresses
                        .Where(addr => addr.Address.AddressFamily == AddressFamily.InterNetwork)
                        .Select(addr => addr.Address);

                    Console.WriteLine($"    IPv4 Addresses: {string.Join(", ", ipv4Addresses)}");

                    Console.WriteLine();

                    cmbAdapterName.Items.Add(networkInterface.Name + " / " + networkInterface.Description);
                }
            }

            //Selects First Index
            if (cmbAdapterName.Items.Count > 0) cmbAdapterName.SelectedIndex = 0;
            //Loads Default / Last Saved Port Name
            // else if (cmbAdapterName.Items.Contains(Settings.Default.PortName)) cmbAdapterName.Text = Settings.Default.PortName;
            else
            {
                MessageBox.Show(this, "There are no network adapters detected on this computer.\nPlease check device manager then restart this app.", "No Network Adapters Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }
        /// <summary> Network determine if a string ipaddress is valid</summary>
        private bool TryParseIpAddress(string input, out string baseIpAddress)
        {
            // Split the input into octets
            var octets = input.Split('.');

            // Ensure there are exactly four octets
            if (octets.Length == 4)
            {
                // Attempt to parse each octet
                if (int.TryParse(octets[0], out var octet1) &&
                    int.TryParse(octets[1], out var octet2) &&
                    int.TryParse(octets[2], out var octet3))
                {
                    // Check octet ranges
                    if (octet1 >= 0 && octet1 <= 255 &&
                        octet2 >= 0 && octet2 <= 255 &&
                        octet3 >= 0 && octet3 <= 255)
                    {
                        // Combine the first three octets
                        baseIpAddress = $"{octet1}.{octet2}.{octet3}";
                        return true;
                    }
                }
            }

            // Default if parsing fails
            baseIpAddress = null;
            return false;
        }
        private string GetIPv4AddressForSelectedAdapter()
        {
            if (cmbAdapterName.SelectedItem is string selectedAdapterInfo)
            {
                // Extract network interface name from the selected item
                var selectedAdapterName = selectedAdapterInfo.Split('/')[0].Trim();

                // Find the network interface by name
                var selectedAdapter = NetworkInterface.GetAllNetworkInterfaces()
                    .FirstOrDefault(adapter => adapter.Name == selectedAdapterName);

                // Retrieve the IPv4 address for the selected adapter
                if (selectedAdapter != null)
                {
                    var ipv4Address = selectedAdapter.GetIPProperties().UnicastAddresses
                        .FirstOrDefault(addr => addr.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;

                    return ipv4Address?.ToString() ?? "IPv4 address not found";
                }
            }
            return "No adapter selected";
        }
        /// <summary> Send the user's data currently entered in the 'send' box.</summary>
        public void SendStrData(string strdata)
        {
            // Set the local port for receiving messages
            var localPort = StringtoInt(TbDestPort.Text);
            if (TryParseIpAddress(TbDestIP.Text, out _))
            {
                TxUdpMsg(TbDestIP.Text, localPort, strdata);
                LogTx(LogMsgType.Outgoing,
                    TbSrcIP.Text + ":" + TbSrcPort.Text,
                    TbDestIP.Text + ":" + localPort,
                    strdata);
            }
            else
            {
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: Invalid Dest IP Address : {TbDestIP.Text}");
            }
        }
        /// <summary> DataGridView Save text file</summary>
        private void SaveDgvToTxtFile(DataGridView dataGridView, string filePath)
        {
            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    // Write data
                    for (var i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (var j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            var cellValue = dataGridView.Rows[i].Cells[j].Value;

                            // Check if the cell contains a long string
                            if (j == dataGridView.Columns.Count - 1 && cellValue != null && cellValue.ToString().Contains('\n'))
                            {
                                sw.Write($"{cellValue}");
                            }
                            else if (cellValue != null)
                            {
                                sw.Write($"{cellValue}\t"); // Use tab as delimiter
                            }
                        }
                        sw.WriteLine(); // Move to the next line after writing a row
                    }
                }

                MessageBox.Show("Data saved to file successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary> DataGridView Open text file</summary>
        private void OpenTxtFileToDgvDialog(DataGridView dataGridView)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog.FileName;

                    // logic to open and process the file content goes here


                    // Display the file content in the DataGridView
                    DisplayFileInDataGridView(dataGridView, filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary> DataGridView Display text file to window</summary>
        private void DisplayFileInDataGridView(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);

                dataGridView.Rows.Clear(); // Clear existing rows

                // Populate the DataGridView with the lines from the file
                foreach (var line in lines)
                {
                    // Split the line into columns based on a delimiter (e.g., tab or comma)
                    var columns = line.Split('\t'); // using '\t' tabs

                    // Add a new row to the DataGridView and set the cell values
                    dataGridView.Rows.Add(columns);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary> DataGridView Add data to a new row/record</summary>
        public void AddRowToDataGridView(string logMode, string logSrc, string logDest, string logMessage)
        {
            InvokeIfRequired(dgvLogWindow, () =>
            {
                dgvLogWindow.Rows.Add(
                    _dgvLoglineCounter.ToString(),
                    DateTime.Now.ToString("hh:mm:ss tt"),
                    logMode, logSrc, logDest, logMessage
                );

                _dgvLoglineCounter++;

                if (cbTermAutoScroll.Checked)
                {
                    ScrollToLastRecord();
                }
            });
        }
        /// <summary> DataGridView Delete selected row</summary>
        private void DeleteSelectedRows()
        {
            // Check if any cell is selected
            if (dgvLogWindow.SelectedCells.Count > 0)
            {
                // Create a HashSet to store unique row indices
                var uniqueRowIndices = new HashSet<int>();

                // Iterate through all selected cells and store unique row indices
                foreach (DataGridViewCell cell in dgvLogWindow.SelectedCells)
                {
                    uniqueRowIndices.Add(cell.RowIndex);
                }

                // Remove the entire rows at the specified indices
                foreach (var rowIndex in uniqueRowIndices.OrderByDescending(i => i))
                {
                    dgvLogWindow.Rows.RemoveAt(rowIndex);
                }
            }
        }
        /// <summary> DataGridView AutoScroll</summary>
        private void ScrollToLastRecord()
        {
            // Scroll to the last displayed row
            dgvLogWindow.FirstDisplayedScrollingRowIndex = dgvLogWindow.RowCount - 1;
        }
        /// <summary> DataGridView Used to set font color after adding a row/record</summary>
        private void SetFontColorForLastRow(Color color)
        {
            // Check if there's at least one row
            if (dgvLogWindow.Rows.Count > 0)
            {
                // Set the font color for the cells in the last row
                DataGridViewRow lastRow = dgvLogWindow.Rows[dgvLogWindow.Rows.Count - 1];
                foreach (DataGridViewCell cell in lastRow.Cells)
                {
                    cell.Style.ForeColor = color;
                }
            }
        }
        /// <summary> DataGridView Search a item on a column, hide all non revelant rows</summary>
        private void SearchAndShowResults(DataGridView dataGridView, int columnIndex, string searchTerm)
        {
            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Get the cell in the specified column
                var cell = row.Cells[columnIndex];

                // Check if the cell value contains the search term (case-insensitive)
                if (cell.Value != null && cell.Value.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // Set the row Visible property to true to show the result
                    row.Visible = true;
                }
                else
                {
                    // If the cell value doesn't contain the search term, hide the row
                    row.Visible = false;
                }
            }
        }
        /// <summary> DataGridView Set all rows to Visible</summary>
        private void UnhideAllRows(DataGridView dataGridView)
        {
            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Set the Visible property to true to unhide the row
                row.Visible = true;
            }
        }
        /// <summary> Log Tx data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogTx(LogMsgType msgtype, string src, string dest, string msg)
        {
            AddRowToDataGridView("Tx", src, dest, msg);
            SetFontColorForLastRow(_logMsgTypeColor[(int)msgtype]);
        }
        /// <summary> Log Rx data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogRx(LogMsgType msgtype, string src, string dest, string msg)
        {
            AddRowToDataGridView("Rx", src, dest, msg);
            SetFontColorForLastRow(_logMsgTypeColor[(int)msgtype]);
        }
        /// <summary> Log system message to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogMsg(LogMsgType msgtype, string src, string dest, string msg)
        {
            AddRowToDataGridView("--", src, dest, msg);
            SetFontColorForLastRow(_logMsgTypeColor[(int)msgtype]);
        }
        /// <summary> DataGridView determine if string exists to send response with delays as needed. </summary>
        private async Task ProcessAutoReplyAsync(string rxBuffer)
        {
            foreach (DataGridViewRow row in dgvAutoReply.Rows)
            {
                // Access data in each cell
                var rxdata = row.Cells[0].Value?.ToString(); // Rx data column
                var delay = row.Cells[1].Value?.ToString(); // delay column
                var txdata = row.Cells[2].Value?.ToString(); // Tx data column

                // Confirm Rx/Tx fields are not empty is not null before using them
                if (!string.IsNullOrEmpty(rxdata) && !string.IsNullOrEmpty(txdata))
                {
                    // Compare data
                    if (rxdata == rxBuffer)
                    {
                        if (string.IsNullOrEmpty(delay))
                        {
                            row.Cells[1].Value = "0"; // delay column
                            delay = row.Cells[1].Value?.ToString(); // delay column
                        }

                        if (!int.TryParse(delay, out _))
                        {
                            // Handle the case where strdata is not a valid integer, we put a zero
                            row.Cells[1].Value = "0"; // delay column
                            LogMsg(LogMsgType.Warning, "", "", $"{SystemAppName}: Invalid auto reply delay value. Setting delay to '0'.");
                            //update value in delay
                            delay = row.Cells[1].Value?.ToString(); // delay column
                                                                    //   return; // or throw an exception, log an error, etc.
                        }

                        if (int.TryParse(delay, out var intValue) && cbAutoReplyEnable.Checked)
                        {
                            await Task.Delay(intValue * 1000);
                            LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Sending Auto Reply");
                            SendStrData(txdata);
                        }
                    }
                    else
                    {
                    }
                }
            }
        }
        /// <summary> DataGridView when enabled proceed to start sending list of messages with delays.</summary>
        private async Task ProcessScriptingAsync()
        {
            if (cbScriptEnable.Checked && gbScripting.Enabled && dgvScripting.Rows.Count > 1)
            {
                // Prevent changes while script is running.
                // gbScripting.Enabled = false;
                LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Start Async Task Scripting");

                if (cbScriptLoop.Checked)
                {
                    while (cbScriptLoop.Checked && cbScriptEnable.Checked)
                    {
                        foreach (DataGridViewRow row in dgvScripting.Rows)
                        {
                            // Access data in each cell
                            var delay = row.Cells[0].Value?.ToString(); // delay column
                            var data = row.Cells[1].Value?.ToString(); // data column

                            // Check if data is not null before using them
                            if (!string.IsNullOrEmpty(data))
                            {
                                if (!int.TryParse(delay, out _))
                                {
                                    // Handle the case where strdata is not a valid integer, we put a one
                                    row.Cells[0].Value = "1"; // delay column
                                    LogMsg(LogMsgType.Warning, "", "", $"{SystemAppName}: Invalid loop delay value. Setting delay to '1'.");
                                    //update value in delay
                                    delay = row.Cells[0].Value?.ToString(); // delay column
                                                                            //   return; // or throw an exception, log an error, etc.
                                }

                                if (int.TryParse(delay, out var intValue))
                                {
                                    if (intValue == 0)
                                    {
                                        row.Cells[0].Value = "1"; // delay column
                                        intValue = 1;
                                        LogMsg(LogMsgType.Warning, "", "", $"{SystemAppName}: Minimum loop delay value = 1. Setting delay to '1'.");
                                    }
                                    await Task.Delay(intValue * 1000);
                                    SendStrData(data);
                                    if (!cbScriptEnable.Checked)
                                    {
                                        LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Aborting Async Task Scripting");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvScripting.Rows)
                    {
                        // Access data in each cell
                        var delay = row.Cells[0].Value?.ToString(); // delay column
                        var data = row.Cells[1].Value?.ToString(); // data column

                        // Check if data is not null before using them
                        if (!string.IsNullOrEmpty(data))
                        {
                            if (!int.TryParse(delay, out _))
                            {
                                // Handle the case where strdata is not a valid integer, we put a zero
                                row.Cells[0].Value = "0"; // delay column
                                LogMsg(LogMsgType.Warning, "", "", $"{SystemAppName}: Invalid delay value. Setting delay to '0'.");
                                //update value in delay
                                delay = row.Cells[0].Value?.ToString(); // delay column
                                                                        //   return; // or throw an exception, log an error, etc.
                            }

                            if (int.TryParse(delay, out var intValue))
                            {
                                await Task.Delay(intValue * 1000);
                                SendStrData(data);
                                if (!cbScriptEnable.Checked)
                                {
                                    LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Aborting Async Task Scripting");
                                    break;
                                }
                            }
                        }
                    }
                }


                if (!cbScriptLoop.Checked)
                {
                    timerScript.Enabled = false;
                    cbScriptEnable.Checked = false;
                    LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: End Async Task Scripting");
                    // Prevent changes while script is running.
                    gbScripting.Enabled = true;
                }
            }
        }
        /// <summary> Network ping a range of network devices</summary>
        public async Task ScanForNetworkDevicesAsync(string baseIpAddress, bool fastscan, int timeout = 1000, int startRange = 1, int endRange = 254) //254
        {
            Console.WriteLine("Scan For Network Devices");
            // Clear all items before we start scan.
            cmbNetworkDevices.Items.Clear();

            var tasks = new Task[endRange - startRange + 1];

            for (var i = startRange; i <= endRange; i++)
            {
                var ipAddress = $"{baseIpAddress}.{i}";
                tasks[i - startRange] = ScanSingleAsync(ipAddress, timeout, fastscan);
            }

            await Task.WhenAll(tasks);

            //Selects First Index
            if (cmbNetworkDevices.Items.Count > 0) cmbNetworkDevices.SelectedIndex = 0;
            else
            {
                MessageBox.Show(this, "There are no valid network adapters to scan.\nPlease check device manager then restart this app.", "No Network Adapters Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary> Network ping a single device</summary>
        private async Task ScanSingleAsync(string ipAddress, int timeout, bool fastscan)
        {
            var ping = new Ping();
            var reply = await ping.SendPingAsync(ipAddress, timeout);

            if (reply.Status == IPStatus.Success)
            {
                if (fastscan)
                {
                    LogRx(LogMsgType.Incoming, ipAddress, "", $"Device found: {ipAddress}");
                    if (!cmbNetworkDevices.Items.Contains(ipAddress))
                        cmbNetworkDevices.Items.Add(ipAddress);
                }
                else
                {
                    try
                    {
                        var entry = Dns.GetHostEntry(ipAddress);
                        var deviceName = entry.HostName;
                        LogRx(LogMsgType.Incoming, ipAddress, "", $"Host Info: {deviceName}");
                        if (!cmbNetworkDevices.Items.Contains(ipAddress))
                            cmbNetworkDevices.Items.Add(ipAddress);
                    }
                    catch (SocketException ex)
                    {
                        LogRx(LogMsgType.Incoming, ipAddress, "", $"Ping Success but Unable to resolve host name: {ex.Message}");
                        // Handle the exception gracefully, for example:
                        // Log the error, display a user-friendly message, or proceed with a default value.
                    }
                    catch (Exception ex)
                    {
                        LogRx(LogMsgType.Incoming, ipAddress, "", $"Ping Success but An unexpected error occurred: {ex.Message}");
                        // Handle other exceptions if needed.
                    }
                }
            }
            else
            {
                // If we want to do something for addresses that fail to ping
                //LogRx(LogMsgType.Incoming, ipAddress, "", "No Device found");
            }
        }
        /// <summary> Open Window About Box</summary>
        private void OpenWindowAboutBox()
        {
            // Check if the form is null or has been closed
            if (_aboutBoxForm == null || _aboutBoxForm.IsDisposed)
            {
                _aboutBoxForm = new AboutBox
                {
                    TopMost = true // Set the form to always be on top
                };
                _aboutBoxForm.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                _aboutBoxForm.BringToFront();
            }
        }
        #endregion // Local Methods
        #region Event Handlers
        #region Event Handlers > Main Form
        private void FrmTerminal_Load(object sender, EventArgs e)
        {

        }
        private void FrmTerminal_Shown(object sender, EventArgs e)
        {
        }
        private void FrmTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectUdp();
        }
        #endregion
        #region Events Handlers > Tool Strip Menu Item 
        private void TsmLogsOpen_Click(object sender, EventArgs e)
        {
            OpenTxtFileToDgvDialog(dgvLogWindow);
        }
        private void TsmLogsSaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    SaveDgvToTxtFile(dgvLogWindow, filePath);
                }
            }
        }
        private void TsmTVControls_Click(object sender, EventArgs e)
        {
        }
        private void TsmScriptOpen_Click(object sender, EventArgs e)
        {
            OpenTxtFileToDgvDialog(dgvScripting);
        }
        private void TsmScriptSaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    SaveDgvToTxtFile(dgvScripting, filePath);
                }
            }
        }
        private void TsmAutoReplyOpen_Click(object sender, EventArgs e)
        {
            OpenTxtFileToDgvDialog(dgvAutoReply);
        }
        private void TsmAutoReplySaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    SaveDgvToTxtFile(dgvAutoReply, filePath);
                }
            }
        }
        private void TsmiFileExit_Click(object sender, EventArgs e)
        {
            DisconnectUdp();
            Close();
        }
        private void TsmiFileLogs_Click(object sender, EventArgs e)
        {

        }
        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            OpenWindowAboutBox();
        }
        #endregion
        #region Event Handlers > Tool Strip Button Click
        private void TsbtnTVControls_Click(object sender, EventArgs e)
        {

        }
        private void TsbtnConnect_Click(object sender, EventArgs e)
        {

        }
        private void TsbtnDisconnect_Click(object sender, EventArgs e)
        {

        }
        private void TsbtnLogOpen_Click(object sender, EventArgs e)
        {
            OpenTxtFileToDgvDialog(dgvLogWindow);
        }
        private void TsbtnLogSaveAs_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    SaveDgvToTxtFile(dgvLogWindow, filePath);
                }
            }
        }
        #endregion // Event Handler Tool Strip Button Click
        #region Event Handlers > Form Change
        private void CbScriptEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbScriptEnable.Checked)
            {
                //timerScript.Enabled = true;
                _ = ProcessScriptingAsync();
            }
        }
        private void CbAutoReplyEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoReplyEnable.Checked)
            {
                LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Auto Reply Scripting Enabled");
            }
            else
            {
                LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Auto Reply Scripting Disabled");
            }
        }
        private void CmbAdapterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the method to get the IPv4 address for the selected adapter
            var ipv4Address = GetIPv4AddressForSelectedAdapter();
            TbSrcIP.Text = ipv4Address;
            // Display or use the IPv4 address as needed
            Console.WriteLine($"IPv4 Address for Selected Adapter: {ipv4Address}");
        }
        private void TbAnalyzeHexData_GotFocus(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => (sender as TextBox).SelectAll()));
        }
        private void TbAnalyzeHexData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Handle Enter key press
                e.Handled = true;

                // Trigger the button click event (send the message)
                BtnAnalyzeHexDataSearch_Click(sender, e);
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
                // Handle Enter key press
                e.Handled = true;

                // Save the current non-blank message to history
                var currentMessage = TbMessage.Text.Trim();

                if (!string.IsNullOrWhiteSpace(currentMessage))
                {
                    // Check if the message is already in history and remove it
                    _messageHistory.Remove(currentMessage);

                    // Save the current message to history
                    _messageHistory.Insert(0, currentMessage);

                    // Debug output
                    Console.WriteLine("Added to history: " + currentMessage);
                    Console.WriteLine("History count: " + _messageHistory.Count);

                    // Limit the number of records in history
                    if (_messageHistory.Count > _maxHistorySize)
                    {
                        _messageHistory.RemoveAt(_messageHistory.Count - 1);
                    }
                }

                // Trigger the button click event (send the message)
                BtnSendMessage_Click(sender, e);

                // Reset history index for new messages
                _historyIndex = -1;
            }
        }
        private void TbSrcPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and the delete key
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
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
        private void TimerScript_Tick(object sender, EventArgs e)
        {
        }
        #endregion
        #region Events Handlers > Form Button Click
        private void BtnUDPConnect_Click(object sender, EventArgs e)
        {
            ConnectUdp();
        }
        private void BtnRefreshAdapters_Click(object sender, EventArgs e)
        {

        }
        private void BtnUDPDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectUdp();
        }
        private async void BtnQuickScan_Click(object sender, EventArgs e)
        {
            // Get the IP address from the text box
            var ipAddressText = TbSrcIP.Text;

            // Parse the three octets
            if (TryParseIpAddress(ipAddressText, out var baseIpAddress))
            {
                // Perform the scan with the parsed base IP address
                await ScanForNetworkDevicesAsync(baseIpAddress, true);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show($"Invalid IP address format. {TbSrcIP.Text}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void BtnSlowScan_Click(object sender, EventArgs e)
        {
            // Get the IP address from the text box
            var ipAddressText = TbSrcIP.Text;

            // Parse the three octets
            if (TryParseIpAddress(ipAddressText, out var baseIpAddress))
            {
                // Perform the scan with the parsed base IP address
                await ScanForNetworkDevicesAsync(baseIpAddress, false);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show($"Invalid IP address format. {TbSrcIP.Text}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void BtnHostInfo_Click(object sender, EventArgs e)
        {
            if (cmbNetworkDevices.Text != "")
            {
                await ScanSingleAsync(cmbNetworkDevices.Text, 1000, false);
            }
            else
            {
                // Display local information if Network Devices is blank
                // Keep it blank to avoid corner conditions.
                await ScanSingleAsync(TbSrcIP.Text, 1000, false);
                cmbNetworkDevices.Items.Clear();
            }

        }
        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            // Set the local port for receiving messages
            var localPort = StringtoInt(TbDestPort.Text);
            if (TryParseIpAddress(TbDestIP.Text, out _))
            {
                TxUdpMsg(TbDestIP.Text, localPort, TbMessage.Text);
                LogTx(LogMsgType.Outgoing,
                    TbSrcIP.Text + ":" + TbSrcPort.Text,
                    TbDestIP.Text + ":" + localPort,
                    TbMessage.Text);
            }
            else
            {
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: Invalid Dest IP Address : {TbDestIP.Text}");
            }
            // Save the current non-blank message to history
            var currentMessage = TbMessage.Text.Trim();

            if (!string.IsNullOrWhiteSpace(currentMessage))
            {
                // Check if the message is already in history and remove it
                _messageHistory.Remove(currentMessage);

                // Save the current message to history
                _messageHistory.Insert(0, currentMessage);

                // Debug output
                Console.WriteLine("Added to history: " + currentMessage);
                Console.WriteLine("History count: " + _messageHistory.Count);

                // Limit the number of records in history
                if (_messageHistory.Count > _maxHistorySize)
                {
                    _messageHistory.RemoveAt(_messageHistory.Count - 1);
                }
            }

            // Clear the text box or take other actions as needed
            // todo: we may not want to clear textbox if fail to send.
            if (cbClearMsgAfterSend.Checked) TbMessage.Clear();

            // Reset history index for new messages
            _historyIndex = -1;
        }
        private void BtnAnalyzeHexDataSearch_Click(object sender, EventArgs e)
        {
            // Search in 2nd Column
            SearchAndShowResults(dgvLogWindow, 5, TbAnalyzeHexData.Text);
        }
        private void BtnAnalyzeHexDataShowAll_Click(object sender, EventArgs e)
        {
            UnhideAllRows(dgvLogWindow);
        }
        private void BtnTermClearAll_Click(object sender, EventArgs e)
        {
            // Clear all rows and columns
            // todo: add pop up to give a warning
            dgvLogWindow.Rows.Clear();
        }
        private void BtnDelSelRow_Click(object sender, EventArgs e)
        {
            // Delete selected rows in dgvLogWindow
            DeleteSelectedRows();
        }
        private void BtnTermReset_Click(object sender, EventArgs e)
        {
            dgvLogWindow.Rows.Clear();
            LogMsg(LogMsgType.MsgFromApp, "", "", $"{SystemAppName}: Resetting Log...");
            InitializeDataGridView();
        }
        #endregion // Events Handler Form Button Click
        #endregion // Event Handlers
    }
}

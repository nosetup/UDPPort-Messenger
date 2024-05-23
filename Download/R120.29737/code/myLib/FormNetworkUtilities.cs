using System;
using System.Windows.Forms;
using MyUtilities;
using TcpIpInterface;

namespace LogTerminal
{
    public partial class FormNetworkUtilities : Form
    {

        #region Delegates
        private readonly MyDelegates.HostInfo _hostInfo;
        #endregion

        #region Local Variables
        public static string TraceClass;
        #endregion

        #region Classes
        // Create an instance of classes
        readonly NetworkUtil _networkUtil = new NetworkUtil();
        readonly MyVar _myVar = new MyVar();
        readonly MyUi _myUi = new MyUi();
        public MySharedData _sharedData;
        #pragma warning disable
        private static FrmTerminal s_parentForm;
        #pragma warning restore
        #endregion // Classes

        #region Constructor
        public FormNetworkUtilities(FrmTerminal parent, 
                                    MySharedData mySharedData, 
                                    MyDelegates.HostInfo hostInfo)
        {
            TraceClass = GetType().Name; // Assign the class name to the static variable
            s_parentForm = parent;
            _sharedData = mySharedData;
            _hostInfo = hostInfo;

            InitializeComponent();
            _networkUtil.DiscoveryTask += UpdateCmbNetworkDevices;

        }
        #endregion // Constructor

        #region Local Properties
        public bool FormEnable
        {
            set
            {
                gbNetworkUtil.Enabled = value;
            }
        }

        #endregion // Local Properties

        #region Local Methods

        /// <summary> A single update command to display either Quick Scan or Slow scan
        /// Quick Scan will contain IP Address (Key) with Null (Value)
        /// Slow Scan will contain IP Address (Key) with Host Name or Null
        /// Output to Cmb.. Display all Keys
        /// Output to log.. if null, Give a generic response that would work with both null and !null values.
        /// "Ping successful.. Host name information not availalbe"
        /// </summary>
        private void UpdateCmbNetworkDevices(object sender, DeviceDiscoveryEventArgs e)
        {
            _myUi.InvokeIfRequired(cmbNetworkDevices, () =>
            {
                // lets clear the list to start fresh
                cmbNetworkDevices.Items.Clear();
            });
#if debug
            Trace.WriteLine("Go over dictionary and add to combo list.");
#endif
            foreach (var ipaddress in _networkUtil.listActiveNetworkDevices.Keys)
            {
                // Access the description using the key (adapter name)
                var hostname = _networkUtil.listActiveNetworkDevices[ipaddress];

                // Add all ping successful to combobox list
                _myUi.InvokeIfRequired(cmbNetworkDevices, () =>
                {
                    cmbNetworkDevices.Items.Add($"{ipaddress}");
                    _hostInfo(ipaddress, hostname);
                });
            }
            //After listing items, Selects First Index
            _myUi.InvokeIfRequired(cmbNetworkDevices, () =>
            {
                if (cmbNetworkDevices.Items.Count > 0) cmbNetworkDevices.SelectedIndex = 0;
            });
        }

        #endregion // Local Methods

        #region Event Handlers

        #region Event Handlers > Form Change
        private void FormNetworkUtilities_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Cancel the form closing
            Hide(); // Hide the form instead
        }
        #endregion // Event Handlers > Form Change

        #region Events Handlers > Form Button Click
        private async void BtnQuickScan_Click(object sender, EventArgs e)
        {
            // Get the IP address from the text box
            var ipAddressText = _sharedData.SourceIP;

            // Parse the three octets
            if (_myVar.TryParseIpAddress3Octet(ipAddressText, out var baseIpAddress))
            {
                Console.WriteLine($"IPADDRESS 3 OCT {baseIpAddress}");
                // Perform the scan with the parsed base IP address
                await _networkUtil.ScanForNetworkDevicesAsync(baseIpAddress, true);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show($"Invalid IP address format. {_sharedData.SourceIP}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnHostInfo_Click(object sender, EventArgs e)
        {
            // This is a blocking method
            if (cmbNetworkDevices.Text != "")
            {
                var hostname = _networkUtil.GetHostNameByIPAddress(cmbNetworkDevices.Text);
                _hostInfo(cmbNetworkDevices.Text, hostname);
            }
            else
            {
                // Display local information if Network Devices is blank
                // Keep it blank to avoid corner conditions.
                var hostname = _networkUtil.GetHostNameByIPAddress(cmbNetworkDevices.Text);
                _hostInfo(_sharedData.SourceIP, hostname);
                cmbNetworkDevices.Items.Clear();
            }
        }

        private async void BtnScanNetwork_Click(object sender, EventArgs e)
        {
            // Get the IP address from the text box
            var ipAddressText = _sharedData.SourceIP;

            // Parse the three octets
            if (_myVar.TryParseIpAddress3Octet(ipAddressText, out var baseIpAddress))
            {
                // Perform the scan with the parsed base IP address
                await _networkUtil.ScanForNetworkDevicesAsync(baseIpAddress, false);
            }
        }

        #endregion // Events Handlers > Form Button Click

        #endregion // Event Handlers

    }
}

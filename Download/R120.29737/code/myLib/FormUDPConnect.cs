using MyUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpIpInterface;

namespace LogTerminal
{
    public partial class FormUDPConnect : Form
    {
        #region Delegates
        private readonly MyDelegates.ConnectUDPDelegate _connect;
        private readonly MyDelegates.DisconnectDelegate _disconnect;
        #endregion

        #region Local Variables
        public static string TraceClass;
        #endregion

        #region Classes
        // Create an instance of classes
        public MySharedData _sharedData;
#pragma warning disable
        private static FrmTerminal s_parentForm;
#pragma warning restore
        readonly NetworkAdapterMgr _networkAdapterManager = new NetworkAdapterMgr();
        #endregion

        #region Constructor
        public FormUDPConnect(FrmTerminal parent,
            MySharedData mySharedData,
            MyDelegates.ConnectUDPDelegate connect,
            MyDelegates.DisconnectDelegate disconnect
            )
        {
            _sharedData = mySharedData;
            _connect = connect;
            _disconnect = disconnect;

            TraceClass = GetType().Name; // Assign the class name to the static variable
            s_parentForm = parent;
            InitializeComponent();

            cmbAdapterName.SelectedIndexChanged += CmbAdapterName_SelectedIndexChanged;
            InitializeCmbAdapterName();
            _sharedData.SourceIP = TbSrcIP.Text; // Initialize SourceIP as first item selected
        }
        #endregion

        #region Local Properties
        public bool FormEnable
        {
            set
            {
                cmbAdapterName.Enabled = !value;
                TbSrcPort.Enabled = !value;
                BtnRefreshAdapters.Enabled = !value;
                BtnUDPConnect.Enabled = !value;
                BtnUDPDisconnect.Enabled = value;
            }
        }

        public string SourceIP 
        { 
            get { return TbSrcIP.Text; } 
        }

        public string SourcePort
        {
            get { return TbSrcPort.Text; }
        }
        #endregion

        #region Local Methods

        private void InitializeCmbAdapterName()
        {
            cmbAdapterName.Items.Clear();
            _networkAdapterManager.UpdateNetworkAdapterList();
            foreach (var nic in _networkAdapterManager.adapterDictionary.Keys)
            {
                // Access the description using the key (adapter name)
                var description = _networkAdapterManager.adapterDictionary[nic];

                // Add the adapter name and description to the ComboBox
                cmbAdapterName.Items.Add($"{nic} / {description}");
            }

            //After list is items, Selects First Index
            if (cmbAdapterName.Items.Count > 0)
            { 
                cmbAdapterName.SelectedIndex = 0;
            }
            //Loads Default / Last Saved Port Name
            // else if (cmbAdapterName.Items.Contains(Settings.Default.PortName)) cmbAdapterName.Text = Settings.Default.PortName;
            else
            {
                MessageBox.Show(this, "There are no network adapters detected on this computer.\nPlease check device manager then restart this app.", "No Network Adapters Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        #endregion // Local Methods

        #region Event Handlers

        #region Event Handlers > Form Change

        private void FormUDPConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the form closing
                Hide(); // Hide the form instead
            }
        }

        private void CmbAdapterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the method to get the IPv4 address for the selected adapter
            // We will remove the '/' that was added in GUI.
            var ipv4Address = _networkAdapterManager.GetIPv4AddressForSelectedAdapter(cmbAdapterName.Text.Split('/')[0].Trim());
            TbSrcIP.Text = ipv4Address;
            // Display or use the IPv4 address as needed
            Trace.WriteLine($"IPv4 Address for Selected Adapter: {ipv4Address}");
        }
        #endregion // Event Handlers > Form Change


        #region Events Handlers > Form Button Click

        private void BtnUDPConnect_Click(object sender, EventArgs e)
        {
            // Set IP / Port# before making connection
            _sharedData.SourceIP = TbSrcIP.Text;
            _sharedData.SourcePort = TbSrcPort.Text;
            _connect(TbSrcPort.Text);
        }

        private void BtnUDPDisconnect_Click(object sender, EventArgs e)
        {
            _disconnect();
        }

        private void BtnRefreshAdapters_Click(object sender, EventArgs e)
        {
            InitializeCmbAdapterName();
        }
        #endregion // Events Handlers > Form Button Click


        #endregion // Event Handlers

    }
}

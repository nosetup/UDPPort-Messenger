#region Credits
/* 
 * simple UDP messenging app.
 * by N Diep
*/
#endregion
#region Namespace Inclusions
using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

// User Added Namespace
using UdpInterface;
using MyUtilities;



#endregion
namespace LogTerminal
{
    #region Public Enumerations

    #endregion
    public partial class FrmTerminal : Form
    {
        #region Local Variables
        public static string TraceClass;
        public const string SystemAppName = "UDPPortMessengerApp";
        #endregion

        #region Classes
        public MySharedData _sharedData;
        readonly UdpConnect _udpConnect;
        readonly MyVar _myVar = new MyVar();
        readonly MyUi _myUi = new MyUi();
        readonly MyForms _myForms = new MyForms();

        // Keep track of child window instance
        private FormNetworkUtilities _networkUtilitiesInstance;
        public FormUDPAutomate _udPAutomateInstance;
        private FormUDPConnect _udpConnectInstance;
        private FormNetworkTestPing _networkPingTestInstance;
        private FormUDPLogWindow _udpLogWindowInstance;
        private AboutBox _aboutBoxForm;
        #endregion // Classes

        #region Constructor
        public FrmTerminal()
        {
            // Build the form
            InitializeComponent();


            _sharedData = new MySharedData
            {
                SystemAppName = SystemAppName
            };
            _udpConnect = new UdpConnect();

            InitializeChildForms();
            _udpConnectInstance.Show(); // Show this as default screen

            // If Release build, hide Debug UI.
            InitializeReleaseUI();

            // Enable/disable controls based on the current state
            // Depends on an instance of UDPConnect()
            EnableControls();

            _udpConnect.NewRxUdpData += (sender, e) => RxUdpMsg(sender, e, e.Udpendpoint);

        }
        #endregion // Constructor

        #region Local Properties
        #endregion // Local Properties

        #region Local Methods
        public void InitializeChildForms()
        {
            // Settings / Connection
            if (_udpConnectInstance == null || _udpConnectInstance.IsDisposed)
                _udpConnectInstance = new FormUDPConnect(this, _sharedData, ConnectUdp, DisconnectUdp);
            _myForms.InitializeSingleInstanceForm(this, _udpConnectInstance); 

            // LOG WINDOW
            if (_udpLogWindowInstance == null || _udpLogWindowInstance.IsDisposed)
                _udpLogWindowInstance = new FormUDPLogWindow(this, _sharedData, IsUdpConnected, TxUdpMsg);
            _myForms.InitializeSingleInstanceForm(this, _udpLogWindowInstance); 
            
            // AUTOMATION / SCRIPTING
            if (_udPAutomateInstance == null || _udPAutomateInstance.IsDisposed)
                _udPAutomateInstance = new FormUDPAutomate(this, _sharedData, IsUdpConnected, AutomateActive, TraceAppMsg, SendStrData);
            _myForms.InitializeSingleInstanceForm(this, _udPAutomateInstance);

            // PING TEST
            if (_networkPingTestInstance == null || _networkPingTestInstance.IsDisposed)
                _networkPingTestInstance = new FormNetworkTestPing(this, _sharedData, TraceAppMsg);
            _myForms.InitializeSingleInstanceForm(this, _networkPingTestInstance);

            // UTILITIES
            if (_networkUtilitiesInstance == null || _networkUtilitiesInstance.IsDisposed)
                _networkUtilitiesInstance = new FormNetworkUtilities(this, _sharedData, LogHostInfo);
            _myForms.InitializeSingleInstanceForm(this, _networkUtilitiesInstance);

            // ABOUT FORM
            _myForms.InitializeSingleInstanceForm(this, _aboutBoxForm); // ABOUT THIS APP
        }

        /// <summary>
        /// Hide all Debug UI</summary>
        private void InitializeReleaseUI()
        {
#if !DEBUG
            TsbtnClearConsole.Visible = false;
            BtnSideCapture.Visible = false;
            BtnSideInfo.Visible = false;
            BtnTestHide.Visible = false;
#endif
        }

        /// <summary>
        /// Save the user's settings. </summary>
        public void SaveSettings()
        {
        }
        /// <summary>
        /// Enable/disable controls based on the app's current state. </summary>
        public void EnableControls()
        {
            tsbtnConnect.Enabled = !IsUdpConnected();
            tsbtnDisconnect.Enabled = IsUdpConnected();
            _myUi.InvokeIfRequired(_networkUtilitiesInstance, () => { _networkUtilitiesInstance.FormEnable = IsUdpConnected(); ; });
            _myUi.InvokeIfRequired(_udPAutomateInstance, () => { _udPAutomateInstance.FormEnable = IsUdpConnected(); ; });
            _myUi.InvokeIfRequired(_udpConnectInstance, () => { _udpConnectInstance.FormEnable = IsUdpConnected(); ; });
            _myUi.InvokeIfRequired(_udpLogWindowInstance, () => { _udpLogWindowInstance.FormEnable = IsUdpConnected(); ; });
        }

        public void DisableControls()
        {
            tsbtnConnect.Enabled = true;
            tsbtnDisconnect.Enabled = false;
            // _myUi.InvokeIfRequired(_tvRemoteForm, () => { _tvRemoteForm.FormEnable = false; });
            _myUi.InvokeIfRequired(_networkUtilitiesInstance, () => { _networkUtilitiesInstance.FormEnable = false; });
            _myUi.InvokeIfRequired(_udPAutomateInstance, () => { _udPAutomateInstance.FormEnable = false; });
            _myUi.InvokeIfRequired(_udpConnectInstance, () => { _udpConnectInstance.FormEnable = false; });
            _myUi.InvokeIfRequired(_udpLogWindowInstance, () => { _udpLogWindowInstance.FormEnable = false; });
        }

        public void AutomateActive()
        {
            
        }

        /// <summary>
        /// UDP Connect</summary>
        public void ConnectUdp(string source_port)
        {
            _udpConnect.SocketConnect(source_port);
            EnableControls();
            tsslConnectionStatus.Text = $"Connected : {_sharedData.SourceIP} Port: {_sharedData.SourcePort}";
        }
        
        /// <summary>
        /// UDP Connection status Check if the UDP client is initialized and the receiving thread is alive</summary>
        public bool IsUdpConnected()
        {
            return _udpConnect.UdpIsConnected();
        }
        /// <summary>
        /// UDP Disconnect</summary>
        public void DisconnectUdp()
        {
            DisableControls();
            _udpConnect.SocketDisconnect();
            _sharedData.SourceIP = "";
            _sharedData.SourcePort = "";
            tsslConnectionStatus.Text = $"Disconnected";
        }
        /// <summary>
        /// UDP Recieve message .. access from another thread</summary>
        #pragma warning disable
        public void RxUdpMsg(object sender, UdpDataEventArgs e, IPEndPoint udpendpoint)
        #pragma warning restore
        {
            // Show the Rx Message in the Log, use local address from connector adapter
            var receivedMessage = Encoding.ASCII.GetString(e.Buffer);
            LogRx(LogMsgType.Incoming, $"{udpendpoint}", $"{_sharedData.SourceIP}:{_sharedData.SourcePort}", $"{receivedMessage}");

            // This access child form UI
            if (_udPAutomateInstance.AutoReplyEnableCheckbox.Checked)
            {
                _ = _udPAutomateInstance.ProcessAutoReplyAsync(receivedMessage);
            }
        }

        /// <summary>
        /// UDP Send message</summary>
        public void TxUdpMsg(string ipaddress, int remotePort, string message)
        {
            _udpConnect.TxUdpMsg(ipaddress, remotePort, message);
        }
        /// <summary>
        /// Send the user's data currently entered in the 'send' box.</summary>
        public void SendStrData(string strdata)
        {
            var destIP = _udpLogWindowInstance.DestIP;
            var destPort = _udpLogWindowInstance.DestPort;

            // Set the local port for receiving messages
            var localPort = _myVar.StringtoInt(destPort);
            if (_myVar.TryParseIpAddress(destIP, out _))
            {
                TxUdpMsg(destIP, localPort, strdata);
                LogTx(LogMsgType.Outgoing,
                    _sharedData.SourceIP + ":" + _sharedData.SourcePort,
                    destIP + ":" + localPort,
                    strdata);
            }
            else
            {
                LogTx(LogMsgType.Error, "", "", $"{SystemAppName}: Invalid Dest IP Address : {destIP}");
            }
        }
        public void LogTx(LogMsgType msgtype, string src, string dest, string msg)
        {
            _myUi.InvokeIfRequired(_udpLogWindowInstance, () => _udpLogWindowInstance.LogTx(msgtype, src, dest, msg));
        }
        /// <summary> Log Rx data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogRx(LogMsgType msgtype, string src, string dest, string msg)
        {
            _myUi.InvokeIfRequired(_udpLogWindowInstance, () => _udpLogWindowInstance.LogRx(msgtype, src, dest, msg));
        }
        /// <summary> Log system message to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="src"> The string containing the src to be shown. </param>
        /// <param name="dest"> The string containing the dest to be shown. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void LogMsg(LogMsgType msgtype, string src, string dest, string msg)
        {
            _myUi.InvokeIfRequired(_udpLogWindowInstance, () => _udpLogWindowInstance.LogMsg(msgtype, src, dest, msg));
        }
        /// <summary> Wrapper to forward log messages
        /// </summary>
        public void TraceAppMsg(LogMsgType msgtype, string src, string dest, string msg)
        {
            _myUi.InvokeIfRequired(_udpLogWindowInstance, () => _udpLogWindowInstance.LogMsg(msgtype, src, dest, msg));
#if DEBUG
            Trace.WriteLine($"{TraceClass} : src = {src} : dest = {dest} : msg = {msg}");
#endif
        }

        /// <summary>
        /// To format and log information collected from Network Utilities Slow Scan
        /// </summary>
        public void LogHostInfo(string ipaddress, string hostname)
        {
            if (hostname != null)
            {
                LogRx(LogMsgType.Incoming, ipaddress, "", $"Host Info='{hostname}'");
                Trace.WriteLine($"Device Address ='{ipaddress}', Host Info='{hostname}'");
            }
            else
            {
                LogRx(LogMsgType.Incoming, ipaddress, "", $"Ping successful.. Host name not availalbe");
                Trace.WriteLine($"Device Address ='{ipaddress}', Ping successful.. Host name not availalbe");
            }
        }
        /// <summary>
        /// Open Window About Box</summary>
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
        private void TsmTVControls_Click(object sender, EventArgs e)
        {
        }
        private void TsmiFileExit_Click(object sender, EventArgs e)
        {
            DisconnectUdp();
            Close();
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
            // Set IP / Port# before making connection
            _sharedData.SourceIP = _udpConnectInstance.SourceIP;
            _sharedData.SourcePort = _udpConnectInstance.SourcePort;
            ConnectUdp(_udpConnectInstance.SourcePort);
        }
        private void TsbtnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectUdp();
        }
        /// <summary> Add space for Console / Trace Writeline</summary>
        private void TsbtnClearConsole_Click(object sender, EventArgs e)
        {
            Trace.WriteLine($"\n\n"); // Used for debugging, add space in console for readability.
        }
        #endregion // Event Handler Tool Strip Button Click
        #region Event Handlers > Form Change
        private void TimerScript_Tick(object sender, EventArgs e)
        {
        }
        #endregion

        #region Events Handlers > Form Button Click

        private void BtnSideSettings_Click(object sender, EventArgs e)
        {
            if (_udpConnectInstance == null || _udpConnectInstance.IsDisposed)
                _udpConnectInstance = new FormUDPConnect(this, _sharedData, ConnectUdp, DisconnectUdp);
            _myForms.OpenSingleInstanceForm(this, _udpConnectInstance); // Use the modified method
        }

        private void BtnSideLogWindow_Click(object sender, EventArgs e)
        {
            if (_udpLogWindowInstance == null || _udpLogWindowInstance.IsDisposed)
                _udpLogWindowInstance = new FormUDPLogWindow(this, _sharedData, IsUdpConnected, TxUdpMsg);
            _myForms.OpenSingleInstanceForm(this, _udpLogWindowInstance); // Use the modified method
        }

        private void BtnSideAutomate_Click(object sender, EventArgs e)
        {
            if (_udPAutomateInstance == null || _udPAutomateInstance.IsDisposed)
                _udPAutomateInstance = new FormUDPAutomate(this, _sharedData, IsUdpConnected, AutomateActive, TraceAppMsg, SendStrData);
            _myForms.OpenSingleInstanceForm(this, _udPAutomateInstance); // Use the modified method
        }
        private void BtnSideTesting_Click(object sender, EventArgs e)
        {
            if (_networkPingTestInstance == null || _networkPingTestInstance.IsDisposed)
                _networkPingTestInstance = new FormNetworkTestPing(this, _sharedData, TraceAppMsg);
            _myForms.OpenSingleInstanceForm(this, _networkPingTestInstance);
        }

        private void BtnSideUtilities_Click(object sender, EventArgs e)
        {
            if (_networkUtilitiesInstance == null || _networkUtilitiesInstance.IsDisposed)
                _networkUtilitiesInstance = new FormNetworkUtilities(this, _sharedData, LogHostInfo);
            _myForms.OpenSingleInstanceForm(this, _networkUtilitiesInstance); // Use the modified method
        }
        #endregion // Events Handler Form Button Click

        #endregion // Event Handlers

    }
}

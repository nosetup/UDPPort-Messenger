#region Credits
/* 
 * Modified by N Diep
 * 
*/
#endregion
#region Namespace Inclusions
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace UDPInterface
{
    public class UDPConnect
    {
        #region Local Variables
        static UdpClient s_udpClient;
        static IPEndPoint s_localEndPoint;
        private Thread _receiveThread;
        private bool _exitRequested = false;
        #endregion


        #region Constructor
        public UDPConnect()
        {
            // Set up the UDP client for sending and receiving
            s_udpClient = new UdpClient();

            // Set the local port for receiving messages
            var localPort = 12345;

            // Create an endpoint for receiving messages on any available IP address
            s_localEndPoint = new IPEndPoint(IPAddress.Any, localPort);

            // Bind the UDP client to the local endpoint
            s_udpClient.Client.Bind(s_localEndPoint);

            // Start a new thread for receiving messages
            var receiveThread = new System.Threading.Thread(RxUDPMsg);
            receiveThread.Start();

            Console.WriteLine("UDP Messaging App - Type 'exit' to quit");

            // Allow the user to input messages to send
            string userInput;
            do
            {
                Console.Write("Enter message: ");
                userInput = Console.ReadLine();

                // Send the user input as a message
                //SendMessage(userInput);

            } while (userInput.ToLower() != "exit");

            // Close the UDP client and the receiving thread
            s_udpClient.Close();
            receiveThread.Abort();
        }


        #endregion

        #region Local Properties
        #endregion

        #region Local Methods
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
            }
            catch (OverflowException)
            {
                Console.WriteLine("The entered value is too large or too small for an integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
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
        public void SocketConnect(string strport)
        {
            // Set the local port for receiving messages
            var localPort = StringtoInt(strport);

            // Set the exit flag to true
            _exitRequested = false;

            // Set up the UDP client for sending and receiving
            s_udpClient = new UdpClient();

            // Create an endpoint for receiving messages on any available IP address
            s_localEndPoint = new IPEndPoint(IPAddress.Any, localPort);

            // Bind the UDP client to the local endpoint
            s_udpClient.Client.Bind(s_localEndPoint);

            // Start a new thread for receiving messages
            _receiveThread = new System.Threading.Thread(RxUDPMsg);
            _receiveThread.Start();
        }
        /// <summary> UDP Connection status</summary>
        public bool UDPIsConnected()
        {
            // Check if the UDP client is initialized and the receiving thread is alive
            return s_udpClient != null && _receiveThread != null && _receiveThread.IsAlive;
        }
        /// <summary> UDP Disconnect</summary>
        public void SocketDisconnect()
        {
            // Set the exit flag to true
            _exitRequested = true;
            if (UDPIsConnected())
            {
                // Close the UDP client and the receiving thread
                s_udpClient.Close();
            }
            // If the receiving thread is still alive, wait for it to finish gracefully
            if (_receiveThread != null && _receiveThread.IsAlive)
            {
                _receiveThread.Join();
            }
        }
        /// <summary> UDP Recieve message</summary>
        public void RxUDPMsg()
        {
            while (!_exitRequested)
            {
                if (s_udpClient.Available > 0)
                {
                    // Receive a message and the endpoint it was sent from
                    var receivedBytes = s_udpClient.Receive(ref s_localEndPoint);
                    var receivedMessage = Encoding.ASCII.GetString(receivedBytes);
                    // Print the received message
                    Console.WriteLine($"{s_localEndPoint}", "", $"{receivedMessage}");

                }
                else
                {
                    // Introduce a small delay if no data is available
                    Thread.Sleep(10); // Adjust the sleep duration as needed
                }
            }

        }
        /// <summary> UDP Send message</summary>
        static void TxUDPMsg(string ipaddress, int remotePort, string message)
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

                }
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
        #endregion

        #region Event Handlers
        #endregion

    }

}

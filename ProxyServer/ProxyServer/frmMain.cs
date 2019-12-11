using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyServer
{

    /**
    * Used to define app interaction logic
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public partial class frmMain : Form
    {
        // Initial port span 
        private const int MIN_PORT = 1;
        private const int MAX_PORT = 65535;

        public static readonly string CommonDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ProxyProxy");
        public static readonly string ConfigInfoPath = Path.Combine(CommonDataPath, "config.txt");

        private ProxyThread ProxyThreadListener = null;


        public frmMain()
        {
            InitializeComponent();

            this.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            var ips = GetLocalIPs().OrderBy(x => x);
            if (ips.Any())
            {
                cmbIPAddress.Items.Clear();
                foreach (string ip in ips)
                {
                    cmbIPAddress.Items.Add(ip);
                }
                cmbIPAddress.Text = cmbIPAddress.Items[0].ToString();
            }

            int port = 5000; // listen on external port 
            while (!CheckPortAvailability(port))
            {
                port++;
            }
            txtExternalPort.Text = port.ToString();
        }
     
        /*
         * GetLocalIPs() Function to get local IP address
         * 
         * @return ownIPS
         */
        private List<string> GetLocalIPs()
        {
            // Try to find our internal IP address...
            string myHost = System.Net.Dns.GetHostName();
            IPAddress[] addresses = System.Net.Dns.GetHostEntry(myHost).AddressList;
            List<string> ownIPs = new List<string>();
            string fallbackIP = "";

            for (int i = 0; i < addresses.Length; i++)
            {
                // Is this a valid IPv4 address?
                if (addresses[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    string thisAddress = addresses[i].ToString();
                    
                    // Loopback is not our preference...
                    if (thisAddress == "127.0.0.1")
                        continue;

                    // 168.x.x.x addresses are self-assigned "private network" IP by Windows!!!
                    if (thisAddress.StartsWith("168"))
                    {
                        fallbackIP = thisAddress;
                        continue;
                    }
                    ownIPs.Add(thisAddress);
                }
            }
            if (ownIPs.Count == 0 && !string.IsNullOrEmpty(fallbackIP))
            {
                ownIPs.Add(fallbackIP);
            }

            return ownIPs;
        }

        /*
         * CheckPortAvailability() Function to check TCP port availability
         * 
         * @param port
         * @return true
         */ 
        private bool CheckPortAvailability(int port)
        {
            /*
              http://stackoverflow.com/questions/570098/in-c-how-to-check-if-a-tcp-port-is-available

              Evaluate current system tcp connections. This is the same information provided
              by the netstat command line application, just in .Net strongly-typed object
              form.  We will look through the list, and if our port we would like to use
              in our TcpClient is occupied, we will set isAvailable to false.
            */
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                    return false;
            }

            try
            {
                TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
                listener.Start();
                listener.Stop();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

       /*
        * frmMain_Shown() Event 
        * 
        */
        private void frmMain_Shown(object sender, EventArgs e)
        {
            txtInternalPort.Focus();

            //Try to load config
            try
            {
                using (StreamReader sr = new StreamReader(ConfigInfoPath))
                {
                    var values = sr.ReadToEnd().Split('\n')
                                               .Select(x => x.Trim())
                                               .ToArray();

                    txtInternalPort.Text = values[0];
                    chkRewriteHostHeaders.Checked = bool.Parse(values[1]);
                }
            }
            //catch (Exception ex)
            //{
            //   throw new Exception(ex.ToString());
            //}
            catch
            { }
        }

       /*
        * frmMain_FormClosing() Event
        * 
        */
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ProxyThreadListener != null)
            {
                ProxyThreadListener.Stop();
            }

            //Try to save config
            try
            {
                if (!Directory.Exists(CommonDataPath))
                {
                    Directory.CreateDirectory(CommonDataPath);
                }
                using (StreamWriter sw = new StreamWriter(ConfigInfoPath))
                {
                    sw.WriteLine(txtInternalPort.Text);
                    sw.WriteLine(chkRewriteHostHeaders.Checked);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /*
         * btnStart_Click() Event
         * 
         *@return ShowError()
         */
        private void btnStart_Click(object sender, EventArgs e)
        {
            int externalPort = 0;
            int internalPort = 0;
            //Validation
            int.TryParse(txtExternalPort.Text, out externalPort);
            int.TryParse(txtInternalPort.Text, out internalPort);
            if (!CheckPortRange(externalPort)
                || !CheckPortRange(internalPort)
                || externalPort == internalPort)
            {
                ShowError("Ports must be between " + MIN_PORT + "-" + MAX_PORT + " and must not be the same.");
                return;
            }
            if (!CheckPortAvailability(externalPort))
            {
                ShowError("Port " + externalPort + " is not available, please select a different port.");
                return;
            }

            ProxyThreadListener = new ProxyThread(externalPort, internalPort, chkRewriteHostHeaders.Checked);

            ToggleButtons();
        }

       /*
        * CheckPortRange() Method to check TCP port range 
        * 
        * @param port
        * @return true
        */
        private bool CheckPortRange(int port)
        {
            if (port < MIN_PORT || port > MAX_PORT)
                return false;
            return true;
        }

       /*
        * ShowError() Function to show specific error message
        * 
        * @param msg
        */
        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*
         * btnStop_Click() Event 
         * 
         */
        private void btnStop_Click(object sender, EventArgs e)
        {
            ProxyThreadListener.Stop();

            ToggleButtons();
        }

        /*
         * ToogleButtons() Function to toggle buttons
         * 
         */
        private void ToggleButtons()
        {
            btnStop.Enabled = !btnStop.Enabled;
            btnStart.Enabled = !btnStart.Enabled;
            txtExternalPort.Enabled = !txtExternalPort.Enabled;
            txtInternalPort.Enabled = !txtInternalPort.Enabled;
            chkRewriteHostHeaders.Enabled = !chkRewriteHostHeaders.Enabled;
        }

        /*
         * txtPorts_KeyPress() Event 
         * 
         */
        private void txtPorts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnStart_Click(null, null);
            }
        }






    }
}

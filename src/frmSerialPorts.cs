using System.Diagnostics;
using System.IO.Ports;

namespace WinSerialPorts
{
    public partial class frmSerialPorts : Form
    {
        static bool Enumerating = false;

        /// <summary>
        ///  Form constructor - registers notification events from USB and enumerates ports
        /// </summary>
        public frmSerialPorts()
        {
            InitializeComponent();
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
            EnumeratePorts();
        }

        /// <summary>
        /// Sniff for USB notification messages to force a refresh
        /// </summary>
        /// <param name="m">Windows Message</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                    case UsbNotification.DbtDevicearrival:
                        EnumeratePorts();
                        break;
                }
            }
        }

        /// <summary>
        /// List the serial ports and see if they are available (can be opened)
        /// </summary>
        protected void EnumeratePorts()
        {
            // prevent re-entry - the number of notifications is unreliable
            if (Enumerating)
            {
                return;
            }
            Enumerating = true;

            listBoxPorts.Items.Clear();

            Debug.WriteLine("Enumerating COM ports");
            string[] ports = SerialPort.GetPortNames();
            string notifyText = "";

            foreach (string port in ports)
            {
                string portName = String.Format($"{port}: ");
                try
                {
                    SerialPort sp = new SerialPort(port, 9600);
                    sp.Open();
                    sp.Close();
                    portName += "Available";
                }
                catch (UnauthorizedAccessException)
                {
                    portName += "In Use";
                }
                catch
                {
                    portName += "Error";
                }
                Debug.WriteLine(portName);
                listBoxPorts.Items.Add(portName);
                notifyText += portName + "\r";
            }

            if (ports.Length == 0)
            {
                Debug.WriteLine("No COM ports found by enumeration");
                listBoxPorts.Items.Add("None");
                notifyText = "No Ports Found";
            }

            notifyIconPorts.Text = notifyText;
            Enumerating = false;
        }

        /// <summary>
        /// Check for keypresses that we want to handle
        /// </summary>
        /// <param name="sender">source - don't care</param>
        /// <param name="e">event args - the key</param>
        private void frmSerialPorts_KeyDown(object sender, KeyEventArgs e)
        {
            // force a refresh on F5
            if (e.KeyCode == Keys.F5)
            {
                EnumeratePorts();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handle resizing - minimize to the notification icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSerialPorts_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        /// <summary>
        /// Restore the window when the notificaiton icon is double-clicked
        /// </summary>
        /// <param name="sender">don't care</param>
        /// <param name="e">mouse event - double click</param>
        private void notifyIconPorts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}

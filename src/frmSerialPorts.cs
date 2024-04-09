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

            // start with an empty list
            listViewPorts.Items.Clear();
            List<SerialPortInfo> portList = new List<SerialPortInfo>();
            
            // get the set of ports and create a list of serial port info
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                SerialPortInfo serialPortInfo = new SerialPortInfo(port);
                if (serialPortInfo.Number > 0)
                {
                    portList.Add(new SerialPortInfo(port));
                }
                else
                {
                    Debug.WriteLine($"Discarding invalid serial port {port}");
                }
            }

            // sort the ports by number not the name
            portList.Sort((x,y) => x.Number.CompareTo(y.Number));

            // build the display list and notification text
            string notifyText = "";
            foreach (SerialPortInfo p in portList)
            {
                ListViewItem item = new ListViewItem(p.Name);
                item.SubItems.Add(p.Status);
                listViewPorts.Items.Add(item);
                notifyText += $"{p.Name}: {p.Status}\r";
            }

            // make sure that we have valid notification text - not empty, not too long for tooltips
            if (notifyText.Length == 0)
            {
                notifyText = "No ports found";
            }
            notifyIconPorts.Text = notifyText.Substring(0, (notifyText.Length > 127) ? 127 : notifyText.Length);

            // allow entry now that we are done
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

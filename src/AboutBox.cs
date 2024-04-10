namespace WinSerialPorts
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", "WinSerialPorts");
            this.labelProductName.Text = "WinSerialPorts";
            this.labelVersion.Text = String.Format("Version {0} Build {1:D4}", Program.Version, Program.BuildNumber);
            this.labelCopyright.Text = "Copyright © 2024 - All rights reserved.";
            this.labelCompanyName.Text = "Sanctuary Software Studio, Inc.";
            this.textBoxDescription.Text = "A utility for tracking serial ports on Microsoft Windows computers.\r\n\r\n" +
                "Use F5 to force a refresh. Minimizes to the notification area. Double-click to restore.\r\n\r\n" +
                "Provided free under the MIT License with source available on github.com. Visit www.sancsoft.com for more tips and tools.";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

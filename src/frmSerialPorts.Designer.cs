namespace WinSerialPorts
{
    partial class frmSerialPorts
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerialPorts));
            listBoxPorts = new ListBox();
            notifyIconPorts = new NotifyIcon(components);
            SuspendLayout();
            // 
            // listBoxPorts
            // 
            listBoxPorts.AllowDrop = true;
            listBoxPorts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxPorts.FormattingEnabled = true;
            listBoxPorts.ItemHeight = 15;
            listBoxPorts.Location = new Point(0, 0);
            listBoxPorts.Name = "listBoxPorts";
            listBoxPorts.SelectionMode = SelectionMode.None;
            listBoxPorts.Size = new Size(222, 154);
            listBoxPorts.Sorted = true;
            listBoxPorts.TabIndex = 0;
            listBoxPorts.UseTabStops = false;
            // 
            // notifyIconPorts
            // 
            notifyIconPorts.Icon = (Icon)resources.GetObject("notifyIconPorts.Icon");
            notifyIconPorts.Text = "Serial Ports";
            notifyIconPorts.Visible = true;
            notifyIconPorts.MouseDoubleClick += notifyIconPorts_MouseDoubleClick;
            // 
            // frmSerialPorts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 161);
            Controls.Add(listBoxPorts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "frmSerialPorts";
            Text = "Ports";
            KeyDown += frmSerialPorts_KeyDown;
            Resize += frmSerialPorts_Resize;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxPorts;
        private NotifyIcon notifyIconPorts;
    }
}

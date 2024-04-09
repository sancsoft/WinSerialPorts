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
            notifyIconPorts = new NotifyIcon(components);
            listViewPorts = new ListView();
            Port = new ColumnHeader();
            Status = new ColumnHeader();
            SuspendLayout();
            // 
            // notifyIconPorts
            // 
            notifyIconPorts.Icon = (Icon)resources.GetObject("notifyIconPorts.Icon");
            notifyIconPorts.Text = "Serial Ports";
            notifyIconPorts.Visible = true;
            notifyIconPorts.MouseDoubleClick += notifyIconPorts_MouseDoubleClick;
            // 
            // listViewPorts
            // 
            listViewPorts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewPorts.Columns.AddRange(new ColumnHeader[] { Port, Status });
            listViewPorts.Location = new Point(1, 0);
            listViewPorts.Name = "listViewPorts";
            listViewPorts.Size = new Size(222, 165);
            listViewPorts.TabIndex = 1;
            listViewPorts.UseCompatibleStateImageBehavior = false;
            listViewPorts.View = View.Details;
            // 
            // Port
            // 
            Port.Text = "Port";
            Port.Width = 100;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 100;
            // 
            // frmSerialPorts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 161);
            Controls.Add(listViewPorts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "frmSerialPorts";
            Text = "Ports";
            KeyDown += frmSerialPorts_KeyDown;
            Resize += frmSerialPorts_Resize;
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon notifyIconPorts;
        private ListView listViewPorts;
        private ColumnHeader Port;
        private ColumnHeader Status;
    }
}

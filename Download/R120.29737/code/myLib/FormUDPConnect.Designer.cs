namespace LogTerminal
{
    partial class FormUDPConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNIC = new System.Windows.Forms.Label();
            this.lblSrcPort = new System.Windows.Forms.Label();
            this.TbSrcPort = new System.Windows.Forms.TextBox();
            this.cmbAdapterName = new System.Windows.Forms.ComboBox();
            this.BtnUDPConnect = new System.Windows.Forms.Button();
            this.BtnRefreshAdapters = new System.Windows.Forms.Button();
            this.lblSrcIP = new System.Windows.Forms.Label();
            this.BtnUDPDisconnect = new System.Windows.Forms.Button();
            this.TbSrcIP = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNIC);
            this.groupBox3.Controls.Add(this.lblSrcPort);
            this.groupBox3.Controls.Add(this.TbSrcPort);
            this.groupBox3.Controls.Add(this.cmbAdapterName);
            this.groupBox3.Controls.Add(this.BtnUDPConnect);
            this.groupBox3.Controls.Add(this.BtnRefreshAdapters);
            this.groupBox3.Controls.Add(this.lblSrcIP);
            this.groupBox3.Controls.Add(this.BtnUDPDisconnect);
            this.groupBox3.Controls.Add(this.TbSrcIP);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 146);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local PC";
            // 
            // lblNIC
            // 
            this.lblNIC.AutoSize = true;
            this.lblNIC.Location = new System.Drawing.Point(7, 31);
            this.lblNIC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNIC.Name = "lblNIC";
            this.lblNIC.Size = new System.Drawing.Size(36, 20);
            this.lblNIC.TabIndex = 33;
            this.lblNIC.Text = "NIC";
            // 
            // lblSrcPort
            // 
            this.lblSrcPort.AutoSize = true;
            this.lblSrcPort.Location = new System.Drawing.Point(393, 64);
            this.lblSrcPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSrcPort.Name = "lblSrcPort";
            this.lblSrcPort.Size = new System.Drawing.Size(38, 20);
            this.lblSrcPort.TabIndex = 26;
            this.lblSrcPort.Text = "Port";
            // 
            // TbSrcPort
            // 
            this.TbSrcPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbSrcPort.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSrcPort.Location = new System.Drawing.Point(439, 63);
            this.TbSrcPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbSrcPort.MaxLength = 30;
            this.TbSrcPort.Name = "TbSrcPort";
            this.TbSrcPort.Size = new System.Drawing.Size(67, 26);
            this.TbSrcPort.TabIndex = 27;
            this.TbSrcPort.Text = "12345";
            // 
            // cmbAdapterName
            // 
            this.cmbAdapterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdapterName.FormattingEnabled = true;
            this.cmbAdapterName.Location = new System.Drawing.Point(60, 25);
            this.cmbAdapterName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAdapterName.Name = "cmbAdapterName";
            this.cmbAdapterName.Size = new System.Drawing.Size(504, 28);
            this.cmbAdapterName.TabIndex = 43;
            // 
            // BtnUDPConnect
            // 
            this.BtnUDPConnect.Location = new System.Drawing.Point(344, 98);
            this.BtnUDPConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnUDPConnect.Name = "BtnUDPConnect";
            this.BtnUDPConnect.Size = new System.Drawing.Size(106, 35);
            this.BtnUDPConnect.TabIndex = 28;
            this.BtnUDPConnect.Text = "Connect";
            this.BtnUDPConnect.Click += new System.EventHandler(this.BtnUDPConnect_Click);
            // 
            // BtnRefreshAdapters
            // 
            this.BtnRefreshAdapters.Font = new System.Drawing.Font("Wingdings 3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.BtnRefreshAdapters.Location = new System.Drawing.Point(60, 56);
            this.BtnRefreshAdapters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRefreshAdapters.Name = "BtnRefreshAdapters";
            this.BtnRefreshAdapters.Size = new System.Drawing.Size(40, 35);
            this.BtnRefreshAdapters.TabIndex = 42;
            this.BtnRefreshAdapters.Text = "P";
            this.BtnRefreshAdapters.Click += new System.EventHandler(this.BtnRefreshAdapters_Click);
            // 
            // lblSrcIP
            // 
            this.lblSrcIP.AutoSize = true;
            this.lblSrcIP.Location = new System.Drawing.Point(164, 64);
            this.lblSrcIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSrcIP.Name = "lblSrcIP";
            this.lblSrcIP.Size = new System.Drawing.Size(79, 20);
            this.lblSrcIP.TabIndex = 29;
            this.lblSrcIP.Text = "Source IP";
            // 
            // BtnUDPDisconnect
            // 
            this.BtnUDPDisconnect.Location = new System.Drawing.Point(458, 98);
            this.BtnUDPDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnUDPDisconnect.Name = "BtnUDPDisconnect";
            this.BtnUDPDisconnect.Size = new System.Drawing.Size(106, 35);
            this.BtnUDPDisconnect.TabIndex = 27;
            this.BtnUDPDisconnect.Text = "Disconnect";
            this.BtnUDPDisconnect.Click += new System.EventHandler(this.BtnUDPDisconnect_Click);
            // 
            // TbSrcIP
            // 
            this.TbSrcIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbSrcIP.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSrcIP.Location = new System.Drawing.Point(260, 63);
            this.TbSrcIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbSrcIP.MaxLength = 30;
            this.TbSrcIP.Name = "TbSrcIP";
            this.TbSrcIP.ReadOnly = true;
            this.TbSrcIP.Size = new System.Drawing.Size(116, 26);
            this.TbSrcIP.TabIndex = 30;
            // 
            // FormUDPConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 169);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormUDPConnect";
            this.Text = "Connection Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUDPConnect_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.Label lblSrcPort;
        private System.Windows.Forms.TextBox TbSrcPort;
        private System.Windows.Forms.ComboBox cmbAdapterName;
        private System.Windows.Forms.Label lblSrcIP;
        private System.Windows.Forms.TextBox TbSrcIP;
        private System.Windows.Forms.Button BtnUDPConnect;
        private System.Windows.Forms.Button BtnRefreshAdapters;
        private System.Windows.Forms.Button BtnUDPDisconnect;
    }
}
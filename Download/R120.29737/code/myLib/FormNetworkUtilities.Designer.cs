namespace LogTerminal
{
    partial class FormNetworkUtilities
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
            this.gbNetworkUtil = new System.Windows.Forms.GroupBox();
            this.BtnHostInfo = new System.Windows.Forms.Button();
            this.cmbNetworkDevices = new System.Windows.Forms.ComboBox();
            this.BtnQuickScan = new System.Windows.Forms.Button();
            this.BtnScanNetwork = new System.Windows.Forms.Button();
            this.gbNetworkUtil.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNetworkUtil
            // 
            this.gbNetworkUtil.Controls.Add(this.BtnHostInfo);
            this.gbNetworkUtil.Controls.Add(this.cmbNetworkDevices);
            this.gbNetworkUtil.Controls.Add(this.BtnQuickScan);
            this.gbNetworkUtil.Controls.Add(this.BtnScanNetwork);
            this.gbNetworkUtil.Location = new System.Drawing.Point(12, 12);
            this.gbNetworkUtil.Name = "gbNetworkUtil";
            this.gbNetworkUtil.Size = new System.Drawing.Size(719, 63);
            this.gbNetworkUtil.TabIndex = 50;
            this.gbNetworkUtil.TabStop = false;
            this.gbNetworkUtil.Text = "Network Utilities";
            // 
            // BtnHostInfo
            // 
            this.BtnHostInfo.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHostInfo.Location = new System.Drawing.Point(479, 20);
            this.BtnHostInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnHostInfo.Name = "BtnHostInfo";
            this.BtnHostInfo.Size = new System.Drawing.Size(106, 35);
            this.BtnHostInfo.TabIndex = 47;
            this.BtnHostInfo.Text = "Host Info";
            this.BtnHostInfo.Click += new System.EventHandler(this.BtnHostInfo_Click);
            // 
            // cmbNetworkDevices
            // 
            this.cmbNetworkDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetworkDevices.FormattingEnabled = true;
            this.cmbNetworkDevices.Location = new System.Drawing.Point(7, 25);
            this.cmbNetworkDevices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNetworkDevices.Name = "cmbNetworkDevices";
            this.cmbNetworkDevices.Size = new System.Drawing.Size(343, 28);
            this.cmbNetworkDevices.TabIndex = 45;
            // 
            // BtnQuickScan
            // 
            this.BtnQuickScan.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuickScan.Location = new System.Drawing.Point(365, 20);
            this.BtnQuickScan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnQuickScan.Name = "BtnQuickScan";
            this.BtnQuickScan.Size = new System.Drawing.Size(106, 35);
            this.BtnQuickScan.TabIndex = 46;
            this.BtnQuickScan.Text = "Quick Scan";
            this.BtnQuickScan.Click += new System.EventHandler(this.BtnQuickScan_Click);
            // 
            // BtnScanNetwork
            // 
            this.BtnScanNetwork.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnScanNetwork.Location = new System.Drawing.Point(593, 20);
            this.BtnScanNetwork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnScanNetwork.Name = "BtnScanNetwork";
            this.BtnScanNetwork.Size = new System.Drawing.Size(106, 35);
            this.BtnScanNetwork.TabIndex = 44;
            this.BtnScanNetwork.Text = "Slow Scan";
            this.BtnScanNetwork.Click += new System.EventHandler(this.BtnScanNetwork_Click);
            // 
            // FormNetworkUtilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 106);
            this.Controls.Add(this.gbNetworkUtil);
            this.Name = "FormNetworkUtilities";
            this.Text = "Network Utilities";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNetworkUtilities_FormClosing);
            this.gbNetworkUtil.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNetworkUtil;
        private System.Windows.Forms.Button BtnHostInfo;
        private System.Windows.Forms.ComboBox cmbNetworkDevices;
        private System.Windows.Forms.Button BtnQuickScan;
        private System.Windows.Forms.Button BtnScanNetwork;
    }
}
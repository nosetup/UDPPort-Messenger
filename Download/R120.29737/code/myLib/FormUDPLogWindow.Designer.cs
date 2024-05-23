namespace LogTerminal
{
    partial class FormUDPLogWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUDPLogWindow));
            this.gbSendMessage = new System.Windows.Forms.GroupBox();
            this.BtnTFTPFile = new System.Windows.Forms.Button();
            this.cbClearMsgAfterSend = new System.Windows.Forms.CheckBox();
            this.TbDestIP = new System.Windows.Forms.TextBox();
            this.lblDestIP = new System.Windows.Forms.Label();
            this.lblDestPort = new System.Windows.Forms.Label();
            this.TbDestPort = new System.Windows.Forms.TextBox();
            this.TbMessage = new System.Windows.Forms.TextBox();
            this.BtnSendMessage = new System.Windows.Forms.Button();
            this.BtnDataShowAll = new System.Windows.Forms.Button();
            this.BtnDataSearch = new System.Windows.Forms.Button();
            this.TbSearchData = new System.Windows.Forms.TextBox();
            this.dgvLogWindow = new System.Windows.Forms.DataGridView();
            this.TcLogWindow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbTermAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnDelSelRow = new System.Windows.Forms.Button();
            this.btnTermReset = new System.Windows.Forms.Button();
            this.btnTermClearAll = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TsBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.TsBtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.cbTermPauseRX = new System.Windows.Forms.CheckBox();
            this.gbSendMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogWindow)).BeginInit();
            this.TcLogWindow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSendMessage
            // 
            this.gbSendMessage.Controls.Add(this.BtnTFTPFile);
            this.gbSendMessage.Controls.Add(this.cbClearMsgAfterSend);
            this.gbSendMessage.Controls.Add(this.TbDestIP);
            this.gbSendMessage.Controls.Add(this.lblDestIP);
            this.gbSendMessage.Controls.Add(this.lblDestPort);
            this.gbSendMessage.Controls.Add(this.TbDestPort);
            this.gbSendMessage.Controls.Add(this.TbMessage);
            this.gbSendMessage.Controls.Add(this.BtnSendMessage);
            this.gbSendMessage.Location = new System.Drawing.Point(12, 76);
            this.gbSendMessage.Name = "gbSendMessage";
            this.gbSendMessage.Size = new System.Drawing.Size(576, 146);
            this.gbSendMessage.TabIndex = 52;
            this.gbSendMessage.TabStop = false;
            this.gbSendMessage.Text = "Send Message";
            // 
            // BtnTFTPFile
            // 
            this.BtnTFTPFile.Location = new System.Drawing.Point(15, 104);
            this.BtnTFTPFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnTFTPFile.Name = "BtnTFTPFile";
            this.BtnTFTPFile.Size = new System.Drawing.Size(106, 28);
            this.BtnTFTPFile.TabIndex = 42;
            this.BtnTFTPFile.Text = "TFTP File";
            this.BtnTFTPFile.Visible = false;
            // 
            // cbClearMsgAfterSend
            // 
            this.cbClearMsgAfterSend.AutoSize = true;
            this.cbClearMsgAfterSend.Checked = true;
            this.cbClearMsgAfterSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClearMsgAfterSend.Location = new System.Drawing.Point(280, 109);
            this.cbClearMsgAfterSend.Name = "cbClearMsgAfterSend";
            this.cbClearMsgAfterSend.Size = new System.Drawing.Size(220, 24);
            this.cbClearMsgAfterSend.TabIndex = 41;
            this.cbClearMsgAfterSend.Text = "Clear Message after Send";
            this.cbClearMsgAfterSend.UseVisualStyleBackColor = true;
            // 
            // TbDestIP
            // 
            this.TbDestIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbDestIP.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDestIP.Location = new System.Drawing.Point(81, 30);
            this.TbDestIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbDestIP.MaxLength = 30;
            this.TbDestIP.Name = "TbDestIP";
            this.TbDestIP.Size = new System.Drawing.Size(116, 26);
            this.TbDestIP.TabIndex = 36;
            this.TbDestIP.Text = "192.168.1.18";
            // 
            // lblDestIP
            // 
            this.lblDestIP.AutoSize = true;
            this.lblDestIP.Location = new System.Drawing.Point(11, 36);
            this.lblDestIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestIP.Name = "lblDestIP";
            this.lblDestIP.Size = new System.Drawing.Size(62, 20);
            this.lblDestIP.TabIndex = 35;
            this.lblDestIP.Text = "Dest IP";
            // 
            // lblDestPort
            // 
            this.lblDestPort.AutoSize = true;
            this.lblDestPort.Location = new System.Drawing.Point(226, 36);
            this.lblDestPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestPort.Name = "lblDestPort";
            this.lblDestPort.Size = new System.Drawing.Size(38, 20);
            this.lblDestPort.TabIndex = 39;
            this.lblDestPort.Text = "Port";
            // 
            // TbDestPort
            // 
            this.TbDestPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbDestPort.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDestPort.Location = new System.Drawing.Point(280, 32);
            this.TbDestPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbDestPort.MaxLength = 30;
            this.TbDestPort.Name = "TbDestPort";
            this.TbDestPort.Size = new System.Drawing.Size(114, 26);
            this.TbDestPort.TabIndex = 40;
            this.TbDestPort.Text = "12345";
            // 
            // TbMessage
            // 
            this.TbMessage.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMessage.Location = new System.Drawing.Point(15, 68);
            this.TbMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbMessage.MaxLength = 40;
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.Size = new System.Drawing.Size(379, 26);
            this.TbMessage.TabIndex = 31;
            // 
            // BtnSendMessage
            // 
            this.BtnSendMessage.Location = new System.Drawing.Point(402, 65);
            this.BtnSendMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSendMessage.Name = "BtnSendMessage";
            this.BtnSendMessage.Size = new System.Drawing.Size(82, 35);
            this.BtnSendMessage.TabIndex = 32;
            this.BtnSendMessage.Text = "Send";
            this.BtnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // BtnDataShowAll
            // 
            this.BtnDataShowAll.Location = new System.Drawing.Point(412, 37);
            this.BtnDataShowAll.Name = "BtnDataShowAll";
            this.BtnDataShowAll.Size = new System.Drawing.Size(98, 32);
            this.BtnDataShowAll.TabIndex = 18;
            this.BtnDataShowAll.Text = "Show All";
            this.BtnDataShowAll.UseVisualStyleBackColor = true;
            this.BtnDataShowAll.Click += new System.EventHandler(this.BtnDataShowAll_Click);
            // 
            // BtnDataSearch
            // 
            this.BtnDataSearch.Location = new System.Drawing.Point(308, 37);
            this.BtnDataSearch.Name = "BtnDataSearch";
            this.BtnDataSearch.Size = new System.Drawing.Size(98, 32);
            this.BtnDataSearch.TabIndex = 7;
            this.BtnDataSearch.Text = "Search";
            this.BtnDataSearch.UseVisualStyleBackColor = true;
            this.BtnDataSearch.Click += new System.EventHandler(this.BtnDataSearch_Click);
            // 
            // TbSearchData
            // 
            this.TbSearchData.Location = new System.Drawing.Point(22, 40);
            this.TbSearchData.MaxLength = 30;
            this.TbSearchData.Name = "TbSearchData";
            this.TbSearchData.Size = new System.Drawing.Size(269, 26);
            this.TbSearchData.TabIndex = 15;
            this.TbSearchData.Text = "Keyword";
            // 
            // dgvLogWindow
            // 
            this.dgvLogWindow.AllowUserToAddRows = false;
            this.dgvLogWindow.AllowUserToDeleteRows = false;
            this.dgvLogWindow.AllowUserToResizeRows = false;
            this.dgvLogWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLogWindow.ColumnHeadersHeight = 34;
            this.dgvLogWindow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogWindow.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogWindow.Location = new System.Drawing.Point(12, 248);
            this.dgvLogWindow.MinimumSize = new System.Drawing.Size(800, 100);
            this.dgvLogWindow.Name = "dgvLogWindow";
            this.dgvLogWindow.RowHeadersWidth = 62;
            this.dgvLogWindow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLogWindow.RowTemplate.Height = 18;
            this.dgvLogWindow.RowTemplate.ReadOnly = true;
            this.dgvLogWindow.Size = new System.Drawing.Size(901, 143);
            this.dgvLogWindow.TabIndex = 50;
            // 
            // TcLogWindow
            // 
            this.TcLogWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TcLogWindow.Controls.Add(this.tabPage1);
            this.TcLogWindow.Controls.Add(this.tabPage2);
            this.TcLogWindow.Location = new System.Drawing.Point(12, 410);
            this.TcLogWindow.Name = "TcLogWindow";
            this.TcLogWindow.SelectedIndex = 0;
            this.TcLogWindow.Size = new System.Drawing.Size(901, 119);
            this.TcLogWindow.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbTermPauseRX);
            this.tabPage1.Controls.Add(this.cbTermAutoScroll);
            this.tabPage1.Controls.Add(this.btnDelSelRow);
            this.tabPage1.Controls.Add(this.btnTermReset);
            this.tabPage1.Controls.Add(this.btnTermClearAll);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(893, 86);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log Window";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbTermAutoScroll
            // 
            this.cbTermAutoScroll.AutoSize = true;
            this.cbTermAutoScroll.Checked = true;
            this.cbTermAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermAutoScroll.Font = new System.Drawing.Font("Calibri", 8F);
            this.cbTermAutoScroll.Location = new System.Drawing.Point(593, 28);
            this.cbTermAutoScroll.Name = "cbTermAutoScroll";
            this.cbTermAutoScroll.Size = new System.Drawing.Size(100, 23);
            this.cbTermAutoScroll.TabIndex = 19;
            this.cbTermAutoScroll.Text = "AutoScroll";
            this.cbTermAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnDelSelRow
            // 
            this.btnDelSelRow.Font = new System.Drawing.Font("Calibri", 8F);
            this.btnDelSelRow.Location = new System.Drawing.Point(16, 22);
            this.btnDelSelRow.Name = "btnDelSelRow";
            this.btnDelSelRow.Size = new System.Drawing.Size(165, 35);
            this.btnDelSelRow.TabIndex = 18;
            this.btnDelSelRow.Text = "Clear Selected";
            this.btnDelSelRow.Click += new System.EventHandler(this.BtnDelSelRow_Click);
            // 
            // btnTermReset
            // 
            this.btnTermReset.Font = new System.Drawing.Font("Calibri", 8F);
            this.btnTermReset.Location = new System.Drawing.Point(308, 22);
            this.btnTermReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTermReset.Name = "btnTermReset";
            this.btnTermReset.Size = new System.Drawing.Size(112, 35);
            this.btnTermReset.TabIndex = 19;
            this.btnTermReset.Text = "Reset";
            this.btnTermReset.Click += new System.EventHandler(this.BtnTermReset_Click);
            // 
            // btnTermClearAll
            // 
            this.btnTermClearAll.Font = new System.Drawing.Font("Calibri", 8F);
            this.btnTermClearAll.Location = new System.Drawing.Point(188, 22);
            this.btnTermClearAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTermClearAll.Name = "btnTermClearAll";
            this.btnTermClearAll.Size = new System.Drawing.Size(112, 35);
            this.btnTermClearAll.TabIndex = 7;
            this.btnTermClearAll.Text = "Clear All";
            this.btnTermClearAll.Click += new System.EventHandler(this.BtnTermClearAll_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.BtnDataShowAll);
            this.tabPage2.Controls.Add(this.BtnDataSearch);
            this.tabPage2.Controls.Add(this.TbSearchData);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 86);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Search for keyword in message column.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TsBtnOpen,
            this.TsBtnSaveAs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(925, 52);
            this.toolStrip1.TabIndex = 54;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 47);
            this.toolStripLabel1.Text = "// Logs >";
            // 
            // TsBtnOpen
            // 
            this.TsBtnOpen.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnOpen.Image")));
            this.TsBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnOpen.Name = "TsBtnOpen";
            this.TsBtnOpen.Size = new System.Drawing.Size(48, 47);
            this.TsBtnOpen.Text = "Open";
            this.TsBtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnOpen.Click += new System.EventHandler(this.TsBtnOpen_Click);
            // 
            // TsBtnSaveAs
            // 
            this.TsBtnSaveAs.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnSaveAs.Image")));
            this.TsBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnSaveAs.Name = "TsBtnSaveAs";
            this.TsBtnSaveAs.Size = new System.Drawing.Size(63, 47);
            this.TsBtnSaveAs.Text = "Save As";
            this.TsBtnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnSaveAs.Click += new System.EventHandler(this.TsBtnSaveAs_Click);
            // 
            // cbTermPauseRX
            // 
            this.cbTermPauseRX.AutoSize = true;
            this.cbTermPauseRX.Font = new System.Drawing.Font("Calibri", 8F);
            this.cbTermPauseRX.Location = new System.Drawing.Point(469, 28);
            this.cbTermPauseRX.Name = "cbTermPauseRX";
            this.cbTermPauseRX.Size = new System.Drawing.Size(94, 23);
            this.cbTermPauseRX.TabIndex = 55;
            this.cbTermPauseRX.Text = "Pause Rx";
            this.cbTermPauseRX.UseVisualStyleBackColor = true;
            // 
            // FormUDPLogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 535);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TcLogWindow);
            this.Controls.Add(this.gbSendMessage);
            this.Controls.Add(this.dgvLogWindow);
            this.Name = "FormUDPLogWindow";
            this.Text = "Log Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUDPLogWindow_FormClosing);
            this.gbSendMessage.ResumeLayout(false);
            this.gbSendMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogWindow)).EndInit();
            this.TcLogWindow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSendMessage;
        private System.Windows.Forms.Button BtnTFTPFile;
        private System.Windows.Forms.CheckBox cbClearMsgAfterSend;
        private System.Windows.Forms.TextBox TbDestIP;
        private System.Windows.Forms.Label lblDestIP;
        private System.Windows.Forms.Label lblDestPort;
        private System.Windows.Forms.TextBox TbDestPort;
        private System.Windows.Forms.TextBox TbMessage;
        private System.Windows.Forms.Button BtnSendMessage;
        private System.Windows.Forms.Button BtnDataShowAll;
        private System.Windows.Forms.Button BtnDataSearch;
        private System.Windows.Forms.TextBox TbSearchData;
        private System.Windows.Forms.DataGridView dgvLogWindow;
        private System.Windows.Forms.TabControl TcLogWindow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbTermAutoScroll;
        private System.Windows.Forms.Button btnDelSelRow;
        private System.Windows.Forms.Button btnTermReset;
        private System.Windows.Forms.Button btnTermClearAll;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton TsBtnOpen;
        private System.Windows.Forms.ToolStripButton TsBtnSaveAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbTermPauseRX;
    }
}

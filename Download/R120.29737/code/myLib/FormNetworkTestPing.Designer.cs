namespace LogTerminal
{
    partial class FormNetworkTestPing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNetworkTestPing));
            this.gbPingTest = new System.Windows.Forms.GroupBox();
            this.BtnDeveloperTest = new System.Windows.Forms.Button();
            this.lblChallengeInfo = new System.Windows.Forms.Label();
            this.cbLoopEn = new System.Windows.Forms.CheckBox();
            this.cbTestEnable = new System.Windows.Forms.CheckBox();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Challenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TsBtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.TsBtnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TsBtnEnableAll = new System.Windows.Forms.ToolStripButton();
            this.TsBtnDisableAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.TsBtnAutoFillNames = new System.Windows.Forms.ToolStripButton();
            this.TsBtnResetAllResults = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsBtnClearAllTests = new System.Windows.Forms.ToolStripButton();
            this.gbPingTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPingTest
            // 
            this.gbPingTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPingTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbPingTest.Controls.Add(this.BtnDeveloperTest);
            this.gbPingTest.Controls.Add(this.lblChallengeInfo);
            this.gbPingTest.Controls.Add(this.cbLoopEn);
            this.gbPingTest.Controls.Add(this.cbTestEnable);
            this.gbPingTest.Controls.Add(this.dgvTest);
            this.gbPingTest.Location = new System.Drawing.Point(6, 80);
            this.gbPingTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbPingTest.Name = "gbPingTest";
            this.gbPingTest.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbPingTest.Size = new System.Drawing.Size(1111, 365);
            this.gbPingTest.TabIndex = 32;
            this.gbPingTest.TabStop = false;
            this.gbPingTest.Text = "Device Ping Test";
            // 
            // BtnDeveloperTest
            // 
            this.BtnDeveloperTest.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeveloperTest.Location = new System.Drawing.Point(289, 25);
            this.BtnDeveloperTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnDeveloperTest.Name = "BtnDeveloperTest";
            this.BtnDeveloperTest.Size = new System.Drawing.Size(123, 35);
            this.BtnDeveloperTest.TabIndex = 48;
            this.BtnDeveloperTest.Text = "Developer Test";
            this.BtnDeveloperTest.Click += new System.EventHandler(this.BtnDeveloperTest_Click);
            // 
            // lblChallengeInfo
            // 
            this.lblChallengeInfo.AutoSize = true;
            this.lblChallengeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallengeInfo.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblChallengeInfo.Location = new System.Drawing.Point(7, 24);
            this.lblChallengeInfo.Name = "lblChallengeInfo";
            this.lblChallengeInfo.Size = new System.Drawing.Size(260, 20);
            this.lblChallengeInfo.TabIndex = 26;
            this.lblChallengeInfo.Text = "Send ICMP ping to specific devices.";
            // 
            // cbLoopEn
            // 
            this.cbLoopEn.AutoSize = true;
            this.cbLoopEn.Font = new System.Drawing.Font("Calibri", 8F);
            this.cbLoopEn.Location = new System.Drawing.Point(639, 31);
            this.cbLoopEn.Name = "cbLoopEn";
            this.cbLoopEn.Size = new System.Drawing.Size(66, 23);
            this.cbLoopEn.TabIndex = 25;
            this.cbLoopEn.Text = "Loop";
            this.cbLoopEn.UseVisualStyleBackColor = true;
            // 
            // cbTestEnable
            // 
            this.cbTestEnable.AutoSize = true;
            this.cbTestEnable.Font = new System.Drawing.Font("Calibri", 8F);
            this.cbTestEnable.Location = new System.Drawing.Point(721, 31);
            this.cbTestEnable.Name = "cbTestEnable";
            this.cbTestEnable.Size = new System.Drawing.Size(96, 23);
            this.cbTestEnable.TabIndex = 23;
            this.cbTestEnable.Text = "Start Test";
            this.cbTestEnable.UseVisualStyleBackColor = true;
            this.cbTestEnable.CheckedChanged += new System.EventHandler(this.CbTestEnable_CheckedChanged);
            // 
            // dgvTest
            // 
            this.dgvTest.AllowUserToResizeRows = false;
            this.dgvTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTest.ColumnHeadersHeight = 34;
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Delay,
            this.Challenge,
            this.DeviceAlias,
            this.Timeout,
            this.Fail,
            this.Pass,
            this.Reset});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTest.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvTest.Location = new System.Drawing.Point(8, 75);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.RowHeadersWidth = 62;
            this.dgvTest.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTest.RowTemplate.Height = 18;
            this.dgvTest.Size = new System.Drawing.Size(1096, 282);
            this.dgvTest.TabIndex = 22;
            // 
            // Enable
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = true;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.Enable.DefaultCellStyle = dataGridViewCellStyle10;
            this.Enable.HeaderText = "En";
            this.Enable.MinimumWidth = 50;
            this.Enable.Name = "Enable";
            this.Enable.ToolTipText = "Enable Test";
            this.Enable.Width = 50;
            // 
            // Delay
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = "0";
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.Delay.DefaultCellStyle = dataGridViewCellStyle11;
            this.Delay.HeaderText = "Delay\n(msec)";
            this.Delay.MaxInputLength = 5;
            this.Delay.MinimumWidth = 55;
            this.Delay.Name = "Delay";
            this.Delay.ToolTipText = "Delay duration before sending next challenge message (msec)";
            this.Delay.Width = 55;
            // 
            // Challenge
            // 
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.Challenge.DefaultCellStyle = dataGridViewCellStyle12;
            this.Challenge.HeaderText = "IP Address";
            this.Challenge.MinimumWidth = 8;
            this.Challenge.Name = "Challenge";
            this.Challenge.ToolTipText = "IP Address for device to ping.";
            this.Challenge.Width = 150;
            // 
            // DeviceAlias
            // 
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.DeviceAlias.DefaultCellStyle = dataGridViewCellStyle13;
            this.DeviceAlias.HeaderText = "Device Name (alias)";
            this.DeviceAlias.MinimumWidth = 8;
            this.DeviceAlias.Name = "DeviceAlias";
            this.DeviceAlias.ToolTipText = "Name of Device for Logging Purposes";
            this.DeviceAlias.Width = 200;
            // 
            // Timeout
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = "1";
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.Timeout.DefaultCellStyle = dataGridViewCellStyle14;
            this.Timeout.HeaderText = "Timeout\n(msec)";
            this.Timeout.MaxInputLength = 5;
            this.Timeout.MinimumWidth = 55;
            this.Timeout.Name = "Timeout";
            this.Timeout.ToolTipText = "Response timeout duration (msec)";
            this.Timeout.Width = 55;
            // 
            // Fail
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = "0";
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.Fail.DefaultCellStyle = dataGridViewCellStyle15;
            this.Fail.HeaderText = "Fail";
            this.Fail.MaxInputLength = 13;
            this.Fail.MinimumWidth = 8;
            this.Fail.Name = "Fail";
            this.Fail.ReadOnly = true;
            this.Fail.Width = 60;
            // 
            // Pass
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = "0";
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.Pass.DefaultCellStyle = dataGridViewCellStyle16;
            this.Pass.HeaderText = "Pass";
            this.Pass.MaxInputLength = 13;
            this.Pass.MinimumWidth = 8;
            this.Pass.Name = "Pass";
            this.Pass.ReadOnly = true;
            this.Pass.Width = 60;
            // 
            // Reset
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle17.NullValue = "Reset";
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.Reset.DefaultCellStyle = dataGridViewCellStyle17;
            this.Reset.HeaderText = "Reset";
            this.Reset.MinimumWidth = 8;
            this.Reset.Name = "Reset";
            this.Reset.Text = "Reset";
            this.Reset.Width = 60;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TsBtnOpenFile,
            this.TsBtnSaveFile,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.TsBtnEnableAll,
            this.TsBtnDisableAll,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.TsBtnAutoFillNames,
            this.TsBtnResetAllResults,
            this.toolStripSeparator3,
            this.TsBtnClearAllTests});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1130, 52);
            this.toolStrip1.TabIndex = 32;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 47);
            this.toolStripLabel1.Text = "// Control >";
            // 
            // TsBtnOpenFile
            // 
            this.TsBtnOpenFile.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TsBtnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnOpenFile.Image")));
            this.TsBtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnOpenFile.Name = "TsBtnOpenFile";
            this.TsBtnOpenFile.Size = new System.Drawing.Size(48, 47);
            this.TsBtnOpenFile.Text = "Open";
            this.TsBtnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnOpenFile.Click += new System.EventHandler(this.TsBtnOpenFile_Click);
            // 
            // TsBtnSaveFile
            // 
            this.TsBtnSaveFile.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnSaveFile.Image")));
            this.TsBtnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnSaveFile.Name = "TsBtnSaveFile";
            this.TsBtnSaveFile.Size = new System.Drawing.Size(63, 47);
            this.TsBtnSaveFile.Text = "Save As";
            this.TsBtnSaveFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnSaveFile.Click += new System.EventHandler(this.TsBtnSaveFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(136, 47);
            this.toolStripLabel2.Text = "// Test Sequence >";
            // 
            // TsBtnEnableAll
            // 
            this.TsBtnEnableAll.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnEnableAll.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnEnableAll.Image")));
            this.TsBtnEnableAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnEnableAll.Name = "TsBtnEnableAll";
            this.TsBtnEnableAll.Size = new System.Drawing.Size(78, 47);
            this.TsBtnEnableAll.Text = "Enable All";
            this.TsBtnEnableAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnEnableAll.Click += new System.EventHandler(this.TsBtnEnableAll_Click);
            // 
            // TsBtnDisableAll
            // 
            this.TsBtnDisableAll.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnDisableAll.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnDisableAll.Image")));
            this.TsBtnDisableAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnDisableAll.Name = "TsBtnDisableAll";
            this.TsBtnDisableAll.Size = new System.Drawing.Size(83, 47);
            this.TsBtnDisableAll.Text = "Disable All";
            this.TsBtnDisableAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnDisableAll.Click += new System.EventHandler(this.TsBtnDisableAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(66, 47);
            this.toolStripLabel3.Text = "// Test >";
            // 
            // TsBtnAutoFillNames
            // 
            this.TsBtnAutoFillNames.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnAutoFillNames.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnAutoFillNames.Image")));
            this.TsBtnAutoFillNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnAutoFillNames.Name = "TsBtnAutoFillNames";
            this.TsBtnAutoFillNames.Size = new System.Drawing.Size(159, 47);
            this.TsBtnAutoFillNames.Text = "AutoFill Device Names";
            this.TsBtnAutoFillNames.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnAutoFillNames.Click += new System.EventHandler(this.TsBtnAutoFillNames_Click);
            // 
            // TsBtnResetAllResults
            // 
            this.TsBtnResetAllResults.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnResetAllResults.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnResetAllResults.Image")));
            this.TsBtnResetAllResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnResetAllResults.Name = "TsBtnResetAllResults";
            this.TsBtnResetAllResults.Size = new System.Drawing.Size(123, 47);
            this.TsBtnResetAllResults.Text = "Reset All Results";
            this.TsBtnResetAllResults.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnResetAllResults.Click += new System.EventHandler(this.TsBtnResetAllResults_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // TsBtnClearAllTests
            // 
            this.TsBtnClearAllTests.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnClearAllTests.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnClearAllTests.Image")));
            this.TsBtnClearAllTests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnClearAllTests.Name = "TsBtnClearAllTests";
            this.TsBtnClearAllTests.Size = new System.Drawing.Size(106, 47);
            this.TsBtnClearAllTests.Text = "Clear All Tests";
            this.TsBtnClearAllTests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnClearAllTests.Click += new System.EventHandler(this.TsBtnClearAllTests_Click);
            // 
            // FormNetworkTestPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbPingTest);
            this.Name = "FormNetworkTestPing";
            this.Text = "Device Ping Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNetworkTestPing_FormClosing);
            this.gbPingTest.ResumeLayout(false);
            this.gbPingTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPingTest;
        private System.Windows.Forms.Label lblChallengeInfo;
        private System.Windows.Forms.CheckBox cbLoopEn;
        private System.Windows.Forms.CheckBox cbTestEnable;
        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsBtnOpenFile;
        private System.Windows.Forms.ToolStripButton TsBtnSaveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TsBtnEnableAll;
        private System.Windows.Forms.ToolStripButton TsBtnDisableAll;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton TsBtnResetAllResults;
        private System.Windows.Forms.ToolStripButton TsBtnClearAllTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button BtnDeveloperTest;
        private System.Windows.Forms.ToolStripButton TsBtnAutoFillNames;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Challenge;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timeout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewButtonColumn Reset;
    }
}

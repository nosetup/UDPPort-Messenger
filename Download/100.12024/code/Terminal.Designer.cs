namespace LogTerminal
{
  partial class FrmTerminal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTerminal));
            this.btnTermClearAll = new System.Windows.Forms.Button();
            this.gbTerminal = new System.Windows.Forms.GroupBox();
            this.BtnAnalyzeHexDataShowAll = new System.Windows.Forms.Button();
            this.BtnAnalyzeHexDataSearch = new System.Windows.Forms.Button();
            this.TbAnalyzeHexData = new System.Windows.Forms.TextBox();
            this.cbTermAutoScroll = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnScanNetwork = new System.Windows.Forms.Button();
            this.timerScript = new System.Windows.Forms.Timer(this.components);
            this.dgvLogWindow = new System.Windows.Forms.DataGridView();
            this.btnDelSelRow = new System.Windows.Forms.Button();
            this.gbAutomate = new System.Windows.Forms.GroupBox();
            this.gbScripting = new System.Windows.Forms.GroupBox();
            this.cbScriptEnable = new System.Windows.Forms.CheckBox();
            this.dgvScripting = new System.Windows.Forms.DataGridView();
            this.cbScriptLoop = new System.Windows.Forms.CheckBox();
            this.gbAutoReply = new System.Windows.Forms.GroupBox();
            this.cbAutoReplyEnable = new System.Windows.Forms.CheckBox();
            this.dgvAutoReply = new System.Windows.Forms.DataGridView();
            this.btnTermReset = new System.Windows.Forms.Button();
            this.timerAutoReply = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MenuStripTerminal = new System.Windows.Forms.MenuStrip();
            this.TsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiFileLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiFLogsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiFLogsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAutomate = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAutomateScripting = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAScriptOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiAScriptSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAutomateAutoReply = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAAutoReplyOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiAAutoReplySaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiControl = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiControlCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiCCustomTVControls = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ethernetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLogWindow = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripButtons = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnLogOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLogSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnTVControls = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.TbDestIP = new System.Windows.Forms.TextBox();
            this.lblDestIP = new System.Windows.Forms.Label();
            this.lblNIC = new System.Windows.Forms.Label();
            this.BtnSendMessage = new System.Windows.Forms.Button();
            this.TbMessage = new System.Windows.Forms.TextBox();
            this.TbSrcIP = new System.Windows.Forms.TextBox();
            this.lblSrcIP = new System.Windows.Forms.Label();
            this.BtnUDPConnect = new System.Windows.Forms.Button();
            this.TbSrcPort = new System.Windows.Forms.TextBox();
            this.lblSrcPort = new System.Windows.Forms.Label();
            this.TbDestPort = new System.Windows.Forms.TextBox();
            this.lblDestPort = new System.Windows.Forms.Label();
            this.BtnUDPDisconnect = new System.Windows.Forms.Button();
            this.BtnRefreshAdapters = new System.Windows.Forms.Button();
            this.cmbAdapterName = new System.Windows.Forms.ComboBox();
            this.cmbNetworkDevices = new System.Windows.Forms.ComboBox();
            this.BtnQuickScan = new System.Windows.Forms.Button();
            this.gbSendMessage = new System.Windows.Forms.GroupBox();
            this.BtnTFTPFile = new System.Windows.Forms.Button();
            this.cbClearMsgAfterSend = new System.Windows.Forms.CheckBox();
            this.gbNetworkUtil = new System.Windows.Forms.GroupBox();
            this.BtnHostInfo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbTerminal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogWindow)).BeginInit();
            this.gbAutomate.SuspendLayout();
            this.gbScripting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripting)).BeginInit();
            this.gbAutoReply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutoReply)).BeginInit();
            this.MenuStripTerminal.SuspendLayout();
            this.gbLogWindow.SuspendLayout();
            this.ToolStripButtons.SuspendLayout();
            this.gbSendMessage.SuspendLayout();
            this.gbNetworkUtil.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTermClearAll
            // 
            this.btnTermClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTermClearAll.Location = new System.Drawing.Point(182, 25);
            this.btnTermClearAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTermClearAll.Name = "btnTermClearAll";
            this.btnTermClearAll.Size = new System.Drawing.Size(112, 35);
            this.btnTermClearAll.TabIndex = 7;
            this.btnTermClearAll.Text = "Clear All";
            this.btnTermClearAll.Click += new System.EventHandler(this.BtnTermClearAll_Click);
            // 
            // gbTerminal
            // 
            this.gbTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTerminal.Controls.Add(this.BtnAnalyzeHexDataShowAll);
            this.gbTerminal.Controls.Add(this.BtnAnalyzeHexDataSearch);
            this.gbTerminal.Controls.Add(this.TbAnalyzeHexData);
            this.gbTerminal.Location = new System.Drawing.Point(609, 360);
            this.gbTerminal.Name = "gbTerminal";
            this.gbTerminal.Size = new System.Drawing.Size(422, 65);
            this.gbTerminal.TabIndex = 10;
            this.gbTerminal.TabStop = false;
            this.gbTerminal.Text = "Search Message";
            // 
            // BtnAnalyzeHexDataShowAll
            // 
            this.BtnAnalyzeHexDataShowAll.Location = new System.Drawing.Point(308, 25);
            this.BtnAnalyzeHexDataShowAll.Name = "BtnAnalyzeHexDataShowAll";
            this.BtnAnalyzeHexDataShowAll.Size = new System.Drawing.Size(98, 32);
            this.BtnAnalyzeHexDataShowAll.TabIndex = 18;
            this.BtnAnalyzeHexDataShowAll.Text = "Show All";
            this.BtnAnalyzeHexDataShowAll.UseVisualStyleBackColor = true;
            this.BtnAnalyzeHexDataShowAll.Click += new System.EventHandler(this.BtnAnalyzeHexDataShowAll_Click);
            // 
            // BtnAnalyzeHexDataSearch
            // 
            this.BtnAnalyzeHexDataSearch.Location = new System.Drawing.Point(204, 25);
            this.BtnAnalyzeHexDataSearch.Name = "BtnAnalyzeHexDataSearch";
            this.BtnAnalyzeHexDataSearch.Size = new System.Drawing.Size(98, 32);
            this.BtnAnalyzeHexDataSearch.TabIndex = 7;
            this.BtnAnalyzeHexDataSearch.Text = "Search";
            this.BtnAnalyzeHexDataSearch.UseVisualStyleBackColor = true;
            this.BtnAnalyzeHexDataSearch.Click += new System.EventHandler(this.BtnAnalyzeHexDataSearch_Click);
            // 
            // TbAnalyzeHexData
            // 
            this.TbAnalyzeHexData.Location = new System.Drawing.Point(12, 28);
            this.TbAnalyzeHexData.MaxLength = 30;
            this.TbAnalyzeHexData.Name = "TbAnalyzeHexData";
            this.TbAnalyzeHexData.Size = new System.Drawing.Size(187, 26);
            this.TbAnalyzeHexData.TabIndex = 15;
            this.TbAnalyzeHexData.Text = "Keyword";
            // 
            // cbTermAutoScroll
            // 
            this.cbTermAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTermAutoScroll.AutoSize = true;
            this.cbTermAutoScroll.Checked = true;
            this.cbTermAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermAutoScroll.Location = new System.Drawing.Point(454, 29);
            this.cbTermAutoScroll.Name = "cbTermAutoScroll";
            this.cbTermAutoScroll.Size = new System.Drawing.Size(108, 24);
            this.cbTermAutoScroll.TabIndex = 19;
            this.cbTermAutoScroll.Text = "AutoScroll";
            this.cbTermAutoScroll.UseVisualStyleBackColor = true;
            // 
            // BtnScanNetwork
            // 
            this.BtnScanNetwork.Location = new System.Drawing.Point(593, 20);
            this.BtnScanNetwork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnScanNetwork.Name = "BtnScanNetwork";
            this.BtnScanNetwork.Size = new System.Drawing.Size(106, 35);
            this.BtnScanNetwork.TabIndex = 44;
            this.BtnScanNetwork.Text = "Slow Scan";
            this.toolTip1.SetToolTip(this.BtnScanNetwork, "Warning : Operation takes approx 2 mins");
            this.BtnScanNetwork.Click += new System.EventHandler(this.BtnSlowScan_Click);
            // 
            // timerScript
            // 
            this.timerScript.Interval = 1000;
            this.timerScript.Tick += new System.EventHandler(this.TimerScript_Tick);
            // 
            // dgvLogWindow
            // 
            this.dgvLogWindow.AllowUserToAddRows = false;
            this.dgvLogWindow.AllowUserToDeleteRows = false;
            this.dgvLogWindow.AllowUserToResizeRows = false;
            this.dgvLogWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.dgvLogWindow.Location = new System.Drawing.Point(4, 254);
            this.dgvLogWindow.MinimumSize = new System.Drawing.Size(1240, 100);
            this.dgvLogWindow.Name = "dgvLogWindow";
            this.dgvLogWindow.RowHeadersWidth = 62;
            this.dgvLogWindow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLogWindow.RowTemplate.Height = 18;
            this.dgvLogWindow.RowTemplate.ReadOnly = true;
            this.dgvLogWindow.Size = new System.Drawing.Size(1274, 100);
            this.dgvLogWindow.TabIndex = 14;
            // 
            // btnDelSelRow
            // 
            this.btnDelSelRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelSelRow.Location = new System.Drawing.Point(6, 23);
            this.btnDelSelRow.Name = "btnDelSelRow";
            this.btnDelSelRow.Size = new System.Drawing.Size(165, 35);
            this.btnDelSelRow.TabIndex = 18;
            this.btnDelSelRow.Text = "Clear Selected";
            this.btnDelSelRow.Click += new System.EventHandler(this.BtnDelSelRow_Click);
            // 
            // gbAutomate
            // 
            this.gbAutomate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbAutomate.Controls.Add(this.gbScripting);
            this.gbAutomate.Controls.Add(this.gbAutoReply);
            this.gbAutomate.Location = new System.Drawing.Point(3, 425);
            this.gbAutomate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAutomate.Name = "gbAutomate";
            this.gbAutomate.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAutomate.Size = new System.Drawing.Size(1275, 249);
            this.gbAutomate.TabIndex = 15;
            this.gbAutomate.TabStop = false;
            this.gbAutomate.Text = "Automate";
            // 
            // gbScripting
            // 
            this.gbScripting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScripting.Controls.Add(this.cbScriptEnable);
            this.gbScripting.Controls.Add(this.dgvScripting);
            this.gbScripting.Controls.Add(this.cbScriptLoop);
            this.gbScripting.Location = new System.Drawing.Point(9, 22);
            this.gbScripting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScripting.Name = "gbScripting";
            this.gbScripting.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScripting.Size = new System.Drawing.Size(519, 211);
            this.gbScripting.TabIndex = 17;
            this.gbScripting.TabStop = false;
            this.gbScripting.Text = "Scripting";
            // 
            // cbScriptEnable
            // 
            this.cbScriptEnable.AutoSize = true;
            this.cbScriptEnable.Location = new System.Drawing.Point(369, 12);
            this.cbScriptEnable.Name = "cbScriptEnable";
            this.cbScriptEnable.Size = new System.Drawing.Size(85, 24);
            this.cbScriptEnable.TabIndex = 22;
            this.cbScriptEnable.Text = "Enable";
            this.cbScriptEnable.UseVisualStyleBackColor = true;
            this.cbScriptEnable.CheckedChanged += new System.EventHandler(this.CbScriptEnable_CheckedChanged);
            // 
            // dgvScripting
            // 
            this.dgvScripting.AllowUserToResizeColumns = false;
            this.dgvScripting.AllowUserToResizeRows = false;
            this.dgvScripting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScripting.ColumnHeadersHeight = 34;
            this.dgvScripting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScripting.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScripting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvScripting.Location = new System.Drawing.Point(3, 45);
            this.dgvScripting.Name = "dgvScripting";
            this.dgvScripting.RowHeadersWidth = 62;
            this.dgvScripting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvScripting.RowTemplate.Height = 18;
            this.dgvScripting.Size = new System.Drawing.Size(507, 158);
            this.dgvScripting.TabIndex = 21;
            // 
            // cbScriptLoop
            // 
            this.cbScriptLoop.AutoSize = true;
            this.cbScriptLoop.Location = new System.Drawing.Point(288, 12);
            this.cbScriptLoop.Name = "cbScriptLoop";
            this.cbScriptLoop.Size = new System.Drawing.Size(71, 24);
            this.cbScriptLoop.TabIndex = 20;
            this.cbScriptLoop.Text = "Loop";
            this.cbScriptLoop.UseVisualStyleBackColor = true;
            // 
            // gbAutoReply
            // 
            this.gbAutoReply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAutoReply.Controls.Add(this.cbAutoReplyEnable);
            this.gbAutoReply.Controls.Add(this.dgvAutoReply);
            this.gbAutoReply.Location = new System.Drawing.Point(536, 22);
            this.gbAutoReply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAutoReply.Name = "gbAutoReply";
            this.gbAutoReply.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAutoReply.Size = new System.Drawing.Size(730, 211);
            this.gbAutoReply.TabIndex = 16;
            this.gbAutoReply.TabStop = false;
            this.gbAutoReply.Text = "Auto Reply";
            // 
            // cbAutoReplyEnable
            // 
            this.cbAutoReplyEnable.AutoSize = true;
            this.cbAutoReplyEnable.Location = new System.Drawing.Point(598, 12);
            this.cbAutoReplyEnable.Name = "cbAutoReplyEnable";
            this.cbAutoReplyEnable.Size = new System.Drawing.Size(85, 24);
            this.cbAutoReplyEnable.TabIndex = 23;
            this.cbAutoReplyEnable.Text = "Enable";
            this.cbAutoReplyEnable.UseVisualStyleBackColor = true;
            this.cbAutoReplyEnable.CheckedChanged += new System.EventHandler(this.CbAutoReplyEnable_CheckedChanged);
            // 
            // dgvAutoReply
            // 
            this.dgvAutoReply.AllowUserToResizeRows = false;
            this.dgvAutoReply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAutoReply.ColumnHeadersHeight = 34;
            this.dgvAutoReply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAutoReply.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAutoReply.Location = new System.Drawing.Point(8, 45);
            this.dgvAutoReply.Name = "dgvAutoReply";
            this.dgvAutoReply.RowHeadersWidth = 62;
            this.dgvAutoReply.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAutoReply.RowTemplate.Height = 18;
            this.dgvAutoReply.Size = new System.Drawing.Size(716, 158);
            this.dgvAutoReply.TabIndex = 22;
            // 
            // btnTermReset
            // 
            this.btnTermReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTermReset.Location = new System.Drawing.Point(306, 25);
            this.btnTermReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTermReset.Name = "btnTermReset";
            this.btnTermReset.Size = new System.Drawing.Size(112, 35);
            this.btnTermReset.TabIndex = 19;
            this.btnTermReset.Text = "Reset";
            this.btnTermReset.Click += new System.EventHandler(this.BtnTermReset_Click);
            // 
            // timerAutoReply
            // 
            this.timerAutoReply.Interval = 1000;
            // 
            // MenuStripTerminal
            // 
            this.MenuStripTerminal.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStripTerminal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStripTerminal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiFile,
            this.TsmiConnections,
            this.TsmiAutomate,
            this.TsmiControl,
            this.TsmiHelp});
            this.MenuStripTerminal.Location = new System.Drawing.Point(0, 0);
            this.MenuStripTerminal.Name = "MenuStripTerminal";
            this.MenuStripTerminal.Size = new System.Drawing.Size(1284, 33);
            this.MenuStripTerminal.TabIndex = 22;
            this.MenuStripTerminal.Text = "menuStripTerminal";
            // 
            // TsmiFile
            // 
            this.TsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.TsmiFileLogs,
            this.toolStripSeparator2,
            this.TsmiFileExit});
            this.TsmiFile.Name = "TsmiFile";
            this.TsmiFile.Size = new System.Drawing.Size(54, 29);
            this.TsmiFile.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // TsmiFileLogs
            // 
            this.TsmiFileLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiFLogsOpen,
            this.TsmiFLogsSaveAs});
            this.TsmiFileLogs.Name = "TsmiFileLogs";
            this.TsmiFileLogs.Size = new System.Drawing.Size(152, 34);
            this.TsmiFileLogs.Text = "Logs";
            this.TsmiFileLogs.Click += new System.EventHandler(this.TsmiFileLogs_Click);
            // 
            // TsmiFLogsOpen
            // 
            this.TsmiFLogsOpen.Name = "TsmiFLogsOpen";
            this.TsmiFLogsOpen.Size = new System.Drawing.Size(176, 34);
            this.TsmiFLogsOpen.Text = "Open";
            this.TsmiFLogsOpen.Click += new System.EventHandler(this.TsmLogsOpen_Click);
            // 
            // TsmiFLogsSaveAs
            // 
            this.TsmiFLogsSaveAs.Name = "TsmiFLogsSaveAs";
            this.TsmiFLogsSaveAs.Size = new System.Drawing.Size(176, 34);
            this.TsmiFLogsSaveAs.Text = "Save As";
            this.TsmiFLogsSaveAs.Click += new System.EventHandler(this.TsmLogsSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // TsmiFileExit
            // 
            this.TsmiFileExit.Name = "TsmiFileExit";
            this.TsmiFileExit.Size = new System.Drawing.Size(152, 34);
            this.TsmiFileExit.Text = "Exit";
            this.TsmiFileExit.Click += new System.EventHandler(this.TsmiFileExit_Click);
            // 
            // TsmiConnections
            // 
            this.TsmiConnections.Name = "TsmiConnections";
            this.TsmiConnections.Size = new System.Drawing.Size(126, 29);
            this.TsmiConnections.Text = "Connections";
            this.TsmiConnections.Visible = false;
            // 
            // TsmiAutomate
            // 
            this.TsmiAutomate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiAutomateScripting,
            this.TsmiAutomateAutoReply});
            this.TsmiAutomate.Name = "TsmiAutomate";
            this.TsmiAutomate.Size = new System.Drawing.Size(107, 29);
            this.TsmiAutomate.Text = "Automate";
            this.TsmiAutomate.Visible = false;
            // 
            // TsmiAutomateScripting
            // 
            this.TsmiAutomateScripting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiAScriptOpen,
            this.toolStripSeparator4,
            this.TsmiAScriptSaveAs});
            this.TsmiAutomateScripting.Name = "TsmiAutomateScripting";
            this.TsmiAutomateScripting.Size = new System.Drawing.Size(201, 34);
            this.TsmiAutomateScripting.Text = "Scripting";
            // 
            // TsmiAScriptOpen
            // 
            this.TsmiAScriptOpen.Name = "TsmiAScriptOpen";
            this.TsmiAScriptOpen.Size = new System.Drawing.Size(208, 34);
            this.TsmiAScriptOpen.Text = "Open Script";
            this.TsmiAScriptOpen.Click += new System.EventHandler(this.TsmScriptOpen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // TsmiAScriptSaveAs
            // 
            this.TsmiAScriptSaveAs.Name = "TsmiAScriptSaveAs";
            this.TsmiAScriptSaveAs.Size = new System.Drawing.Size(208, 34);
            this.TsmiAScriptSaveAs.Text = "Save As";
            this.TsmiAScriptSaveAs.Click += new System.EventHandler(this.TsmScriptSaveAs_Click);
            // 
            // TsmiAutomateAutoReply
            // 
            this.TsmiAutomateAutoReply.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiAAutoReplyOpen,
            this.toolStripSeparator3,
            this.TsmiAAutoReplySaveAs});
            this.TsmiAutomateAutoReply.Name = "TsmiAutomateAutoReply";
            this.TsmiAutomateAutoReply.Size = new System.Drawing.Size(201, 34);
            this.TsmiAutomateAutoReply.Text = "Auto Reply";
            // 
            // TsmiAAutoReplyOpen
            // 
            this.TsmiAAutoReplyOpen.Name = "TsmiAAutoReplyOpen";
            this.TsmiAAutoReplyOpen.Size = new System.Drawing.Size(250, 34);
            this.TsmiAAutoReplyOpen.Text = "Open Auto Reply";
            this.TsmiAAutoReplyOpen.Click += new System.EventHandler(this.TsmAutoReplyOpen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(247, 6);
            // 
            // TsmiAAutoReplySaveAs
            // 
            this.TsmiAAutoReplySaveAs.Name = "TsmiAAutoReplySaveAs";
            this.TsmiAAutoReplySaveAs.Size = new System.Drawing.Size(250, 34);
            this.TsmiAAutoReplySaveAs.Text = "Save As";
            this.TsmiAAutoReplySaveAs.Click += new System.EventHandler(this.TsmAutoReplySaveAs_Click);
            // 
            // TsmiControl
            // 
            this.TsmiControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiControlCustom});
            this.TsmiControl.Name = "TsmiControl";
            this.TsmiControl.Size = new System.Drawing.Size(87, 29);
            this.TsmiControl.Text = "Control";
            this.TsmiControl.Visible = false;
            // 
            // TsmiControlCustom
            // 
            this.TsmiControlCustom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiCCustomTVControls});
            this.TsmiControlCustom.Name = "TsmiControlCustom";
            this.TsmiControlCustom.Size = new System.Drawing.Size(176, 34);
            this.TsmiControlCustom.Text = "Custom";
            // 
            // TsmiCCustomTVControls
            // 
            this.TsmiCCustomTVControls.Name = "TsmiCCustomTVControls";
            this.TsmiCCustomTVControls.Size = new System.Drawing.Size(206, 34);
            this.TsmiCCustomTVControls.Text = "TV Controls";
            this.TsmiCCustomTVControls.Click += new System.EventHandler(this.TsmTVControls_Click);
            // 
            // TsmiHelp
            // 
            this.TsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiHelpAbout});
            this.TsmiHelp.Name = "TsmiHelp";
            this.TsmiHelp.Size = new System.Drawing.Size(65, 29);
            this.TsmiHelp.Text = "Help";
            // 
            // TsmiHelpAbout
            // 
            this.TsmiHelpAbout.Name = "TsmiHelpAbout";
            this.TsmiHelpAbout.Size = new System.Drawing.Size(164, 34);
            this.TsmiHelpAbout.Text = "About";
            this.TsmiHelpAbout.Click += new System.EventHandler(this.TsmiAbout_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(267, 6);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.connectToolStripMenuItem1,
            this.disconnectToolStripMenuItem1});
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.serialToolStripMenuItem.Text = "Serial";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(201, 34);
            this.settingsToolStripMenuItem1.Text = "Settings";
            // 
            // connectToolStripMenuItem1
            // 
            this.connectToolStripMenuItem1.Name = "connectToolStripMenuItem1";
            this.connectToolStripMenuItem1.Size = new System.Drawing.Size(201, 34);
            this.connectToolStripMenuItem1.Text = "Connect";
            // 
            // disconnectToolStripMenuItem1
            // 
            this.disconnectToolStripMenuItem1.Name = "disconnectToolStripMenuItem1";
            this.disconnectToolStripMenuItem1.Size = new System.Drawing.Size(201, 34);
            this.disconnectToolStripMenuItem1.Text = "Disconnect";
            // 
            // ethernetToolStripMenuItem
            // 
            this.ethernetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.ethernetToolStripMenuItem.Name = "ethernetToolStripMenuItem";
            this.ethernetToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ethernetToolStripMenuItem.Text = "Ethernet";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // gbLogWindow
            // 
            this.gbLogWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLogWindow.Controls.Add(this.cbTermAutoScroll);
            this.gbLogWindow.Controls.Add(this.btnDelSelRow);
            this.gbLogWindow.Controls.Add(this.btnTermClearAll);
            this.gbLogWindow.Controls.Add(this.btnTermReset);
            this.gbLogWindow.Location = new System.Drawing.Point(4, 360);
            this.gbLogWindow.Name = "gbLogWindow";
            this.gbLogWindow.Size = new System.Drawing.Size(594, 65);
            this.gbLogWindow.TabIndex = 23;
            this.gbLogWindow.TabStop = false;
            this.gbLogWindow.Text = "Log Window";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 680);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToolStripButtons
            // 
            this.ToolStripButtons.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStripButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tsbtnLogOpen,
            this.tsbtnLogSaveAs,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.tsbtnConnect,
            this.tsbtnDisconnect,
            this.toolStripSeparator7,
            this.toolStripLabel2,
            this.tsbtnTVControls,
            this.toolStripButton4});
            this.ToolStripButtons.Location = new System.Drawing.Point(0, 33);
            this.ToolStripButtons.Name = "ToolStripButtons";
            this.ToolStripButtons.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ToolStripButtons.Size = new System.Drawing.Size(1284, 33);
            this.ToolStripButtons.TabIndex = 25;
            this.ToolStripButtons.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(50, 28);
            this.toolStripLabel3.Text = "Logs";
            // 
            // tsbtnLogOpen
            // 
            this.tsbtnLogOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLogOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLogOpen.Image")));
            this.tsbtnLogOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogOpen.Name = "tsbtnLogOpen";
            this.tsbtnLogOpen.Size = new System.Drawing.Size(34, 28);
            this.tsbtnLogOpen.Text = "Open";
            this.tsbtnLogOpen.Click += new System.EventHandler(this.TsbtnLogOpen_Click);
            // 
            // tsbtnLogSaveAs
            // 
            this.tsbtnLogSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLogSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLogSaveAs.Image")));
            this.tsbtnLogSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogSaveAs.Name = "tsbtnLogSaveAs";
            this.tsbtnLogSaveAs.Size = new System.Drawing.Size(34, 28);
            this.tsbtnLogSaveAs.Text = "Save As";
            this.tsbtnLogSaveAs.Click += new System.EventHandler(this.TsbtnLogSaveAs_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 28);
            this.toolStripLabel1.Text = "Serial Port";
            this.toolStripLabel1.Visible = false;
            // 
            // tsbtnConnect
            // 
            this.tsbtnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConnect.Image")));
            this.tsbtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnect.Name = "tsbtnConnect";
            this.tsbtnConnect.Size = new System.Drawing.Size(34, 28);
            this.tsbtnConnect.Text = "Connect";
            this.tsbtnConnect.Visible = false;
            this.tsbtnConnect.Click += new System.EventHandler(this.TsbtnConnect_Click);
            // 
            // tsbtnDisconnect
            // 
            this.tsbtnDisconnect.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnDisconnect.Checked = true;
            this.tsbtnDisconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDisconnect.Image")));
            this.tsbtnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDisconnect.Name = "tsbtnDisconnect";
            this.tsbtnDisconnect.Size = new System.Drawing.Size(34, 28);
            this.tsbtnDisconnect.Text = "Disconnect";
            this.tsbtnDisconnect.Visible = false;
            this.tsbtnDisconnect.Click += new System.EventHandler(this.TsbtnDisconnect_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(128, 28);
            this.toolStripLabel2.Text = "Show Controls";
            this.toolStripLabel2.Visible = false;
            // 
            // tsbtnTVControls
            // 
            this.tsbtnTVControls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTVControls.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTVControls.Image")));
            this.tsbtnTVControls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTVControls.Name = "tsbtnTVControls";
            this.tsbtnTVControls.Size = new System.Drawing.Size(34, 28);
            this.tsbtnTVControls.Text = "Show TV Controls";
            this.tsbtnTVControls.Visible = false;
            this.tsbtnTVControls.Click += new System.EventHandler(this.TsbtnTVControls_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton4.Text = "RSLK Robot";
            this.toolStripButton4.Visible = false;
            // 
            // TbDestIP
            // 
            this.TbDestIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbDestIP.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDestIP.Location = new System.Drawing.Point(81, 20);
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
            this.lblDestIP.Location = new System.Drawing.Point(11, 26);
            this.lblDestIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestIP.Name = "lblDestIP";
            this.lblDestIP.Size = new System.Drawing.Size(62, 20);
            this.lblDestIP.TabIndex = 35;
            this.lblDestIP.Text = "Dest IP";
            // 
            // lblNIC
            // 
            this.lblNIC.AutoSize = true;
            this.lblNIC.Location = new System.Drawing.Point(51, 26);
            this.lblNIC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNIC.Name = "lblNIC";
            this.lblNIC.Size = new System.Drawing.Size(36, 20);
            this.lblNIC.TabIndex = 33;
            this.lblNIC.Text = "NIC";
            // 
            // BtnSendMessage
            // 
            this.BtnSendMessage.Location = new System.Drawing.Point(402, 77);
            this.BtnSendMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSendMessage.Name = "BtnSendMessage";
            this.BtnSendMessage.Size = new System.Drawing.Size(82, 35);
            this.BtnSendMessage.TabIndex = 32;
            this.BtnSendMessage.Text = "Send";
            this.BtnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // TbMessage
            // 
            this.TbMessage.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMessage.Location = new System.Drawing.Point(15, 80);
            this.TbMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbMessage.MaxLength = 40;
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.Size = new System.Drawing.Size(379, 26);
            this.TbMessage.TabIndex = 31;
            // 
            // TbSrcIP
            // 
            this.TbSrcIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbSrcIP.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSrcIP.Location = new System.Drawing.Point(104, 60);
            this.TbSrcIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbSrcIP.MaxLength = 30;
            this.TbSrcIP.Name = "TbSrcIP";
            this.TbSrcIP.ReadOnly = true;
            this.TbSrcIP.Size = new System.Drawing.Size(116, 26);
            this.TbSrcIP.TabIndex = 30;
            // 
            // lblSrcIP
            // 
            this.lblSrcIP.AutoSize = true;
            this.lblSrcIP.Location = new System.Drawing.Point(8, 61);
            this.lblSrcIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSrcIP.Name = "lblSrcIP";
            this.lblSrcIP.Size = new System.Drawing.Size(79, 20);
            this.lblSrcIP.TabIndex = 29;
            this.lblSrcIP.Text = "Source IP";
            // 
            // BtnUDPConnect
            // 
            this.BtnUDPConnect.Location = new System.Drawing.Point(479, 57);
            this.BtnUDPConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnUDPConnect.Name = "BtnUDPConnect";
            this.BtnUDPConnect.Size = new System.Drawing.Size(106, 35);
            this.BtnUDPConnect.TabIndex = 28;
            this.BtnUDPConnect.Text = "Connect";
            this.BtnUDPConnect.Click += new System.EventHandler(this.BtnUDPConnect_Click);
            // 
            // TbSrcPort
            // 
            this.TbSrcPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbSrcPort.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSrcPort.Location = new System.Drawing.Point(283, 60);
            this.TbSrcPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbSrcPort.MaxLength = 30;
            this.TbSrcPort.Name = "TbSrcPort";
            this.TbSrcPort.Size = new System.Drawing.Size(67, 26);
            this.TbSrcPort.TabIndex = 27;
            this.TbSrcPort.Text = "12345";
            // 
            // lblSrcPort
            // 
            this.lblSrcPort.AutoSize = true;
            this.lblSrcPort.Location = new System.Drawing.Point(237, 61);
            this.lblSrcPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSrcPort.Name = "lblSrcPort";
            this.lblSrcPort.Size = new System.Drawing.Size(38, 20);
            this.lblSrcPort.TabIndex = 26;
            this.lblSrcPort.Text = "Port";
            // 
            // TbDestPort
            // 
            this.TbDestPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbDestPort.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDestPort.Location = new System.Drawing.Point(280, 22);
            this.TbDestPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbDestPort.MaxLength = 30;
            this.TbDestPort.Name = "TbDestPort";
            this.TbDestPort.Size = new System.Drawing.Size(114, 26);
            this.TbDestPort.TabIndex = 40;
            this.TbDestPort.Text = "12345";
            // 
            // lblDestPort
            // 
            this.lblDestPort.AutoSize = true;
            this.lblDestPort.Location = new System.Drawing.Point(226, 26);
            this.lblDestPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestPort.Name = "lblDestPort";
            this.lblDestPort.Size = new System.Drawing.Size(38, 20);
            this.lblDestPort.TabIndex = 39;
            this.lblDestPort.Text = "Port";
            // 
            // BtnUDPDisconnect
            // 
            this.BtnUDPDisconnect.Location = new System.Drawing.Point(593, 57);
            this.BtnUDPDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnUDPDisconnect.Name = "BtnUDPDisconnect";
            this.BtnUDPDisconnect.Size = new System.Drawing.Size(106, 35);
            this.BtnUDPDisconnect.TabIndex = 41;
            this.BtnUDPDisconnect.Text = "Disconnect";
            this.BtnUDPDisconnect.Click += new System.EventHandler(this.BtnUDPDisconnect_Click);
            // 
            // BtnRefreshAdapters
            // 
            this.BtnRefreshAdapters.Location = new System.Drawing.Point(365, 57);
            this.BtnRefreshAdapters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRefreshAdapters.Name = "BtnRefreshAdapters";
            this.BtnRefreshAdapters.Size = new System.Drawing.Size(106, 35);
            this.BtnRefreshAdapters.TabIndex = 42;
            this.BtnRefreshAdapters.Text = "Refresh";
            this.BtnRefreshAdapters.Visible = false;
            this.BtnRefreshAdapters.Click += new System.EventHandler(this.BtnRefreshAdapters_Click);
            // 
            // cmbAdapterName
            // 
            this.cmbAdapterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdapterName.FormattingEnabled = true;
            this.cmbAdapterName.Location = new System.Drawing.Point(104, 20);
            this.cmbAdapterName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAdapterName.Name = "cmbAdapterName";
            this.cmbAdapterName.Size = new System.Drawing.Size(595, 28);
            this.cmbAdapterName.TabIndex = 43;
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
            this.BtnQuickScan.Location = new System.Drawing.Point(365, 20);
            this.BtnQuickScan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnQuickScan.Name = "BtnQuickScan";
            this.BtnQuickScan.Size = new System.Drawing.Size(106, 35);
            this.BtnQuickScan.TabIndex = 46;
            this.BtnQuickScan.Text = "Quick Scan";
            this.BtnQuickScan.Click += new System.EventHandler(this.BtnQuickScan_Click);
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
            this.gbSendMessage.Location = new System.Drawing.Point(745, 90);
            this.gbSendMessage.Name = "gbSendMessage";
            this.gbSendMessage.Size = new System.Drawing.Size(506, 157);
            this.gbSendMessage.TabIndex = 48;
            this.gbSendMessage.TabStop = false;
            this.gbSendMessage.Text = "Send Message";
            // 
            // BtnTFTPFile
            // 
            this.BtnTFTPFile.Location = new System.Drawing.Point(15, 115);
            this.BtnTFTPFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnTFTPFile.Name = "BtnTFTPFile";
            this.BtnTFTPFile.Size = new System.Drawing.Size(106, 35);
            this.BtnTFTPFile.TabIndex = 42;
            this.BtnTFTPFile.Text = "TFTP File";
            this.BtnTFTPFile.Visible = false;
            // 
            // cbClearMsgAfterSend
            // 
            this.cbClearMsgAfterSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbClearMsgAfterSend.AutoSize = true;
            this.cbClearMsgAfterSend.Checked = true;
            this.cbClearMsgAfterSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClearMsgAfterSend.Location = new System.Drawing.Point(257, 121);
            this.cbClearMsgAfterSend.Name = "cbClearMsgAfterSend";
            this.cbClearMsgAfterSend.Size = new System.Drawing.Size(220, 24);
            this.cbClearMsgAfterSend.TabIndex = 41;
            this.cbClearMsgAfterSend.Text = "Clear Message after Send";
            this.cbClearMsgAfterSend.UseVisualStyleBackColor = true;
            // 
            // gbNetworkUtil
            // 
            this.gbNetworkUtil.Controls.Add(this.BtnHostInfo);
            this.gbNetworkUtil.Controls.Add(this.cmbNetworkDevices);
            this.gbNetworkUtil.Controls.Add(this.BtnQuickScan);
            this.gbNetworkUtil.Controls.Add(this.BtnScanNetwork);
            this.gbNetworkUtil.Location = new System.Drawing.Point(9, 184);
            this.gbNetworkUtil.Name = "gbNetworkUtil";
            this.gbNetworkUtil.Size = new System.Drawing.Size(719, 63);
            this.gbNetworkUtil.TabIndex = 49;
            this.gbNetworkUtil.TabStop = false;
            this.gbNetworkUtil.Text = "Network Utilities";
            // 
            // BtnHostInfo
            // 
            this.BtnHostInfo.Location = new System.Drawing.Point(479, 20);
            this.BtnHostInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnHostInfo.Name = "BtnHostInfo";
            this.BtnHostInfo.Size = new System.Drawing.Size(106, 35);
            this.BtnHostInfo.TabIndex = 47;
            this.BtnHostInfo.Text = "Host Info";
            this.BtnHostInfo.Click += new System.EventHandler(this.BtnHostInfo_Click);
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
            this.groupBox3.Location = new System.Drawing.Point(9, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(719, 94);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local PC";
            // 
            // FrmTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 702);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbNetworkUtil);
            this.Controls.Add(this.gbSendMessage);
            this.Controls.Add(this.ToolStripButtons);
            this.Controls.Add(this.gbTerminal);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbLogWindow);
            this.Controls.Add(this.gbAutomate);
            this.Controls.Add(this.dgvLogWindow);
            this.Controls.Add(this.MenuStripTerminal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStripTerminal;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1268, 642);
            this.Name = "FrmTerminal";
            this.Text = "UDPPort Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTerminal_FormClosing);
            this.Load += new System.EventHandler(this.FrmTerminal_Load);
            this.Shown += new System.EventHandler(this.FrmTerminal_Shown);
            this.gbTerminal.ResumeLayout(false);
            this.gbTerminal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogWindow)).EndInit();
            this.gbAutomate.ResumeLayout(false);
            this.gbScripting.ResumeLayout(false);
            this.gbScripting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripting)).EndInit();
            this.gbAutoReply.ResumeLayout(false);
            this.gbAutoReply.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutoReply)).EndInit();
            this.MenuStripTerminal.ResumeLayout(false);
            this.MenuStripTerminal.PerformLayout();
            this.gbLogWindow.ResumeLayout(false);
            this.gbLogWindow.PerformLayout();
            this.ToolStripButtons.ResumeLayout(false);
            this.ToolStripButtons.PerformLayout();
            this.gbSendMessage.ResumeLayout(false);
            this.gbSendMessage.PerformLayout();
            this.gbNetworkUtil.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
        private System.Windows.Forms.Button btnTermClearAll;
        private System.Windows.Forms.GroupBox gbTerminal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerScript;
        private System.Windows.Forms.DataGridView dgvLogWindow;
        private System.Windows.Forms.TextBox TbAnalyzeHexData;
        private System.Windows.Forms.Button BtnAnalyzeHexDataSearch;
        private System.Windows.Forms.Button btnDelSelRow;
        private System.Windows.Forms.CheckBox cbTermAutoScroll;
        private System.Windows.Forms.GroupBox gbAutomate;
        private System.Windows.Forms.GroupBox gbAutoReply;
        private System.Windows.Forms.GroupBox gbScripting;
        private System.Windows.Forms.CheckBox cbScriptLoop;
        private System.Windows.Forms.Button btnTermReset;
        private System.Windows.Forms.CheckBox cbScriptEnable;
        private System.Windows.Forms.DataGridView dgvScripting;
        private System.Windows.Forms.DataGridView dgvAutoReply;
        private System.Windows.Forms.CheckBox cbAutoReplyEnable;
        private System.Windows.Forms.Timer timerAutoReply;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip MenuStripTerminal;
        private System.Windows.Forms.ToolStripMenuItem TsmiFile;
        private System.Windows.Forms.ToolStripMenuItem TsmiFileExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem TsmiConnections;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem TsmiAutomate;
        private System.Windows.Forms.ToolStripMenuItem TsmiAutomateScripting;
        private System.Windows.Forms.ToolStripMenuItem TsmiAScriptOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem TsmiAScriptSaveAs;
        private System.Windows.Forms.ToolStripMenuItem TsmiAutomateAutoReply;
        private System.Windows.Forms.ToolStripMenuItem TsmiAAutoReplyOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem TsmiAAutoReplySaveAs;
        private System.Windows.Forms.ToolStripMenuItem TsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem TsmiHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem TsmiControl;
        private System.Windows.Forms.ToolStripMenuItem TsmiControlCustom;
        private System.Windows.Forms.ToolStripMenuItem TsmiCCustomTVControls;
        private System.Windows.Forms.GroupBox gbLogWindow;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip ToolStripButtons;
        private System.Windows.Forms.ToolStripButton tsbtnLogSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbtnConnect;
        private System.Windows.Forms.ToolStripButton tsbtnDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsbtnTVControls;
        private System.Windows.Forms.ToolStripButton tsbtnLogOpen;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem TsmiFileLogs;
        private System.Windows.Forms.ToolStripMenuItem TsmiFLogsOpen;
        private System.Windows.Forms.ToolStripMenuItem TsmiFLogsSaveAs;
        private System.Windows.Forms.Button BtnAnalyzeHexDataShowAll;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ethernetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.TextBox TbDestIP;
        private System.Windows.Forms.Label lblDestIP;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.Button BtnSendMessage;
        private System.Windows.Forms.TextBox TbMessage;
        private System.Windows.Forms.TextBox TbSrcIP;
        private System.Windows.Forms.Label lblSrcIP;
        private System.Windows.Forms.Button BtnUDPConnect;
        private System.Windows.Forms.TextBox TbSrcPort;
        private System.Windows.Forms.Label lblSrcPort;
        private System.Windows.Forms.TextBox TbDestPort;
        private System.Windows.Forms.Label lblDestPort;
        private System.Windows.Forms.Button BtnUDPDisconnect;
        private System.Windows.Forms.Button BtnRefreshAdapters;
        private System.Windows.Forms.ComboBox cmbAdapterName;
        private System.Windows.Forms.Button BtnScanNetwork;
        private System.Windows.Forms.ComboBox cmbNetworkDevices;
        private System.Windows.Forms.Button BtnQuickScan;
        private System.Windows.Forms.GroupBox gbSendMessage;
        private System.Windows.Forms.GroupBox gbNetworkUtil;
        private System.Windows.Forms.Button BtnHostInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbClearMsgAfterSend;
        private System.Windows.Forms.Button BtnTFTPFile;
    }
}


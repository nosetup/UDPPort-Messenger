namespace LogTerminal
{
    partial class FormUDPAutomate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUDPAutomate));
            this.gbScripting = new System.Windows.Forms.GroupBox();
            this.cbScriptEnable = new System.Windows.Forms.CheckBox();
            this.dgvScripting = new System.Windows.Forms.DataGridView();
            this.cbScriptLoop = new System.Windows.Forms.CheckBox();
            this.gbAutoReply = new System.Windows.Forms.GroupBox();
            this.cbAutoReplyEnable = new System.Windows.Forms.CheckBox();
            this.dgvAutoReply = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TsBtnScriptOpen = new System.Windows.Forms.ToolStripButton();
            this.TsBtnScriptSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TsBtnAutoReplyOpen = new System.Windows.Forms.ToolStripButton();
            this.TsBtnAutoReplySaveAs = new System.Windows.Forms.ToolStripButton();
            this.gbScripting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripting)).BeginInit();
            this.gbAutoReply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutoReply)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbScripting
            // 
            this.gbScripting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScripting.Controls.Add(this.cbScriptEnable);
            this.gbScripting.Controls.Add(this.dgvScripting);
            this.gbScripting.Controls.Add(this.cbScriptLoop);
            this.gbScripting.Location = new System.Drawing.Point(13, 106);
            this.gbScripting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScripting.Name = "gbScripting";
            this.gbScripting.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScripting.Size = new System.Drawing.Size(774, 235);
            this.gbScripting.TabIndex = 17;
            this.gbScripting.TabStop = false;
            this.gbScripting.Text = "Scripting";
            // 
            // cbScriptEnable
            // 
            this.cbScriptEnable.AutoSize = true;
            this.cbScriptEnable.Location = new System.Drawing.Point(608, 15);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScripting.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScripting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvScripting.Location = new System.Drawing.Point(3, 45);
            this.dgvScripting.Name = "dgvScripting";
            this.dgvScripting.RowHeadersWidth = 62;
            this.dgvScripting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvScripting.RowTemplate.Height = 18;
            this.dgvScripting.Size = new System.Drawing.Size(762, 182);
            this.dgvScripting.TabIndex = 21;
            // 
            // cbScriptLoop
            // 
            this.cbScriptLoop.AutoSize = true;
            this.cbScriptLoop.Location = new System.Drawing.Point(527, 15);
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
            this.gbAutoReply.Location = new System.Drawing.Point(13, 351);
            this.gbAutoReply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAutoReply.Name = "gbAutoReply";
            this.gbAutoReply.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAutoReply.Size = new System.Drawing.Size(774, 140);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAutoReply.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAutoReply.Location = new System.Drawing.Point(8, 45);
            this.dgvAutoReply.Name = "dgvAutoReply";
            this.dgvAutoReply.RowHeadersWidth = 62;
            this.dgvAutoReply.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAutoReply.RowTemplate.Height = 18;
            this.dgvAutoReply.Size = new System.Drawing.Size(760, 87);
            this.dgvAutoReply.TabIndex = 22;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TsBtnScriptOpen,
            this.TsBtnScriptSaveAs,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.TsBtnAutoReplyOpen,
            this.TsBtnAutoReplySaveAs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 52);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 47);
            this.toolStripLabel1.Text = "// Scripting >";
            // 
            // TsBtnScriptOpen
            // 
            this.TsBtnScriptOpen.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnScriptOpen.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnScriptOpen.Image")));
            this.TsBtnScriptOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnScriptOpen.Name = "TsBtnScriptOpen";
            this.TsBtnScriptOpen.Size = new System.Drawing.Size(48, 47);
            this.TsBtnScriptOpen.Text = "Open";
            this.TsBtnScriptOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnScriptOpen.Click += new System.EventHandler(this.TsBtnScriptOpen_Click);
            // 
            // TsBtnScriptSaveAs
            // 
            this.TsBtnScriptSaveAs.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnScriptSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnScriptSaveAs.Image")));
            this.TsBtnScriptSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnScriptSaveAs.Name = "TsBtnScriptSaveAs";
            this.TsBtnScriptSaveAs.Size = new System.Drawing.Size(63, 47);
            this.TsBtnScriptSaveAs.Text = "Save As";
            this.TsBtnScriptSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnScriptSaveAs.Click += new System.EventHandler(this.TsBtnScriptSaveAs_Click);
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
            this.toolStripLabel2.Size = new System.Drawing.Size(115, 47);
            this.toolStripLabel2.Text = "// Auto Reply >";
            // 
            // TsBtnAutoReplyOpen
            // 
            this.TsBtnAutoReplyOpen.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnAutoReplyOpen.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnAutoReplyOpen.Image")));
            this.TsBtnAutoReplyOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnAutoReplyOpen.Name = "TsBtnAutoReplyOpen";
            this.TsBtnAutoReplyOpen.Size = new System.Drawing.Size(48, 47);
            this.TsBtnAutoReplyOpen.Text = "Open";
            this.TsBtnAutoReplyOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnAutoReplyOpen.Click += new System.EventHandler(this.TsBtnAutoReplyOpen_Click);
            // 
            // TsBtnAutoReplySaveAs
            // 
            this.TsBtnAutoReplySaveAs.Font = new System.Drawing.Font("Calibri", 8F);
            this.TsBtnAutoReplySaveAs.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnAutoReplySaveAs.Image")));
            this.TsBtnAutoReplySaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnAutoReplySaveAs.Name = "TsBtnAutoReplySaveAs";
            this.TsBtnAutoReplySaveAs.Size = new System.Drawing.Size(63, 47);
            this.TsBtnAutoReplySaveAs.Text = "Save As";
            this.TsBtnAutoReplySaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsBtnAutoReplySaveAs.Click += new System.EventHandler(this.TsBtnAutoReplySaveAs_Click);
            // 
            // FormUDPAutomate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbScripting);
            this.Controls.Add(this.gbAutoReply);
            this.Name = "FormUDPAutomate";
            this.Text = "Automate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUDPAutomate_FormClosing);
            this.gbScripting.ResumeLayout(false);
            this.gbScripting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripting)).EndInit();
            this.gbAutoReply.ResumeLayout(false);
            this.gbAutoReply.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutoReply)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbScripting;
        private System.Windows.Forms.CheckBox cbScriptEnable;
        private System.Windows.Forms.DataGridView dgvScripting;
        private System.Windows.Forms.CheckBox cbScriptLoop;
        private System.Windows.Forms.GroupBox gbAutoReply;
        private System.Windows.Forms.CheckBox cbAutoReplyEnable;
        private System.Windows.Forms.DataGridView dgvAutoReply;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton TsBtnScriptOpen;
        private System.Windows.Forms.ToolStripButton TsBtnScriptSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton TsBtnAutoReplyOpen;
        private System.Windows.Forms.ToolStripButton TsBtnAutoReplySaveAs;
    }
}
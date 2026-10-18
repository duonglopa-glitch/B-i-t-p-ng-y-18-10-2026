namespace frmCryptoStockTicker
{
    partial class frmCryptoStockTicker
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpLiveDisplay = new System.Windows.Forms.GroupBox();
            this.lblBTCPrice = new System.Windows.Forms.Label();
            this.grpLogHistory = new System.Windows.Forms.GroupBox();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSyncCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvHistoryLog = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpLiveDisplay.SuspendLayout();
            this.grpLogHistory.SuspendLayout();
            this.stsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryLog)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpLiveDisplay, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpLogHistory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.stsMain, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.50237F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.49763F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 379F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều khiển giám sát";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Location = new System.Drawing.Point(146, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(170, 36);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶ Bắt đầu Giám sát";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LightCoral;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(644, 39);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(170, 36);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "⏸ Tạm dừng";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpLiveDisplay
            // 
            this.grpLiveDisplay.Controls.Add(this.lblBTCPrice);
            this.grpLiveDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLiveDisplay.Location = new System.Drawing.Point(3, 107);
            this.grpLiveDisplay.Name = "grpLiveDisplay";
            this.grpLiveDisplay.Size = new System.Drawing.Size(976, 81);
            this.grpLiveDisplay.TabIndex = 1;
            this.grpLiveDisplay.TabStop = false;
            this.grpLiveDisplay.Text = "Tỷ giá BTC/USD thời gian thực";
            // 
            // lblBTCPrice
            // 
            this.lblBTCPrice.AutoSize = true;
            this.lblBTCPrice.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBTCPrice.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblBTCPrice.Location = new System.Drawing.Point(318, 18);
            this.lblBTCPrice.Name = "lblBTCPrice";
            this.lblBTCPrice.Size = new System.Drawing.Size(269, 62);
            this.lblBTCPrice.TabIndex = 0;
            this.lblBTCPrice.Text = "$65,000.00";
            // 
            // grpLogHistory
            // 
            this.grpLogHistory.Controls.Add(this.dgvHistoryLog);
            this.grpLogHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLogHistory.Location = new System.Drawing.Point(3, 194);
            this.grpLogHistory.Name = "grpLogHistory";
            this.grpLogHistory.Size = new System.Drawing.Size(976, 373);
            this.grpLogHistory.TabIndex = 2;
            this.grpLogHistory.TabStop = false;
            this.grpLogHistory.Text = "Nhật ký lịch sử biến động giá";
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLastUpdate,
            this.lblSyncCount,
            this.lblStatus});
            this.stsMain.Location = new System.Drawing.Point(0, 577);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(982, 26);
            this.stsMain.TabIndex = 3;
            this.stsMain.Text = "statusStrip1";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(128, 20);
            this.lblLastUpdate.Text = "Lần cập nhật cuối:";
            // 
            // lblSyncCount
            // 
            this.lblSyncCount.Name = "lblSyncCount";
            this.lblSyncCount.Size = new System.Drawing.Size(121, 20);
            this.lblSyncCount.Text = "Số lượt đồng bộ:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 20);
            this.lblStatus.Text = "Trạng thái:";
            // 
            // dgvHistoryLog
            // 
            this.dgvHistoryLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryLog.Location = new System.Drawing.Point(3, 18);
            this.dgvHistoryLog.Name = "dgvHistoryLog";
            this.dgvHistoryLog.ReadOnly = true;
            this.dgvHistoryLog.RowHeadersWidth = 51;
            this.dgvHistoryLog.RowTemplate.Height = 24;
            this.dgvHistoryLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoryLog.Size = new System.Drawing.Size(970, 352);
            this.dgvHistoryLog.TabIndex = 0;
            // 
            // frmCryptoStockTicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCryptoStockTicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Real-Time Crypto Ticker - Cross-Thread Safety Monitor";
            this.Load += new System.EventHandler(this.frmCryptoStockTicker_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grpLiveDisplay.ResumeLayout(false);
            this.grpLiveDisplay.PerformLayout();
            this.grpLogHistory.ResumeLayout(false);
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grpLiveDisplay;
        private System.Windows.Forms.Label lblBTCPrice;
        private System.Windows.Forms.GroupBox grpLogHistory;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
        private System.Windows.Forms.ToolStripStatusLabel lblSyncCount;
        private System.Windows.Forms.DataGridView dgvHistoryLog;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}


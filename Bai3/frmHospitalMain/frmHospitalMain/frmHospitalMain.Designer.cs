namespace frmHospitalMain
{
    partial class frmHospitalMain
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
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cửaSổToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReloadData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoctors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.lblDutyUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.cửaSổToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(800, 28);
            this.mnsMain.TabIndex = 1;
            this.mnsMain.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout,
            this.mnuReloadData,
            this.mnuExit});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPatients,
            this.mnuDoctors});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // cửaSổToolStripMenuItem
            // 
            this.cửaSổToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.mnuCloseAll});
            this.cửaSổToolStripMenuItem.Name = "cửaSổToolStripMenuItem";
            this.cửaSổToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.cửaSổToolStripMenuItem.Text = "Cửa sổ";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(224, 26);
            this.mnuLogout.Text = "Đăng xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuReloadData
            // 
            this.mnuReloadData.Name = "mnuReloadData";
            this.mnuReloadData.Size = new System.Drawing.Size(224, 26);
            this.mnuReloadData.Text = "Nạp lại dữ liệu";
            this.mnuReloadData.Click += new System.EventHandler(this.mnuReloadData_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(224, 26);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuPatients
            // 
            this.mnuPatients.Name = "mnuPatients";
            this.mnuPatients.Size = new System.Drawing.Size(224, 26);
            this.mnuPatients.Text = "Hồ sơ Bệnh nhân";
            this.mnuPatients.Click += new System.EventHandler(this.mnuPatients_Click);
            // 
            // mnuDoctors
            // 
            this.mnuDoctors.Name = "mnuDoctors";
            this.mnuDoctors.Size = new System.Drawing.Size(224, 26);
            this.mnuDoctors.Text = "Lịch trực Bác sĩ";
            this.mnuDoctors.Click += new System.EventHandler(this.mnuDoctors_Click);
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(249, 26);
            this.mnuCascade.Text = "Xếp tầng - Cascade";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(249, 26);
            this.mnuTileHorizontal.Text = "Ngang - Tile Horizontal";
            this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(249, 26);
            this.mnuTileVertical.Text = "Dọc - Tile Vertical";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(249, 26);
            this.mnuCloseAll.Text = "Đóng tất cả";
            this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDutyUser,
            this.prgStatus,
            this.lblStatusText});
            this.stsMain.Location = new System.Drawing.Point(0, 424);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(800, 26);
            this.stsMain.TabIndex = 2;
            this.stsMain.Text = "statusStrip1";
            // 
            // lblDutyUser
            // 
            this.lblDutyUser.Name = "lblDutyUser";
            this.lblDutyUser.Size = new System.Drawing.Size(80, 20);
            this.lblDutyUser.Text = "Bác sĩ trực:";
            // 
            // prgStatus
            // 
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(100, 18);
            // 
            // lblStatusText
            // 
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(151, 20);
            this.lblStatusText.Text = "toolStripStatusLabel1";
            // 
            // frmHospitalMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnsMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmHospitalMain";
            this.Text = "Hệ Thống Quản Lý Bệnh Viện & Hồ Sơ Bệnh Án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHospitalMain_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuReloadData;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPatients;
        private System.Windows.Forms.ToolStripMenuItem mnuDoctors;
        private System.Windows.Forms.ToolStripMenuItem cửaSổToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDutyUser;
        private System.Windows.Forms.ToolStripProgressBar prgStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
    }
}


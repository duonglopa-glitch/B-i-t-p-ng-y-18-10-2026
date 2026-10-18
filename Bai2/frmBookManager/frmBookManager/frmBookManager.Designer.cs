namespace frmBookManager
{
    partial class frmBookManager
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
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlsOpen = new System.Windows.Forms.ToolStripLabel();
            this.tlsSave = new System.Windows.Forms.ToolStripLabel();
            this.tlsAdd = new System.Windows.Forms.ToolStripLabel();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.lblTotalBooks = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSystemTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.picBookCover = new System.Windows.Forms.PictureBox();
            this.btnBrowseCover = new System.Windows.Forms.Button();
            this.btnClearCover = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.epBook = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.mnsMain.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBookCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1132, 28);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenCsv,
            this.mnuSaveCsv,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuDelete,
            this.mnuSearch});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuOpenCsv
            // 
            this.mnuOpenCsv.Name = "mnuOpenCsv";
            this.mnuOpenCsv.Size = new System.Drawing.Size(224, 26);
            this.mnuOpenCsv.Text = "Mở CSV";
            this.mnuOpenCsv.Click += new System.EventHandler(this.mnuOpenCsv_Click);
            // 
            // mnuSaveCsv
            // 
            this.mnuSaveCsv.Name = "mnuSaveCsv";
            this.mnuSaveCsv.Size = new System.Drawing.Size(224, 26);
            this.mnuSaveCsv.Text = "Lưu CSV";
            this.mnuSaveCsv.Click += new System.EventHandler(this.mnuSaveCsv_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(224, 26);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(224, 26);
            this.mnuAdd.Text = "Thêm";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(224, 26);
            this.mnuDelete.Text = "Xóa";
            // 
            // mnuSearch
            // 
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Size = new System.Drawing.Size(224, 26);
            this.mnuSearch.Text = "Tìm kiếm";
            // 
            // tlsMain
            // 
            this.tlsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsOpen,
            this.tlsSave,
            this.tlsAdd});
            this.tlsMain.Location = new System.Drawing.Point(0, 28);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(1132, 25);
            this.tlsMain.TabIndex = 1;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlsOpen
            // 
            this.tlsOpen.Name = "tlsOpen";
            this.tlsOpen.Size = new System.Drawing.Size(30, 28);
            this.tlsOpen.Text = "📂";
            // 
            // tlsSave
            // 
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(30, 28);
            this.tlsSave.Text = "💾";
            // 
            // tlsAdd
            // 
            this.tlsAdd.Name = "tlsAdd";
            this.tlsAdd.Size = new System.Drawing.Size(30, 28);
            this.tlsAdd.Text = "➕";
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalBooks,
            this.lblTotalValue,
            this.lblSystemTime});
            this.stsMain.Location = new System.Drawing.Point(0, 647);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1132, 26);
            this.stsMain.TabIndex = 2;
            this.stsMain.Text = "statusStrip1";
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(127, 20);
            this.lblTotalBooks.Text = "Tổng số đầu sách:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(117, 20);
            this.lblTotalValue.Text = "Tổng giá trị kho:";
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.Name = "lblSystemTime";
            this.lblSystemTime.Size = new System.Drawing.Size(0, 20);
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvBooks, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.46416F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.53584F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1132, 594);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClearCover);
            this.groupBox1.Controls.Add(this.btnBrowseCover);
            this.groupBox1.Controls.Add(this.picBookCover);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtAuthor);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.txtBookId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1126, 281);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tác giả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đơn giá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng:";
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(130, 29);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(270, 22);
            this.txtBookId.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(130, 61);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(270, 22);
            this.txtTitle.TabIndex = 6;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(545, 29);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(270, 22);
            this.txtAuthor.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(545, 61);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(270, 22);
            this.txtPrice.TabIndex = 8;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(545, 95);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(102, 22);
            this.numQuantity.TabIndex = 9;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // picBookCover
            // 
            this.picBookCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBookCover.Location = new System.Drawing.Point(901, 21);
            this.picBookCover.Name = "picBookCover";
            this.picBookCover.Size = new System.Drawing.Size(176, 164);
            this.picBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBookCover.TabIndex = 10;
            this.picBookCover.TabStop = false;
            this.picBookCover.Click += new System.EventHandler(this.picBookCover_Click);
            // 
            // btnBrowseCover
            // 
            this.btnBrowseCover.Location = new System.Drawing.Point(870, 202);
            this.btnBrowseCover.Name = "btnBrowseCover";
            this.btnBrowseCover.Size = new System.Drawing.Size(96, 44);
            this.btnBrowseCover.TabIndex = 11;
            this.btnBrowseCover.Text = "Tải ảnh bìa";
            this.btnBrowseCover.UseVisualStyleBackColor = true;
            this.btnBrowseCover.Click += new System.EventHandler(this.btnBrowseCover_Click);
            // 
            // btnClearCover
            // 
            this.btnClearCover.Location = new System.Drawing.Point(1002, 202);
            this.btnClearCover.Name = "btnClearCover";
            this.btnClearCover.Size = new System.Drawing.Size(96, 44);
            this.btnClearCover.TabIndex = 12;
            this.btnClearCover.Text = "Xóa ảnh";
            this.btnClearCover.UseVisualStyleBackColor = true;
            this.btnClearCover.Click += new System.EventHandler(this.btnClearCover_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(94, 203);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 42);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(269, 203);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 42);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Sửa thông tin";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(448, 203);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 42);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Xóa sách";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(632, 203);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 42);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // epBook
            // 
            this.epBook.ContainerControl = this;
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(3, 290);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.RowTemplate.Height = 24;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1126, 301);
            this.dgvBooks.TabIndex = 1;
            // 
            // frmBookManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmBookManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Tài Liệu Sách & Nhà Sách";
            this.Load += new System.EventHandler(this.frmBookManager_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBookCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenCsv;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveCsv;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripLabel tlsOpen;
        private System.Windows.Forms.ToolStripLabel tlsSave;
        private System.Windows.Forms.ToolStripLabel tlsAdd;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalBooks;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalValue;
        private System.Windows.Forms.ToolStripStatusLabel lblSystemTime;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picBookCover;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClearCover;
        private System.Windows.Forms.Button btnBrowseCover;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.ErrorProvider epBook;
    }
}


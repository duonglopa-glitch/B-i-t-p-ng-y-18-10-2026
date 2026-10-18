using BookStoreApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmBookManager
{
    public partial class frmBookManager : Form
    {
        private BindingList<BookModel> _bookList;
        private BindingSource _bindingSource;
        private string _selectedCoverPath = string.Empty;
        public frmBookManager()
        {
            InitializeComponent();
        }

        private void frmBookManager_Load(object sender, EventArgs e)
        {
            _bookList = new BindingList<BookModel>();
            _bindingSource = new BindingSource { DataSource = _bookList };

            ConfigureDataGridView();
            InitMockData();
            RegisterEvents();
            UpdateStatusStrip();
        }
        private void ConfigureDataGridView()
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.ReadOnly = true;
            dgvBooks.MultiSelect = false;
            dgvBooks.Columns.Clear();

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookId",
                HeaderText = "Mã Sách",
                Width = 90
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Tên Sách",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Author",
                HeaderText = "Tác Giả",
                Width = 150
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Đơn Giá",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "SL Tồn",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalValue",
                HeaderText = "Tổng Giá Trị",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Chỉ hiển thị tên file hoặc đường dẫn ngắn trên lưới
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CoverPath",
                HeaderText = "Đường Dẫn Ảnh",
                Width = 160
            });

            dgvBooks.DataSource = _bindingSource;
        }

        private void InitMockData()
        {
            _bookList.Add(new BookModel("MS001", "Lập Trình C# Nâng Cao", "Nguyễn Văn A", 150000m, 20));
            _bookList.Add(new BookModel("MS002", "Cấu Trúc Dữ Liệu & Giải Thuật", "Trần Thị B", 120000m, 35));
            _bookList.Add(new BookModel("MS003", "Thiết Kế Giao Diện WinForms", "Lê Hoàng C", 180000m, 15));
        }

        private void RegisterEvents()
        {
            _bindingSource.CurrentChanged += (s, e) => LoadCurrentBookToInputs();
            _bookList.ListChanged += (s, e) => UpdateStatusStrip(); // Tự động tính lại StatusStrip khi danh sách biến động
        }
        private void LoadCurrentBookToInputs()
        {
            if (_bindingSource.Current is BookModel book)
            {
                txtBookId.Text = book.BookId;
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtPrice.Text = book.Price.ToString("G0");
                numQuantity.Value = book.Quantity;

                _selectedCoverPath = book.CoverPath;
                DisplayCoverImage(_selectedCoverPath);

                txtBookId.ReadOnly = true; // Khóa mã sách khi đang chọn từ lưới
            }
        }

        private void btnBrowseCover_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh bìa sách";
                ofd.Filter = "Tệp hình ảnh (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Tất cả tệp (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedCoverPath = ofd.FileName;
                    DisplayCoverImage(_selectedCoverPath);
                }
            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            _selectedCoverPath = string.Empty;
            if (picBookCover.Image != null)
            {
                picBookCover.Image.Dispose();
                picBookCover.Image = null;
            }
        }

        private void picBookCover_Click(object sender, EventArgs e)
        {

        }
        private void DisplayCoverImage(string path)
        {
            if (picBookCover.Image != null)
            {
                picBookCover.Image.Dispose();
                picBookCover.Image = null;
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    // Đọc file dạng Stream để không bị khóa file đĩa
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        picBookCover.Image = Image.FromStream(fs);
                    }
                }
                catch
                {
                    picBookCover.Image = null;
                }
            }
        }
        private bool ValidateInput(bool isNew)
        {
            epBook.Clear();
            bool isValid = true;

            // 1. Kiểm tra Mã sách
            if (string.IsNullOrWhiteSpace(txtBookId.Text))
            {
                epBook.SetError(txtBookId, "Mã sách không được để trống!");
                isValid = false;
            }
            else if (isNew && _bookList.Any(b => b.BookId.Equals(txtBookId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                epBook.SetError(txtBookId, "Mã sách đã tồn tại trong kho!");
                isValid = false;
            }

            // 2. Kiểm tra Tên sách
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                epBook.SetError(txtTitle, "Tên sách không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Tác giả
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                epBook.SetError(txtAuthor, "Tên tác giả không được để trống!");
                isValid = false;
            }

            // 4. Kiểm tra Đơn giá
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                epBook.SetError(txtPrice, "Đơn giá sách phải là số dương (> 0)!");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isNew: true)) return;

            BookModel newBook = new BookModel(
                txtBookId.Text.Trim(),
                txtTitle.Text.Trim(),
                txtAuthor.Text.Trim(),
                decimal.Parse(txtPrice.Text.Trim()),
                (int)numQuantity.Value,
                _selectedCoverPath
            );

            _bookList.Add(newBook);
            MessageBox.Show("Thêm sách mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is BookModel currentBook)
            {
                if (!ValidateInput(isNew: false)) return;

                currentBook.Title = txtTitle.Text.Trim();
                currentBook.Author = txtAuthor.Text.Trim();
                currentBook.Price = decimal.Parse(txtPrice.Text.Trim());
                currentBook.Quantity = (int)numQuantity.Value;
                currentBook.CoverPath = _selectedCoverPath;

                _bindingSource.ResetCurrentItem();
                MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đầu sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is BookModel currentBook)
            {
                DialogResult dr = MessageBox.Show(
                    string.Format("Bạn có chắc chắn muốn xóa đầu sách [{0}] - {1}?", currentBook.BookId, currentBook.Title),
                    "Xác nhận xóa sách", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _bookList.Remove(currentBook);
                    ClearInputForm();
                    MessageBox.Show("Đã xóa đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputForm();
        }
        private void ClearInputForm()
        {
            dgvBooks.ClearSelection();
            txtBookId.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            numQuantity.Value = 1;
            btnClearCover_Click(null, null);

            txtBookId.ReadOnly = false;
            epBook.Clear();
            txtBookId.Focus();
        }

        private void mnuSaveCsv_Click(object sender, EventArgs e)
        {
            if (_bookList.Count == 0)
            {
                MessageBox.Show("Danh sách sách hiện tại đang rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu báo cáo danh sách sách ra file CSV";
                sfd.Filter = "File CSV (*.csv)|*.csv";
                sfd.FileName = string.Format("BaoCaoNhaSach_{0:yyyyMMdd_HHmmss}.csv", DateTime.Now);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("MaSach,TenSach,TacGia,DonGia,SoLuong,DuongDanAnh");

                        foreach (var book in _bookList)
                        {
                            sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\",{3},{4},\"{5}\"",
                                book.BookId,
                                book.Title,
                                book.Author,
                                book.Price,
                                book.Quantity,
                                book.CoverPath));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file CSV báo cáo nhà sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi trong quá trình ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void mnuOpenCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Mở file CSV dữ liệu sách";
                ofd.Filter = "File CSV (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                        if (lines.Length <= 1)
                        {
                            MessageBox.Show("File CSV không chứa dữ liệu hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _bookList.Clear(); // Xóa dữ liệu cũ trước khi nạp file mới

                        // Bỏ qua dòng Tiêu đề (i = 1)
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string line = lines[i].Trim();
                            if (string.IsNullOrEmpty(line)) continue;

                            // Parse dòng CSV đơn giản tách theo dấu phẩy
                            string[] parts = line.Split(',');
                            if (parts.Length >= 5)
                            {
                                string bookId = parts[0].Trim('"');
                                string title = parts[1].Trim('"');
                                string author = parts[2].Trim('"');
                                decimal.TryParse(parts[3], out decimal price);
                                int.TryParse(parts[4], out int quantity);
                                string coverPath = parts.Length >= 6 ? parts[5].Trim('"') : "";

                                _bookList.Add(new BookModel(bookId, title, author, price, quantity, coverPath));
                            }
                        }

                        MessageBox.Show(string.Format("Đã nhập thành công {0} đầu sách từ file CSV!", _bookList.Count), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void UpdateStatusStrip()
        {
            int totalBooks = _bookList.Count;
            decimal totalValue = _bookList.Sum(b => b.TotalValue);

            lblTotalBooks.Text = string.Format("Tổng số đầu sách: {0}", totalBooks);
            lblTotalValue.Text = string.Format("Tổng giá trị kho: {0:N0} VNĐ", totalValue);
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}

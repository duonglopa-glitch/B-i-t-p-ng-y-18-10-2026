using RevenueAnalyticsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmRevenueAnalytics
{
    public partial class frmRevenueAnalytics : Form
    {
        private CancellationTokenSource _cts;
        public frmRevenueAnalytics()
        {
            InitializeComponent();
        }

        private void frmRevenueAnalytics_Load(object sender, EventArgs e)
        {
            InitDropdownData();
            ConfigureDataGridView();
        }
        private void InitDropdownData()
        {
            cboBranch.Items.Clear();
            cboBranch.Items.AddRange(new object[] {
                "Tất cả chi nhánh",
                "Chi nhánh Hà Nội",
                "Chi nhánh TP.HCM",
                "Chi nhánh Đà Nẵng"
            });
            cboBranch.SelectedIndex = 0;

            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;
        }

        private void ConfigureDataGridView()
        {
            dgvRevenueData.AutoGenerateColumns = false;
            dgvRevenueData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueData.ReadOnly = true;
            dgvRevenueData.MultiSelect = false;
            dgvRevenueData.Columns.Clear();

            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TransactionId", HeaderText = "Mã GD", Width = 100 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BranchName", HeaderText = "Chi Nhánh", Width = 150 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TransactionDate", HeaderText = "Ngày GD", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "Khách Hàng", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "Số Tiền (VNĐ)", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentMethod", HeaderText = "Hình Thức TT", Width = 130 });
        }
        private bool ValidateInput()
        {
            epAnalytics.Clear();
            bool isValid = true;

            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                epAnalytics.SetError(dtpFromDate, "'Từ ngày' không được lớn hơn 'Đến ngày'!");
                isValid = false;
            }

            return isValid;
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // 1. Cập nhật trạng thái Controls giao diện
            btnAnalyze.Enabled = false;
            btnCancel.Enabled = true;
            pgbLoading.Value = 0;
            dgvRevenueData.DataSource = null;

            // 2. Khởi tạo CancellationTokenSource mới
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            // 3. Khai báo IProgress để nhận phần trăm tiến độ từ Background Thread đẩy về UI Thread
            var progressHandler = new Progress<int>(percent =>
            {
                pgbLoading.Value = percent;
                lblProcessingStatus.Text = string.Format("Đang truy xuất CSDL & tổng hợp dữ liệu... {0}%", percent);
            });

            string selectedBranch = cboBranch.SelectedItem.ToString();
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            try
            {
                // 4. Đẩy tác vụ tính toán nặng xuống Background Thread bằng Task.Run
                // UI Thread hoàn toàn rảnh rỗi, Form không bị đơ (Not Responding)
                List<RevenueTransactionModel> result = await Task.Run(() =>
                    SimulateHeavyDataAggregation(selectedBranch, fromDate, toDate, progressHandler, token), token);

                // 5. Hiển thị kết quả khi hoàn tất
                dgvRevenueData.DataSource = new BindingList<RevenueTransactionModel>(result);

                decimal totalRevenue = result.Sum(x => x.Amount);
                lblProcessingStatus.Text = string.Format("Hoàn tất! Đã xử lý {0} giao dịch. Tổng doanh thu: {1:N0} VNĐ", result.Count, totalRevenue);
                pgbLoading.Value = 100;
            }
            catch (OperationCanceledException)
            {
                // Bắt ngoại lệ khi người dùng bấm Hủy
                lblProcessingStatus.Text = "Trạng thái: ĐÃ HỦY THAO TÁC THỐNG KÊ!";
                pgbLoading.Value = 0;
                MessageBox.Show("Tiến trình thống kê đã bị hủy bởi người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblProcessingStatus.Text = "Lỗi trong quá trình xử lý!";
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 6. Khôi phục trạng thái nút bấm và giải phóng CancellationTokenSource
                btnAnalyze.Enabled = true;
                btnCancel.Enabled = false;
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                lblProcessingStatus.Text = "Đang gửi yêu cầu hủy tiến trình...";
                btnCancel.Enabled = false; // Khóa nút hủy tránh người dùng bấm liên tục
                _cts.Cancel(); // Phát tín hiệu yêu cầu hủy
            }
        }
        private List<RevenueTransactionModel> SimulateHeavyDataAggregation(
            string branch,
            DateTime fromDate,
            DateTime toDate,
            IProgress<int> progress,
            CancellationToken token)
        {
            List<RevenueTransactionModel> list = new List<RevenueTransactionModel>();

            // Giả lập tiến trình chạy qua 50 bước, tổng thời gian tốn từ 4 - 5 giây
            int totalSteps = 50;
            for (int i = 1; i <= totalSteps; i++)
            {
                // KIỂM TRA TÍN HIỆU HỦY TỪ NGƯỜI DÙNG TẠI MỖI VÒNG LẶP
                token.ThrowIfCancellationRequested();

                // Tạm dừng 90ms mỗi bước để giả lập thời gian query/xử lý CSDL lớn
                Thread.Sleep(90);

                // Báo cáo phần trăm tiến độ lên UI Thread
                int percentComplete = (i * 100) / totalSteps;
                progress?.Report(percentComplete);
            }

            // Tạo dữ liệu giả lập kết quả sau khi xử lý thành công
            string[] customers = { "Công ty CP Nam Việt", "Tập đoàn Vingroup", "Nguyễn Thị Kim Anh", "Phạm Quốc Hùng", "Lê Minh Trí", "Siêu thị Big C" };
            string[] methods = { "Chuyển khoản QR", "Thẻ Visa/Mastercard", "Tiền mặt", "Ví Điện Tử Momo" };
            Random rand = new Random();

            int recordCount = rand.Next(15, 30);
            for (int k = 1; k <= recordCount; k++)
            {
                string transId = string.Format("GD{0:D4}", rand.Next(1000, 9999));
                string branchName = branch == "Tất cả chi nhánh" ? string.Format("Chi nhánh {0}", rand.Next(1, 4)) : branch;
                DateTime date = fromDate.AddDays(rand.Next(0, (toDate - fromDate).Days + 1)).AddHours(rand.Next(8, 20));
                string customer = customers[rand.Next(customers.Length)];
                decimal amount = rand.Next(500, 50000) * 1000m;
                string method = methods[rand.Next(methods.Length)];

                list.Add(new RevenueTransactionModel(transId, branchName, date, customer, amount, method));
            }

            return list.OrderByDescending(x => x.TransactionDate).ToList();
        }
    }
}

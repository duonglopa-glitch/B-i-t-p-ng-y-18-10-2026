using CryptoTickerApp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace frmCryptoStockTicker
{
    
    public partial class frmCryptoStockTicker : Form
    {
        private BindingList<TickerLogModel> _logList;
        private BindingSource _bindingSource;

        private CancellationTokenSource _cts;
        private decimal _currentPrice = 65000.00m; // Giá khởi điểm BTC/USD
        private int _syncCounter = 0;
        private bool _isMonitoring = false;
        public frmCryptoStockTicker()
        {
            InitializeComponent();
        }

        private void frmCryptoStockTicker_Load(object sender, EventArgs e)
        {
            _logList = new BindingList<TickerLogModel>();
            _bindingSource = new BindingSource { DataSource = _logList };

            ConfigureDataGridView();
            UpdateStatusStripText("Trạng thái: Sẵn sàng.");
        }
        private void ConfigureDataGridView()
        {
            dgvHistoryLog.AutoGenerateColumns = false;
            dgvHistoryLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryLog.ReadOnly = true;
            dgvHistoryLog.MultiSelect = false;
            dgvHistoryLog.Columns.Clear();

            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LogTime",
                HeaderText = "Thời Gian Quét",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm:ss (dd/MM)" }
            });

            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Giá BTC/USD",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Change",
                HeaderText = "Biến Động ($)",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "+$#,##0.00;-$#,##0.00;$0.00", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrendStatus",
                HeaderText = "Xu Hướng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistoryLog.DataSource = _bindingSource;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isMonitoring) return;

            _isMonitoring = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            UpdateStatusStripText("Trạng thái: Đang giám sát tỷ giá thời gian thực (Mỗi 2 giây)...");

            // Đẩy tiến trình ngầm chạy lặp vô hạn xuống Background Thread
            Task.Run(() => MonitoringLoop(token), token);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_isMonitoring) return;

            _isMonitoring = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            UpdateStatusStripText("Trạng thái: Đã tạm dừng giám sát.");
        }
        private async Task MonitoringLoop(CancellationToken token)
        {
            Random rand = new Random();

            while (!token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(2000, token);

                    double percentChange = (rand.NextDouble() * 3.0) - 1.5;
                    decimal changeAmount = _currentPrice * (decimal)(percentChange / 100.0);
                    decimal newPrice = Math.Round(_currentPrice + changeAmount, 2);

                    _currentPrice = newPrice;
                    DateTime updateTime = DateTime.Now;

                    SafeUpdateUI(newPrice, changeAmount, updateTime);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                        MessageBox.Show("Lỗi trong luồng ngầm: " + ex.Message, "Lỗi Ticker", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    break;
                }
            }
        }
        private void SafeUpdateUI(decimal newPrice, decimal change, DateTime updateTime)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SafeUpdateUI(newPrice, change, updateTime)));
                return;
            }


            lblBTCPrice.Text = string.Format("${0:N2}", newPrice);

            if (change > 0)
            {
                lblBTCPrice.ForeColor = Color.ForestGreen;
                lblBTCPrice.Text += " ▲";
            }
            else if (change < 0)
            {
                lblBTCPrice.ForeColor = Color.Crimson;
                lblBTCPrice.Text += " ▼";
            }
            else
            {
                lblBTCPrice.ForeColor = Color.Black;
            }

            string trend = change > 0 ? "Tăng 🟢" : (change < 0 ? "Giảm 🔴" : "Đứng giá ⚪");
            _logList.Insert(0, new TickerLogModel(updateTime, newPrice, change, trend));

            if (_logList.Count > 50)
            {
                _logList.RemoveAt(_logList.Count - 1);
            }

            _syncCounter++;
            lblLastUpdate.Text = string.Format("Lần cập nhật cuối: {0:HH:mm:ss}", updateTime);
            lblSyncCount.Text = string.Format("Số lượt đồng bộ: {0}", _syncCounter);
        }

        private void UpdateStatusStripText(string statusMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateStatusStripText(statusMessage)));
                return;
            }
            lblStatus.Text = statusMessage;
        }
        private void frmCryptoStockTicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
        }

    }
}

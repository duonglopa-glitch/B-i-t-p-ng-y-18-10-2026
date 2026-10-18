using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmHospitalMain
{
    public partial class frmHospitalMain : Form
    {
        public frmHospitalMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void frmHospitalMain_Load(object sender, EventArgs e)
        {
            lblDutyUser.Text = "Cán bộ trực ca: BS. CKII. Nguyễn Văn An | Khoa Cấp Cứu";
            lblStatusText.Text = "Hệ thống sẵn sàng.";
        }
        private void OpenOrActivateChildForm<T>() where T : Form, new()
        {
            // Duyệt qua tất cả các Form con đang mở trong MdiChildren
            foreach (Form child in this.MdiChildren)
            {
                if (child is T targetForm)
                {
                    // Nếu Form đã tồn tại -> Mang lên trên cùng và khôi phục nếu đang bị thu nhỏ
                    if (targetForm.WindowState == FormWindowState.Minimized)
                    {
                        targetForm.WindowState = FormWindowState.Normal;
                    }
                    targetForm.Activate();
                    lblStatusText.Text = string.Format("Đã kích hoạt cửa sổ: {0}", targetForm.Text);
                    return;
                }
            }

            // Nếu Form chưa mở -> Khởi tạo Instance mới và nhúng vào Form cha MDI
            T newChildForm = new T
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };

            newChildForm.Show();
            lblStatusText.Text = string.Format("Đã mở cửa sổ mới: {0}", newChildForm.Text);
        }

        private void mnuPatients_Click(object sender, EventArgs e)
        {
            OpenOrActivateChildForm<frmPatientProfiles>();
        }

        private void mnuDoctors_Click(object sender, EventArgs e)
        {
            OpenOrActivateChildForm<frmDoctorSchedule>();
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            lblStatusText.Text = "Đã sắp xếp cửa sổ dạng Xếp tầng (Cascade).";
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            lblStatusText.Text = "Đã sắp xếp cửa sổ dạng Ngang (Tile Horizontal).";
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            lblStatusText.Text = "Đã sắp xếp cửa sổ dạng Dọc (Tile Vertical).";
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            lblStatusText.Text = "Đã đóng tất cả các cửa sổ con.";
        }

        private async void mnuReloadData_Click(object sender, EventArgs e)
        {
            prgStatus.Visible = true;
            prgStatus.Value = 0;
            lblStatusText.Text = "Đang đồng bộ lại dữ liệu toàn hệ thống...";

            // Mô phỏng tiến trình tải dữ liệu bất đồng bộ
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(100);
                prgStatus.Value = i * 10;
            }

            prgStatus.Visible = false;
            lblStatusText.Text = "Đã nạp xong dữ liệu hệ thống!";
            MessageBox.Show("Đồng bộ dữ liệu bệnh viện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất khỏi phiên làm việc hiện tại?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                mnuCloseAll_Click(null, null);
                lblDutyUser.Text = "Chưa đăng nhập";
                MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng Quản lý Bệnh viện?", "Thoát hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

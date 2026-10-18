using GymManagementApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmGymMemberManager
{
    public partial class frmGymMemberManager : Form
    {
        private BindingList<MemberModel> _memberList;
        private BindingSource _bindingSource;
        public frmGymMemberManager()
        {
            InitializeComponent();
        }

        private void frmGymMemberManager_Load(object sender, EventArgs e)
        {
            _memberList = new BindingList<MemberModel>();
            _bindingSource = new BindingSource { DataSource = _memberList };

            InitDropdownData();
            ConfigureDataGridView();
            InitMockData();
            RegisterEvents();

            txtMemberId.Text = GenerateNextMemberId();
        }
        private void InitDropdownData()
        {
            cboPackage.Items.Clear();
            cboPackage.Items.AddRange(new object[] { "Theo tháng", "6 tháng", "1 năm" });
            cboPackage.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
        }

        private void ConfigureDataGridView()
        {
            // Yêu cầu 1: Tuyệt đối không tự sinh cột, cấu hình thủ công 100% bằng C#
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.ReadOnly = true;
            dgvMembers.MultiSelect = false;
            dgvMembers.Columns.Clear();

            // Khai báo từng cột khớp chính xác với Property của MemberModel
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MemberId",
                HeaderText = "Mã HV",
                Width = 90
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Tên Hội Viên",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Số Điện Thoại",
                Width = 120
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Package",
                HeaderText = "Gói Tập",
                Width = 120
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StartDate",
                HeaderText = "Ngày ĐK",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Định dạng cột phí dịch vụ theo chuẩn "N0"
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fee",
                HeaderText = "Phí Dịch Vụ",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvMembers.DataSource = _bindingSource;
        }

        private void InitMockData()
        {
            _memberList.Add(new MemberModel("HV001", "Nguyễn Văn Tuấn", "0912345678", "Theo tháng", DateTime.Today.AddDays(-15), 500000m));
            _memberList.Add(new MemberModel("HV002", "Trần Thị Minh", "0987654321", "6 tháng", DateTime.Today.AddDays(-60), 2700000m));
            _memberList.Add(new MemberModel("HV003", "Lê Hoàng Nam", "0905112233", "1 năm", DateTime.Today.AddDays(-100), 4800000m));
        }

        private void RegisterEvents()
        {
            // Lắng nghe sự kiện chuyển dòng trên DataGridView để nạp thông tin lên Control
            _bindingSource.CurrentChanged += BindingSource_CurrentChanged;
        }
        private string GenerateNextMemberId()
        {
            int maxId = 0;
            foreach (var member in _memberList)
            {
                if (member.MemberId.StartsWith("HV") && int.TryParse(member.MemberId.Substring(2), out int currentId))
                {
                    if (currentId > maxId) maxId = currentId;
                }
            }
            return string.Format("HV{0:D3}", maxId + 1);
        }
        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Current is MemberModel member)
            {
                txtMemberId.Text = member.MemberId;
                txtFullName.Text = member.FullName;
                txtPhone.Text = member.Phone;
                cboPackage.SelectedItem = member.Package;
                dtpStartDate.Value = member.StartDate < dtpStartDate.MinDate ? DateTime.Today : member.StartDate;
                txtFee.Text = member.Fee.ToString("G0");

                epGym.Clear(); // Dọn sạch lỗi cũ khi chọn dòng mới
            }
        }
        private bool ValidateInput()
        {
            epGym.Clear();
            bool isValid = true;

            // 1. Kiểm tra Tên hội viên (Không trống, không chứa ký tự đặc biệt/số)
            string namePattern = @"^[\p{L}\s]+$"; // Chỉ cho phép chữ cái tiếng Việt và khoảng trắng
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                epGym.SetError(txtFullName, "Tên hội viên không được để trống!");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtFullName.Text.Trim(), namePattern))
            {
                epGym.SetError(txtFullName, "Tên hội viên không được chứa số hoặc ký tự đặc biệt!");
                isValid = false;
            }

            // 2. Kiểm tra Số điện thoại (Đúng 10 chữ số)
            string phonePattern = @"^\d{10}$";
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text.Trim(), phonePattern))
            {
                epGym.SetError(txtPhone, "Số điện thoại phải bao gồm đúng 10 chữ số!");
                isValid = false;
            }

            // 3. Kiểm tra Phí dịch vụ (Số nguyên dương)
            if (!decimal.TryParse(txtFee.Text.Trim(), out decimal fee) || fee <= 0)
            {
                epGym.SetError(txtFee, "Phí dịch vụ phải là một số nguyên dương (> 0)!");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string newId = GenerateNextMemberId();
            decimal fee = decimal.Parse(txtFee.Text.Trim());

            MemberModel newMember = new MemberModel(
                newId,
                txtFullName.Text.Trim(),
                txtPhone.Text.Trim(),
                cboPackage.SelectedItem.ToString(),
                dtpStartDate.Value,
                fee
            );

            _memberList.Add(newMember);
            MessageBox.Show(string.Format("Thêm thành công hội viên [{0}]!", newId), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearInputForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is MemberModel currentMember)
            {
                if (!ValidateInput()) return;

                // Thay đổi thuộc tính của đối tượng -> INotifyPropertyChanged tự cập nhật xuống BindingList & DataGridView
                currentMember.FullName = txtFullName.Text.Trim();
                currentMember.Phone = txtPhone.Text.Trim();
                currentMember.Package = cboPackage.SelectedItem.ToString();
                currentMember.StartDate = dtpStartDate.Value;
                currentMember.Fee = decimal.Parse(txtFee.Text.Trim());

                // Ép BindingSource phát tín hiệu làm mới dòng hiện tại trên lưới
                _bindingSource.ResetCurrentItem();

                MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hội viên trên bảng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is MemberModel currentMember)
            {
                // Hộp thoại xác nhận Yes/No dạng Warning
                DialogResult dr = MessageBox.Show(
                    string.Format("Bạn có chắc chắn muốn xóa hội viên [{0}] - {1} khỏi hệ thống?", currentMember.MemberId, currentMember.FullName),
                    "Xác nhận xóa hội viên",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dr == DialogResult.Yes)
                {
                    _memberList.Remove(currentMember);
                    ClearInputForm();
                    MessageBox.Show("Đã xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputForm();
        }
        private void ClearInputForm()
        {
            dgvMembers.ClearSelection();
            txtMemberId.Text = GenerateNextMemberId();
            txtFullName.Clear();
            txtPhone.Clear();
            cboPackage.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
            txtFee.Clear();

            epGym.Clear();
            txtFullName.Focus();
        }
    }
}

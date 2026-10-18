using HospitalMdiApp;
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
    public partial class frmPatientProfiles : Form
    {
        private BindingList<PatientModel> _patientList;
        private BindingSource _bindingSource;
        public frmPatientProfiles()
        {
            InitializeComponent();
        }
        
        private void ConfigureDataGridView()
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.ReadOnly = true;
            dgvPatients.MultiSelect = false;
            dgvPatients.Columns.Clear();

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientId", HeaderText = "Mã BN", Width = 90 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ Tên Bệnh Nhân", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Giới Tính", Width = 80 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DateOfBirth", HeaderText = "Ngày Sinh", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Số Điện Thoại", Width = 110 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Diagnosis", HeaderText = "Chẩn Đoán Bệnh", Width = 180 });

            dgvPatients.DataSource = _bindingSource;
        }

        private void InitMockData()
        {
            _patientList.Add(new PatientModel("BN001", "Nguyễn Văn Hùng", "Nam", new DateTime(1985, 5, 20), "0912345678", "Sốt xuất huyết Dengue"));
            _patientList.Add(new PatientModel("BN002", "Trần Thị Mai", "Nữ", new DateTime(1992, 11, 15), "0987654321", "Viêm dạ dày cấp"));
            _patientList.Add(new PatientModel("BN003", "Lê Hoàng Nam", "Nam", new DateTime(2000, 3, 8), "0905112233", "Theo dõi Viêm ruột thừa"));
        }

        private void BindControls()
        {
            _bindingSource.CurrentChanged += (s, e) =>
            {
                if (_bindingSource.Current is PatientModel patient)
                {
                    txtPatientId.Text = patient.PatientId;
                    txtFullName.Text = patient.FullName;
                    cboGender.SelectedItem = patient.Gender;
                    dtpDob.Value = patient.DateOfBirth;
                    txtPhone.Text = patient.Phone;
                    txtDiagnosis.Text = patient.Diagnosis;
                }
            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPatientProfiles_Load(object sender, EventArgs e)
        {
            _patientList = new BindingList<PatientModel>();
            _bindingSource = new BindingSource { DataSource = _patientList };

            ConfigureDataGridView();
            InitMockData();
            BindControls();
        }
    }
}

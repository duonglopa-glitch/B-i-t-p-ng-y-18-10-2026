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
    public partial class frmDoctorSchedule : Form
    {
        private BindingList<DoctorScheduleModel> _scheduleList;
        private BindingSource _bindingSource;
        public frmDoctorSchedule()
        {
            InitializeComponent();
        }

        private void frmDoctorSchedule_Load(object sender, EventArgs e)
        {
            _scheduleList = new BindingList<DoctorScheduleModel>();
            _bindingSource = new BindingSource { DataSource = _scheduleList };

            ConfigureDataGridView();
            InitMockData();
        }
        private void ConfigureDataGridView()
        {
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.ReadOnly = true;
            dgvSchedules.MultiSelect = false;
            dgvSchedules.Columns.Clear();

            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ScheduleId", HeaderText = "Mã Lịch", Width = 90 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Bác Sĩ Trực", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Department", HeaderText = "Khoa / Phòng", Width = 150 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ShiftDate", HeaderText = "Ngày Trực", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ShiftTime", HeaderText = "Ca Trực", Width = 100 });
            dgvSchedules.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomNumber", HeaderText = "Phòng Trực", Width = 100 });

            dgvSchedules.DataSource = _bindingSource;
        }

        private void InitMockData()
        {
            _scheduleList.Add(new DoctorScheduleModel("LT001", "BS. CKII. Nguyễn Văn An", "Khoa Cấp Cứu", DateTime.Today, "Ca đêm (22h - 06h)", "P.Cấp cứu 01"));
            _scheduleList.Add(new DoctorScheduleModel("LT002", "BS. CKI. Phạm Thi Bích", "Khoa Nhi", DateTime.Today, "Ca sáng (07h - 15h)", "P.Khám Nhi 03"));
            _scheduleList.Add(new DoctorScheduleModel("LT003", "ThS. BS. Trần Minh Cường", "Khoa Tim Mạch", DateTime.Today.AddDays(1), "Ca chiều (15h - 22h)", "P.Khám Tim 02"));
        }
    }
}

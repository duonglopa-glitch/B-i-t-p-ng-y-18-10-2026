using System;

namespace HospitalMdiApp
{
    public class DoctorScheduleModel
    {
        public string ScheduleId { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftTime { get; set; } // Ca sáng, Ca chiều, Ca đêm
        public string RoomNumber { get; set; }

        public DoctorScheduleModel() { }

        public DoctorScheduleModel(string id, string name, string dept, DateTime date, string time, string room)
        {
            ScheduleId = id;
            DoctorName = name;
            Department = dept;
            ShiftDate = date;
            ShiftTime = time;
            RoomNumber = room;
        }
    }
}
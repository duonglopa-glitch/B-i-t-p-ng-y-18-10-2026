using System;

namespace HospitalMdiApp
{
    public class PatientModel
    {
        public string PatientId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Diagnosis { get; set; }

        public PatientModel() { }

        public PatientModel(string id, string name, string gender, DateTime dob, string phone, string diagnosis)
        {
            PatientId = id;
            FullName = name;
            Gender = gender;
            DateOfBirth = dob;
            Phone = phone;
            Diagnosis = diagnosis;
        }
    }
}
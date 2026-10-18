using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GymManagementApp
{
    public class MemberModel : INotifyPropertyChanged
    {
        private string _memberId;
        private string _fullName;
        private string _phone;
        private string _package;
        private DateTime _startDate;
        private decimal _fee;

        public string MemberId
        {
            get => _memberId;
            set { _memberId = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(); }
        }

        public string Package
        {
            get => _package;
            set { _package = value; OnPropertyChanged(); }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }

        public decimal Fee
        {
            get => _fee;
            set { _fee = value; OnPropertyChanged(); }
        }

        public MemberModel() { }

        public MemberModel(string memberId, string fullName, string phone, string package, DateTime startDate, decimal fee)
        {
            _memberId = memberId;
            _fullName = fullName;
            _phone = phone;
            _package = package;
            _startDate = startDate;
            _fee = fee;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
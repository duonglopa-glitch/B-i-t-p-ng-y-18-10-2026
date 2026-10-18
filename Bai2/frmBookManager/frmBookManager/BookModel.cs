using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookStoreApp
{
    public class BookModel : INotifyPropertyChanged
    {
        private string _bookId;
        private string _title;
        private string _author;
        private decimal _price;
        private int _quantity;
        private string _coverPath;

        public string BookId
        {
            get => _bookId;
            set { _bookId = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get => _author;
            set { _author = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalValue)); }
        }

        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalValue)); }
        }

        public string CoverPath
        {
            get => _coverPath;
            set { _coverPath = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Thành tiền tồn kho của đầu sách = Đơn giá x Số lượng
        /// </summary>
        public decimal TotalValue => _price * _quantity;

        public BookModel() { }

        public BookModel(string bookId, string title, string author, decimal price, int quantity, string coverPath = "")
        {
            _bookId = bookId;
            _title = title;
            _author = author;
            _price = price;
            _quantity = quantity;
            _coverPath = coverPath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
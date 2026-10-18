using System;

namespace CryptoTickerApp
{
    public class TickerLogModel
    {
        public DateTime LogTime { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
        public string TrendStatus { get; set; }

        public TickerLogModel() { }

        public TickerLogModel(DateTime time, decimal price, decimal change, string status)
        {
            LogTime = time;
            Price = price;
            Change = change;
            TrendStatus = status;
        }
    }
}
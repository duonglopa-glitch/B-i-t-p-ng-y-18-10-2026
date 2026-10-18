using System;

namespace RevenueAnalyticsApp
{
    public class RevenueTransactionModel
    {
        public string TransactionId { get; set; }
        public string BranchName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }

        public RevenueTransactionModel() { }

        public RevenueTransactionModel(string id, string branch, DateTime date, string customer, decimal amount, string method)
        {
            TransactionId = id;
            BranchName = branch;
            TransactionDate = date;
            CustomerName = customer;
            Amount = amount;
            PaymentMethod = method;
        }
    }
}
using EconoMe.Api.Contracts.Transaction;

namespace EconoMe.Api.Contracts.Receivable
{
    public class ReceivableRequestContract : TransactionRequestContract
    {
        public double AmountReceived { get; set; }
        public DateTime? ReceiptDate { get; set; }
    }
}
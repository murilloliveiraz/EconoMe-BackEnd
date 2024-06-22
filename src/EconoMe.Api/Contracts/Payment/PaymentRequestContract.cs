using EconoMe.Api.Contracts.Transaction;

namespace EconoMe.Api.Contracts.Payment
{
    public class PaymentRequestContract : TransactionRequestContract
    {
        public double AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
namespace EconoMe.Api.Contracts.Payment
{
    public class PaymentRequestContract
    {
        public long TransactionCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public double OriginalAmount { get; set; }
        public double AmountPaid { get; set; }
        public DateTime? ReferenceDate  { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
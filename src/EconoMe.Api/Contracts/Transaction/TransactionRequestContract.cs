namespace EconoMe.Api.Contracts.Transaction
{
    public abstract class TransactionRequestContract
    {
        public long TransactionCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public double OriginalAmount { get; set; }
        public DateTime? ReferenceDate  { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
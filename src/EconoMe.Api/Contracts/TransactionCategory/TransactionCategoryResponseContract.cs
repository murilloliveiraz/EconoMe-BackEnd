namespace EconoMe.Api.Contracts.TransactionCategory
{
    public class TransactionCategoryResponseContract : TransactionCategoryRequestContract
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
    }
}
namespace EconoMe.Api.Contracts.Receivable
{
    public class ReceivableResponseContract : ReceivableRequestContract
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
    }
}
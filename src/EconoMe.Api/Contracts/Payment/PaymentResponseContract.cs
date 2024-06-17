namespace EconoMe.Api.Contracts.Payment
{
    public class PaymentResponseContract : PaymentRequestContract
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
    }
}
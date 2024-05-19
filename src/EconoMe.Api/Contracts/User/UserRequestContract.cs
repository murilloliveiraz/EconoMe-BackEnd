namespace EconoMe.Api.Contracts.User
{
    public class UserRequestContract : UserLoginRequestContract
    {
        public DateTime? InactivationDate { get; set; }
    }
}
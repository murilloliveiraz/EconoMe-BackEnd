using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.Domain.Repository.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment, long>
    {
        Task<IEnumerable<Payment>> GetByUserId(long userId);
    }
}
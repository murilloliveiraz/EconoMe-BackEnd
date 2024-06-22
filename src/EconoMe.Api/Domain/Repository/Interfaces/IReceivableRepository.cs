using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.Domain.Repository.Interfaces
{
    public interface IReceivableRepository : IRepository<Receivable, long>
    {
        Task<IEnumerable<Receivable>> GetByUserId(long userId);
    }
}
using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.Domain.Repository.Interfaces
{
    public interface ITransactionCategoryRepository : IRepository<TransactionCategory, long>
    {
        Task<IEnumerable<TransactionCategory>> GetByUserId(long userId);
    }
}
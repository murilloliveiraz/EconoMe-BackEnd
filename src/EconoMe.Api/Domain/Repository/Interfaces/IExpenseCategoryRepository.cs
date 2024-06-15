using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.Domain.Repository.Interfaces
{
    public interface IExpenseCategoryRepository : IRepository<ExpenseCategory, long>
    {
        Task<IEnumerable<ExpenseCategory>> GetByUserId(long userId);
    }
}
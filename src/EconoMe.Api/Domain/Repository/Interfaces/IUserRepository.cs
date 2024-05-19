using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.Domain.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<User?> GetByEmail(string email);
    }
}
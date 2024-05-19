using EconoMe.Api.Data.Contexts;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Domain.Repository.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context){
            _context = context;
        }

        public async Task<User> Create(User model)
        {
            await _context.User.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(User model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User?>> Get()
        {
            return await _context.User.AsNoTracking()
            .OrderBy(u => u.Id)
            .ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.User.AsNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User?> GetById(long id)
        {
             return await _context.User.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Update(User model)
        {
            User userAtDatabase = await _context.User.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

            _context.Entry(userAtDatabase).CurrentValues.SetValues(model);
            _context.Update<User>(userAtDatabase);

            await _context.SaveChangesAsync();
            return userAtDatabase;
        }
    }
}
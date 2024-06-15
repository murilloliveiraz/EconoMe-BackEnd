using EconoMe.Api.Data.Contexts;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Domain.Repository.Class
{
    public class TransactionCategoryRepository : ITransactionCategoryRepository
    {
        private readonly ApplicationContext _context;

        public TransactionCategoryRepository(ApplicationContext context)
        {
            _context = context;
        } 
        public async Task<TransactionCategory> Create(TransactionCategory model)
        {
            await _context.TransactionCategory.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(TransactionCategory model)
        {
            model.InactivationDate = DateTime.Now;
            await Update(model);
        }

        public async Task<IEnumerable<TransactionCategory?>> Get()
        {
            return await _context.TransactionCategory.AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();
        }

        public async Task<TransactionCategory?> GetById(long id)
        {
            return await _context.TransactionCategory.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TransactionCategory>> GetByUserId(long userId)
        {
            return await _context.TransactionCategory.AsNoTracking().Where(e=> e.UserId == userId)
                                                                .OrderBy(e => e.Id)
                                                                .ToListAsync();
        }

        public async Task<TransactionCategory> Update(TransactionCategory model)
        {
            TransactionCategory expenseAtDatabase = await _context.TransactionCategory.Where(e => e.Id == model.Id).FirstOrDefaultAsync();

            _context.Entry(expenseAtDatabase).CurrentValues.SetValues(model);
            _context.Update<TransactionCategory>(expenseAtDatabase);

            await _context.SaveChangesAsync();
            return expenseAtDatabase;
        }
    }
}
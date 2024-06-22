using EconoMe.Api.Data.Contexts;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Domain.Repository.Class
{
    public class ReceivableRepository : IReceivableRepository
    {
        private readonly ApplicationContext _context;

        public ReceivableRepository(ApplicationContext context)
        {
            _context = context;
        } 
        public async Task<Receivable> Create(Receivable model)
        {
            await _context.Receivable.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(Receivable model)
        {
            model.InactivationDate = DateTime.Now;
            await Update(model);
        }

        public async Task<IEnumerable<Receivable?>> Get()
        {
            return await _context.Receivable.AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();
        }

        public async Task<Receivable?> GetById(long id)
        {
            return await _context.Receivable.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Receivable>> GetByUserId(long userId)
        {
            return await _context.Receivable.AsNoTracking().Where(e=> e.UserId == userId)
                                                                .OrderBy(e => e.Id)
                                                                .ToListAsync();
        }

        public async Task<Receivable> Update(Receivable model)
        {
            Receivable ReceivableAtDatabase = await _context.Receivable.Where(e => e.Id == model.Id).FirstOrDefaultAsync();

            _context.Entry(ReceivableAtDatabase).CurrentValues.SetValues(model);
            _context.Update<Receivable>(ReceivableAtDatabase);

            await _context.SaveChangesAsync();
            return ReceivableAtDatabase;
        }
    }
}
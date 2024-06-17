using EconoMe.Api.Data.Contexts;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Domain.Repository.Class
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationContext _context;

        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        } 
        public async Task<Payment> Create(Payment model)
        {
            await _context.Payment.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(Payment model)
        {
            model.InactivationDate = DateTime.Now;
            await Update(model);
        }

        public async Task<IEnumerable<Payment?>> Get()
        {
            return await _context.Payment.AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();
        }

        public async Task<Payment?> GetById(long id)
        {
            return await _context.Payment.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetByUserId(long userId)
        {
            return await _context.Payment.AsNoTracking().Where(e=> e.UserId == userId)
                                                                .OrderBy(e => e.Id)
                                                                .ToListAsync();
        }

        public async Task<Payment> Update(Payment model)
        {
            Payment paymentAtDatabase = await _context.Payment.Where(e => e.Id == model.Id).FirstOrDefaultAsync();

            _context.Entry(paymentAtDatabase).CurrentValues.SetValues(model);
            _context.Update<Payment>(paymentAtDatabase);

            await _context.SaveChangesAsync();
            return paymentAtDatabase;
        }
    }
}
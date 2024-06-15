using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoMe.Api.Data.Contexts;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Domain.Repository.Class
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly ApplicationContext _context;

        public ExpenseCategoryRepository(ApplicationContext context)
        {
            _context = context;
        } 
        public async Task<ExpenseCategory> Create(ExpenseCategory model)
        {
            await _context.ExpenseCategory.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(ExpenseCategory model)
        {
            model.InactivationDate = DateTime.Now;
            await Update(model);
        }

        public async Task<IEnumerable<ExpenseCategory?>> Get()
        {
            return await _context.ExpenseCategory.AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();
        }

        public async Task<ExpenseCategory?> GetById(long id)
        {
            return await _context.ExpenseCategory.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ExpenseCategory>> GetByUserId(long userId)
        {
            return await _context.ExpenseCategory.AsNoTracking().Where(e=> e.UserId == userId)
                                                                .OrderBy(e => e.Id)
                                                                .ToListAsync();
        }

        public async Task<ExpenseCategory> Update(ExpenseCategory model)
        {
            ExpenseCategory expenseAtDatabase = await _context.ExpenseCategory.Where(e => e.Id == model.Id).FirstOrDefaultAsync();

            _context.Entry(expenseAtDatabase).CurrentValues.SetValues(model);
            _context.Update<ExpenseCategory>(expenseAtDatabase);

            await _context.SaveChangesAsync();
            return expenseAtDatabase;
        }
    }
}
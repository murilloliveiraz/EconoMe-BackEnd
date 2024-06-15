using AutoMapper;
using EconoMe.Api.Contracts.ExpenseCategory;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using EconoMe.Api.Domain.Services.Interfaces;

namespace EconoMe.Api.Domain.Services.Class
{
    public class ExpenseCategoryService : IService<ExpenseCategoryRequestContract, ExpenseCategoryResponseContract, long>
    {
        private readonly IExpenseCategoryRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseCategoryService(IMapper mapper, IExpenseCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ExpenseCategoryResponseContract> Create(ExpenseCategoryRequestContract model, long idUser)
        {
            ExpenseCategory expenseCategory = _mapper.Map<ExpenseCategory>(model);
            expenseCategory.RegistrationDate = DateTime.Now;
            expenseCategory.UserId = idUser;
            expenseCategory = await _repository.Create(expenseCategory);
            return _mapper.Map<ExpenseCategoryResponseContract>(expenseCategory);
        }

        public async Task Delete(long id, long idUser)
        {
            ExpenseCategory expenseCategory = await GetExpenseCategoryByUserId(id, idUser);
            await _repository.Delete(_mapper.Map<ExpenseCategory>(expenseCategory));
        }

        public async Task<IEnumerable<ExpenseCategoryResponseContract>> Get(long idUser)
        {
            var expenseCategories = await _repository.GetByUserId(idUser);
            return expenseCategories.Select(e => _mapper.Map<ExpenseCategoryResponseContract>(e));
        }

        public async Task<ExpenseCategoryResponseContract> GetById(long id, long idUser)
        {
            var expenseCategory = await GetExpenseCategoryByUserId(id, idUser);
            return _mapper.Map<ExpenseCategoryResponseContract>(expenseCategory);
        }

        public async Task<ExpenseCategoryResponseContract> Update(long id, ExpenseCategoryRequestContract model, long idUser)
        {
            ExpenseCategory expenseCategory = await GetExpenseCategoryByUserId(id, idUser);
            expenseCategory.UserId = idUser;
            expenseCategory.Description = model.Description;
            expenseCategory.Note = model.Note;
            expenseCategory = await _repository.Update(expenseCategory);
            return _mapper.Map<ExpenseCategoryResponseContract>(expenseCategory);
        }

        private async Task<ExpenseCategory> GetExpenseCategoryByUserId(long id, long userId)
        {
            var expenseCategory = await _repository.GetById(id);
            if (expenseCategory is null || expenseCategory.UserId != userId)
            {
                throw new Exception("Categoria de despesa não encontrada");
            }
            return expenseCategory;
        }
    }
}
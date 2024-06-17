using AutoMapper;
using EconoMe.Api.Contracts.TransactionCategory;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using EconoMe.Api.Domain.Services.Interfaces;

namespace EconoMe.Api.Domain.Services.Class
{
    public class TransactionCategoryService : IService<TransactionCategoryRequestContract, TransactionCategoryResponseContract, long>
    {
        private readonly ITransactionCategoryRepository _repository;
        private readonly IMapper _mapper;

        public TransactionCategoryService(IMapper mapper, ITransactionCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TransactionCategoryResponseContract> Create(TransactionCategoryRequestContract model, long idUser)
        {
            TransactionCategory transaction = _mapper.Map<TransactionCategory>(model);
            transaction.RegistrationDate = DateTime.Now;
            transaction.UserId = idUser;
            transaction = await _repository.Create(transaction);
            return _mapper.Map<TransactionCategoryResponseContract>(transaction);
        }

        public async Task Delete(long id, long idUser)
        {
            TransactionCategory transaction = await GetTransactionCategoryByUserId(id, idUser);
            await _repository.Delete(_mapper.Map<TransactionCategory>(transaction));
        }

        public async Task<IEnumerable<TransactionCategoryResponseContract>> Get(long idUser)
        {
            var transactions = await _repository.GetByUserId(idUser);
            return transactions.Select(e => _mapper.Map<TransactionCategoryResponseContract>(e));
        }

        public async Task<TransactionCategoryResponseContract> GetById(long id, long idUser)
        {
            var transaction = await GetTransactionCategoryByUserId(id, idUser);
            return _mapper.Map<TransactionCategoryResponseContract>(transaction);
        }

        public async Task<TransactionCategoryResponseContract> Update(long id, TransactionCategoryRequestContract model, long idUser)
        {
            TransactionCategory transaction = await GetTransactionCategoryByUserId(id, idUser);
            transaction.UserId = idUser;
            transaction.Description = model.Description;
            transaction.Note = model.Note;
            transaction = await _repository.Update(transaction);
            return _mapper.Map<TransactionCategoryResponseContract>(transaction);
        }

        private async Task<TransactionCategory> GetTransactionCategoryByUserId(long id, long userId)
        {
            var transaction = await _repository.GetById(id);
            if (transaction is null || transaction.UserId != userId)
            {
                throw new Exception("Categoria de transação não encontrada");
            }
            return transaction;
        }
    }
}
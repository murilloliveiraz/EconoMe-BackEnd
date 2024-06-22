using AutoMapper;
using EconoMe.Api.Contracts.Receivable;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using EconoMe.Api.Domain.Services.Interfaces;
using EconoMe.Api.Exceptions;

namespace EconoMe.Api.Domain.Services.Class
{
    public class ReceivableService : IService<ReceivableRequestContract, ReceivableResponseContract, long>
    {
        private readonly IReceivableRepository _repository;
        private readonly IMapper _mapper;

        public ReceivableService(IMapper mapper, IReceivableRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReceivableResponseContract> Create(ReceivableRequestContract model, long idUser)
        {
            Validate(model);
            Receivable receivable = _mapper.Map<Receivable>(model);
            receivable.RegistrationDate = DateTime.Now;
            receivable.UserId = idUser;
            receivable = await _repository.Create(receivable);
            return _mapper.Map<ReceivableResponseContract>(receivable);
        }

        public async Task Delete(long id, long idUser)
        {
            Receivable receivable = await GetReceivableByUserId(id, idUser);
            await _repository.Delete(_mapper.Map<Receivable>(receivable));
        }

        public async Task<IEnumerable<ReceivableResponseContract>> Get(long idUser)
        {
            var receivables = await _repository.GetByUserId(idUser);
            return receivables.Select(e => _mapper.Map<ReceivableResponseContract>(e));
        }

        public async Task<ReceivableResponseContract> GetById(long id, long idUser)
        {
            var receivable = await GetReceivableByUserId(id, idUser);
            return _mapper.Map<ReceivableResponseContract>(receivable);
        }

        public async Task<ReceivableResponseContract> Update(long id, ReceivableRequestContract model, long idUser)
        {
            Validate(model);
            Receivable receivable = await GetReceivableByUserId(id, idUser);
            var receivableContract = _mapper.Map<Receivable>(model);
            receivableContract.UserId = receivable.UserId;
            receivableContract.Id = receivable.Id;
            receivableContract.RegistrationDate = receivable.RegistrationDate;

            receivableContract = await _repository.Update(receivableContract);
            return _mapper.Map<ReceivableResponseContract>(receivableContract);
        }

        private async Task<Receivable> GetReceivableByUserId(long id, long userId)
        {
            var receivable = await _repository.GetById(id);
            if (receivable is null || receivable.UserId != userId)
            {
                throw new NotFoundException("Categoria de transação não encontrada");
            }
            return receivable;
        }

        private void Validate(ReceivableRequestContract model)
        {
            if (model.OriginalAmount < 0 || model.AmountReceived < 0)
            {
                throw new BadRequestException("Os valores originais e pagos não podem ser negativos.");
            }
        }
    }
}
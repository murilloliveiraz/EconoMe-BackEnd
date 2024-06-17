using AutoMapper;
using EconoMe.Api.Contracts.Payment;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using EconoMe.Api.Domain.Services.Interfaces;

namespace EconoMe.Api.Domain.Services.Class
{
    public class PaymentService : IService<PaymentRequestContract, PaymentResponseContract, long>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IMapper mapper, IPaymentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaymentResponseContract> Create(PaymentRequestContract model, long idUser)
        {
            Payment payment = _mapper.Map<Payment>(model);
            payment.RegistrationDate = DateTime.Now;
            payment.UserId = idUser;
            payment = await _repository.Create(payment);
            return _mapper.Map<PaymentResponseContract>(payment);
        }

        public async Task Delete(long id, long idUser)
        {
            Payment payment = await GetPaymentByUserId(id, idUser);
            await _repository.Delete(_mapper.Map<Payment>(payment));
        }

        public async Task<IEnumerable<PaymentResponseContract>> Get(long idUser)
        {
            var payments = await _repository.GetByUserId(idUser);
            return payments.Select(e => _mapper.Map<PaymentResponseContract>(e));
        }

        public async Task<PaymentResponseContract> GetById(long id, long idUser)
        {
            var payment = await GetPaymentByUserId(id, idUser);
            return _mapper.Map<PaymentResponseContract>(payment);
        }

        public async Task<PaymentResponseContract> Update(long id, PaymentRequestContract model, long idUser)
        {
            Payment payment = await GetPaymentByUserId(id, idUser);

            var paymentContract = _mapper.Map<Payment>(model);
            paymentContract.UserId = payment.UserId;
            paymentContract.Id = payment.Id;
            paymentContract.RegistrationDate = payment.RegistrationDate;

            paymentContract = await _repository.Update(paymentContract);
            return _mapper.Map<PaymentResponseContract>(paymentContract);
        }

        private async Task<Payment> GetPaymentByUserId(long id, long userId)
        {
            var payment = await _repository.GetById(id);
            if (payment is null || payment.UserId != userId)
            {
                throw new Exception("Categoria de transação não encontrada");
            }
            return payment;
        }
    }
}
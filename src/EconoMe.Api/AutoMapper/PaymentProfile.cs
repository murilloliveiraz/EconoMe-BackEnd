using AutoMapper;
using EconoMe.Api.Contracts.Payment;
using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.AutoMapper
{
    public class PaymentProfile: Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentRequestContract>().ReverseMap();
            CreateMap<Payment, PaymentResponseContract>().ReverseMap();
        }
    }
}
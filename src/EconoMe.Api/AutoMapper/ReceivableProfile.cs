using AutoMapper;
using EconoMe.Api.Contracts.Receivable;
using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.AutoMapper
{
    public class ReceivableProfile: Profile
    {
        public ReceivableProfile()
        {
            CreateMap<Receivable, ReceivableRequestContract>().ReverseMap();
            CreateMap<Receivable, ReceivableResponseContract>().ReverseMap();
        }
    }
}
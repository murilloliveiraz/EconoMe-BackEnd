using AutoMapper;
using EconoMe.Api.Contracts.TransactionCategory;
using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.AutoMapper
{
    public class TransactionCategoryProfile: Profile
    {
        public TransactionCategoryProfile()
        {
            CreateMap<TransactionCategory, TransactionCategoryRequestContract>().ReverseMap();
            CreateMap<TransactionCategory, TransactionCategoryResponseContract>().ReverseMap();
        }
    }
}
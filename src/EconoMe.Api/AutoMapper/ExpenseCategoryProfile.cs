using AutoMapper;
using EconoMe.Api.Contracts.ExpenseCategory;
using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.AutoMapper
{
    public class ExpenseCategoryProfile: Profile
    {
        public ExpenseCategoryProfile()
        {
            CreateMap<ExpenseCategory, ExpenseCategoryRequestContract>().ReverseMap();
            CreateMap<ExpenseCategory, ExpenseCategoryResponseContract>().ReverseMap();
        }
    }
}
using AutoMapper;
using EconoMe.Api.Contracts.User;
using EconoMe.Api.Domain.Models;

namespace EconoMe.Api.AutoMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRequestContract>().ReverseMap();
            CreateMap<User, UserResponseContract>().ReverseMap();
        }
    }
}
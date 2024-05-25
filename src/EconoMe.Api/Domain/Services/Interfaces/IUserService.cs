using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoMe.Api.Contracts.User;

namespace EconoMe.Api.Domain.Services.Interfaces
{
    public interface IUserService : IService<UserRequestContract, UserResponseContract, long>
    {
        Task<UserLoginResponseContract> Authenticate(UserLoginRequestContract user);
        Task<UserResponseContract> GetByEmail(string email);
    }
}
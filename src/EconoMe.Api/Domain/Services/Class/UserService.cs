using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EconoMe.Api.Contracts.User;
using EconoMe.Api.Domain.Models;
using EconoMe.Api.Domain.Repository.Interfaces;
using EconoMe.Api.Domain.Services.Interfaces;

namespace EconoMe.Api.Domain.Services.Class
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Task<UserLoginResponseContract> Authenticate(UserLoginRequestContract user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseContract> Create(UserRequestContract model, long idUser)
        {
            var user = _mapper.Map<User>(model);
            user.Password = CreatePasswordHash(user.Password);
            user = await _userRepository.Create(user);
            return _mapper.Map<UserResponseContract>(user);
        }

        private string CreatePasswordHash(string password)
        {
            string passwordHash;

            using(SHA256 sha256 = SHA256.Create())
            {
               byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
               byte[] passowrdHashBytes = sha256.ComputeHash(passwordBytes);
               passwordHash = BitConverter.ToString(passowrdHashBytes).ToLower();
            }

            return passwordHash;
        }

        public Task Delete(long id, long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseContract>> Get(long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseContract> GetById(long id, long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseContract> Update(long id, UserRequestContract model, long idUser)
        {
            throw new NotImplementedException();
        }
    }
}
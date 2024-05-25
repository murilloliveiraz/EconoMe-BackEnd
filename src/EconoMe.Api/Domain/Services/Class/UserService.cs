using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;
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
        private readonly TokenService _tokenService;

        public UserService(IUserRepository userRepository, IMapper mapper, TokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<UserLoginResponseContract> Authenticate(UserLoginRequestContract userRequest)
        {
            UserResponseContract user = await GetByEmail(userRequest.Email);
            var passwordHash = CreatePasswordHash(userRequest.Password);

            if(user == null ||  user.Password != passwordHash)
            {
                throw new AuthenticationException("Usuário ou senha inválida");
            }

            return new UserLoginResponseContract{
                Id = user.Id,
                Email = user.Email,
                Token = _tokenService.GenerateToken(_mapper.Map<User>(user))
            };
        }

        public async Task<UserResponseContract> Create(UserRequestContract model, long idUser)
        {
            var user = _mapper.Map<User>(model);
            user.Password = CreatePasswordHash(user.Password);
            user.RegistrationDate = DateTime.Now;
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
               passwordHash = BitConverter.ToString(passowrdHashBytes).Replace("-","").ToLower();
            }

            return passwordHash;
        }

        public async Task Delete(long id, long idUser)
        {
             var user = await _userRepository.GetById(id) ?? throw new Exception("Usuário não encontrado");
             await _userRepository.Delete(_mapper.Map<User>(user));
        }

        public async Task<IEnumerable<UserResponseContract>> Get(long idUser)
        {
            var users = await _userRepository.Get();
            return users.Select(user => _mapper.Map<UserResponseContract>(user));
        }

        public async Task<UserResponseContract> GetById(long id, long idUser)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserResponseContract>(user);
        }

        public async Task<UserResponseContract> Update(long id, UserRequestContract model, long idUser)
        {
            _ = await Get(id) ?? throw new Exception("Usiário não encontrado"); 

            var user = _mapper.Map<User>(model);
            user.Id = id;
            user.Password = CreatePasswordHash(model.Password);

            user = await _userRepository.Update(user);
            return _mapper.Map<UserResponseContract>(user);
        }

        public async Task<UserResponseContract> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserResponseContract>(user);
        }
    }
}
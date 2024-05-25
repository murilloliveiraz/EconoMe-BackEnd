using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EconoMe.Api.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace EconoMe.Api.Domain.Services.Class
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["KeySecret"]);

            var tokenDescriptor =  new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim( ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim( ClaimTypes.Email, user.Email),
                }),

                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["TimeTokenIsValid"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
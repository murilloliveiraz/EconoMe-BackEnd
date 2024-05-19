using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EconoMe.Api.Contracts.User
{
    public class UserResponseContract : UserRequestContract 
    {
        public long Id { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
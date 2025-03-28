using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using LoginAuth.Entities.DTO;
using LoginAuth.Entities.Models;
using LoginAuth.Service.IService;

namespace LoginAuth.Service.ServiceImplementation
{
    public class UsersServices : IUsersServices
    {
        public List<Users> Register(UsersDTO request)
        {

            var hashPassword = new PasswordHasher<Users>()
            .HashPassword(user, request.Password);

            user.UserName = request.UserName;
                user.PasswordHash = hashPassword;

            return Ok(user);
        }
    }
}

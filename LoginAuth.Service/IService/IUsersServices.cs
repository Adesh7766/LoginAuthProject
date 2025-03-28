using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAuth.Entities.DTO;
using LoginAuth.Entities.Models;

namespace LoginAuth.Service.IService
{
    public interface IUsersServices
    {
        List<Users> Register(UsersDTO request);
    }
}

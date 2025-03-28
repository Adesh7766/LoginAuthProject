using System;
using LoginAuth.Entities.DTO;
using LoginAuth.Entities.Models;
using LoginAuth.Entities.Common;

namespace LoginAuth.DAL.IRepository
{
    public interface IUsersRepo
    {
        string Register(Users user);

        ResponseData Login(UsersDTO request);
    }
}

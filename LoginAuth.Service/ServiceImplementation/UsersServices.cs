using LoginAuth.Entities.DTO;
using Microsoft.AspNetCore.Identity;
using LoginAuth.Entities.Models;
using LoginAuth.Service.IService;
using LoginAuth.DAL.IRepository;
using LoginAuth.Entities.Common;

namespace LoginAuth.Service.ServiceImplementation
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepo _repo;

        public UsersServices(IUsersRepo repo)
        {
            _repo = repo;
        }

        public string Register(UsersDTO request)
        {
            Users user = new Users();

            var hashPassword = new PasswordHasher<Users>()
            .HashPassword(user, request.Password);

            user.UserName = request.UserName;
                user.PasswordHash = hashPassword;

            string message = _repo.Register(user);

            return message;
        }

        public ResponseData Login(UsersDTO request)
        {
            ResponseData message = _repo.Login(request);

            return message;
        }
    }
}

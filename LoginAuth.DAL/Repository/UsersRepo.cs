using LoginAuth.DAL.AppDbContext;
using LoginAuth.DAL.IRepository;
using LoginAuth.Entities.Common;
using LoginAuth.Entities.DTO;
using LoginAuth.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginAuth.DAL.Repository
{
    public class UsersRepo : IUsersRepo
    {
        private readonly ApplicationDbContext _context;

        public UsersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Register(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return "User registered successfully";
        }

        public ResponseData Login(UsersDTO request)
        {
            Users? user = new Users();

            user = _context.Users.Where(x => x.UserName == request.UserName).FirstOrDefault();

            if(user == null)
            {
                return new ResponseData
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            if (new PasswordHasher<Users>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {

                return new ResponseData
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            return new ResponseData
            {
                Success = true,
                Message = "Logged in successfully",
                Data = user
            };
        }
    }
}

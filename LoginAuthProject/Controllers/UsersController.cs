using LoginAuth.Entities.DTO;
using LoginAuth.Entities.Models;
using LoginAuth.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuthProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : AuthController
    {
        private readonly IUsersServices _userService;

        public UsersController(IConfiguration configuration, IUsersServices userService): base(configuration) 
        {
            _userService = userService;
        }

        Users user = new Users()
        {
            UserName = "Ram123",
            PasswordHash = "randommpw"
        };

        [HttpPost("Register")]
        public ActionResult<Users> Register(UsersDTO request)
        {
            _userService.Register(request);

            return Ok(user);
        }

        [HttpPost("Login")]
        public ActionResult<string> Login(UsersDTO request)
        {
            if(user.UserName != request.UserName)
            {
                return BadRequest("User not found.");
            }

            if (new PasswordHasher<Users>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Password not matched.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

            

    }
}

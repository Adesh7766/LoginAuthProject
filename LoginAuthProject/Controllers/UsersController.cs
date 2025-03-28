using LoginAuth.Entities.Common;
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

        [HttpPost("Register")]
        public ActionResult<Users> Register(UsersDTO request)
        {
            var message = _userService.Register(request);

            return Ok(message);
        }

        [HttpPost("Login")]
        public ActionResult<string> Login(UsersDTO request)
        {
            ResponseData data  = _userService.Login(request);

            string token = CreateToken(data.Data);

            return Ok(token);
        }



    }
}

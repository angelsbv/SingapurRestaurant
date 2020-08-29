using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using server.Models;
using server.Services;

namespace server.Controllers
{

    [Route("/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register(User newUser)
        {
            newUser = await _userService.Register(newUser);
            return newUser;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(AuthRequest authReq)
        {
            var cookieOptions = new CookieOptions
            {
                Path = "/",
                Secure = false,
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                IsEssential = true
            };

            var okOrFail = (await _userService.Authenticate(authReq));
            var isString = (okOrFail is string);

            if(isString){
                Response.Cookies.Append("sr-session", isString ? okOrFail : "FAIL", cookieOptions);
            }
            
            return Content(isString ? "OK" : "FAIL");
        }
    }
}
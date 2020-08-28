using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using server.Models;
using server.Services;

namespace server.Controllers {

    [Route("/user")]
    [ApiController]
    public class UsersController : ControllerBase {

        private readonly UserService _userService;

        public UsersController(UserService userService)
        {   
            _userService = userService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register(User newUser){
            newUser = await _userService.Register(newUser);
            return newUser;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(AuthRequest authReq){
            var isAuthenticated = (await _userService.Authenticate(authReq));
            return Content(isAuthenticated ? "OK" : "FAIL"); 
        }
    }
}
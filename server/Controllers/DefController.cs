using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using server.Services;

namespace server.Controllers {

    [Route("/")]
    [ApiController]
    public class DefController : ControllerBase {

        private readonly UserService _userService;

        public DefController(UserService userService)
        {   
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Test(){
            return Content("up");
        }
    }
}
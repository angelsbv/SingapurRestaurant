using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace server.Controllers {

    [Route("api/")]
    [ApiController]
    public class DefController : ControllerBase {

        [HttpGet]
        public ActionResult Test(){
            return Content("up");
        }
    }
}
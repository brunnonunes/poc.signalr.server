using Microsoft.AspNetCore.Mvc;

namespace poc.signalr.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        public IActionResult Post() {
            return Ok();
        }
    }
}
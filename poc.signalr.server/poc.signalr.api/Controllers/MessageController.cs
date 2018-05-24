using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using poc.signalr.api.Hubs;

namespace poc.signalr.api.Controllers {

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : Controller {
        private IHubContext<ChatHub> _chatHubContext;

        public MessageController(IHubContext<ChatHub> chatHubContext) {
            this._chatHubContext = chatHubContext;
        }

        [HttpPost]
        [Route("receive")]
        public IActionResult ReceiveMessage() {
            _chatHubContext.Clients.All.SendAsync("ReceiveMessage", "Kevin", "Hello from the server!");
            return Ok();
        }

        [HttpPost]
        [Route("receivesimple")]
        public IActionResult ReceiveSimpleMessage() {
            _chatHubContext.Clients.All.SendAsync("ReceiveSimpleMessage", "Hello from the server!");
            return Ok();
        }
    }
}
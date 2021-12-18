using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private IHubContext<CommunicationHub> _communicationHub;

        public TestController(IHubContext<CommunicationHub> communicationHub)
        {
            _communicationHub = communicationHub;
        }

        [HttpPost]
        public async Task SendMessageToAllAsync([FromBody]string message)
        {
            await _communicationHub.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}

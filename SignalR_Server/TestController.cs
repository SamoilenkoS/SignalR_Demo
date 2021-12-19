using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private IHubContext<CommunicationHub, IClientHub> _communicationHub;

        public TestController(IHubContext<CommunicationHub, IClientHub> communicationHub)
        {
            _communicationHub = communicationHub;
        }

        [HttpPost]
        public async Task SendMessageToAllAsync([FromBody]string message)
        {
          //  await _communicationHub.Clients.All.SendAsync("ReceiveMessage", message);
        }

        [HttpPost("/specific")]
        public async Task SendMessageToSpecific(string clientId, string message)
        {
            await _communicationHub.Clients.Client(clientId).ReceiveMessage(message);
        }
    }
}

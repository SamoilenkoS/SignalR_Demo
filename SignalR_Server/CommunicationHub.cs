using Microsoft.AspNetCore.SignalR;
using SignalR_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Server
{
    public class CommunicationHub : Hub<IClientHub>, ICommunicationHub
    {
        private readonly string _testGroupName = nameof(_testGroupName);

        public CommunicationHub()
        {
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, _testGroupName);
            await Clients.Caller.ReceiveMessage($"Your id: {Context.ConnectionId}");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task<string> GetSomeInfoAsync(string infoKey)
        {
            int minLength = 5;
            int maxLength = 20;
            var random = new Random();
            var length = random.Next(minLength, maxLength);
            StringBuilder response = new StringBuilder(length, length);
            for (int i = 0; i < length; i++)
            {
                response.Append((char)random.Next('!', '}'));
            }

            return response.ToString();
        }

        public async Task SendMessageToAllExceptCaller(string message)
        {
            await Clients.Others.ReceiveMessage(message);
        }

        public async Task SendPersonalMessage(string targetId, string message)
        {
            await Clients.Client(targetId).ReceiveMessage(message);
        }

        public async Task SendMessageToGroup(string message)
        {
            await Clients.Group(_testGroupName).ReceiveMessage(message);
        }
    }
}

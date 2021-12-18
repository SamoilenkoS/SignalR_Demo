using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Server
{
    public class CommunicationHub : Hub
    {
        private Dictionary<string, User> Users;

        public CommunicationHub()
        {
            Users = new Dictionary<string, User>();
        }

        public override Task OnConnectedAsync()
        {
            Users.Add(Context.ConnectionId, new User());

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Users.Remove(Context.ConnectionId);

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
    }
}

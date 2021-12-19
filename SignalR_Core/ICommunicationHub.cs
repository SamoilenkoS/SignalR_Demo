using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Core
{
    public interface ICommunicationHub
    {
        Task SendPersonalMessage(string targetId, string message);
        Task SendMessageToAllExceptCaller(string message);
        Task<string> GetSomeInfoAsync(string infoKey);
    }
}

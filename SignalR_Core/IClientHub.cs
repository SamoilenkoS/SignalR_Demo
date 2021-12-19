using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Core
{
    public interface IClientHub
    {
        Task ReceiveMessage(string message);
    }
}

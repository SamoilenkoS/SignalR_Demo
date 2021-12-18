using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR_Net_Client
{
    class Program
    {
        static async Task Main()
        {
            HubConnection connection
               = new HubConnectionBuilder()
               .WithUrl("https://localhost:5001/communication")
               .Build();
            connection.On<string>("ReceiveMessage",
                (message) =>
                {
                    Console.WriteLine(message);
                });

            await connection.StartAsync();

            Console.ReadKey();
        }
    }
}

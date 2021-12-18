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

            await connection.StartAsync();
            do
            {
                var dataKey = "test";
                var info = await connection.InvokeAsync<string>("GetSomeInfoAsync", dataKey);
                Console.WriteLine(info);
                Console.ReadKey();
            } while (true);
        }
    }
}

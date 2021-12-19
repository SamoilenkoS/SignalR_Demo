using Microsoft.AspNetCore.SignalR.Client;
using SignalR_Core;
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
            connection.On<string>(nameof(IClientHub.ReceiveMessage),
                (message) =>
                {
                    Console.WriteLine(message);
                });

            await connection.StartAsync();

            int choise;
            do
            {
                Console.WriteLine(
                    $"1 - Get info{Environment.NewLine}" +
                    $"2 - Send to all except me{Environment.NewLine}" +
                    $"3 - Send personal message{Environment.NewLine}" +
                    $"4 - Send message to group{Environment.NewLine}" +
                    $"0 - Exit");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        var info = await connection.InvokeAsync<string>(
                            nameof(ICommunicationHub.GetSomeInfoAsync),"Test");
                        Console.WriteLine(info);
                        break;
                    case 2:
                        Console.Write("Enter your message:");
                        var message = Console.ReadLine();
                        await connection.InvokeAsync(
                            nameof(ICommunicationHub.SendMessageToAllExceptCaller),
                            message);
                        break;
                    case 3:
                        Console.Write("Enter target id:");
                        var targetId = Console.ReadLine();
                        Console.Write("Enter message:");
                        message = Console.ReadLine();
                        await connection.InvokeAsync(
                            nameof(ICommunicationHub.SendPersonalMessage),
                            targetId,
                            message);
                        break;
                    case 4:
                        Console.Write("Enter message:");
                        message = Console.ReadLine();
                        await connection.InvokeAsync(
                            nameof(ICommunicationHub.SendMessageToGroup),
                            message);
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (choise != 0);
        }
    }
}

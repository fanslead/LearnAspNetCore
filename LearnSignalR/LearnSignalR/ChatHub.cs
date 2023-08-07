using Microsoft.AspNetCore.SignalR;

namespace LearnSignalR
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} Connected");
            await Clients.Caller.SendAsync("ReceiveMessage", "System", "Hello");
        }
    }
}

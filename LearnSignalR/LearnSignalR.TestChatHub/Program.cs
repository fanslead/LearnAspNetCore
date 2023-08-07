using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5192/chat")
    .Build();

connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    var newMessage = $"{user}: {message}";
    Console.WriteLine($"{DateTime.Now}---{newMessage}");
});
await connection.StartAsync();
Console.WriteLine("SetName:");
var userName = Console.ReadLine();
while (true)
{
    Console.WriteLine("Message:");
    var message = Console.ReadLine();
    await connection.InvokeAsync("SendMessage", userName, message);
}

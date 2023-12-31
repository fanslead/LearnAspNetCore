using LearnSignalR;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<ChatHub>("/chat");

app.MapGet("/", () => "Hello World!");

app.Run();

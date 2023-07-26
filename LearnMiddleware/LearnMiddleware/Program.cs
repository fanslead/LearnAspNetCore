using LearnMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FactoryMiddleware>();
builder.Services.AddScoped<TestMiddlewareDi>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.Request.Headers.Add("TestMiddlewareAdd", "Abc");
    await next.Invoke();
});
app.UseMiddleware<AMiddleware>();
app.UseMiddleware<FactoryMiddleware>();
app.MapControllers();

app.Run();

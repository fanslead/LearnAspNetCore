using LearnDI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TestSingleton>();
builder.Services.AddScoped<TestScoped>();
builder.Services.AddTransient<TestTransient>();
builder.Services.AddScoped<IScopedDependency, TestAbcScoped>();
builder.Services.AddScoped<IScopedDependency, TestAbcdScoped>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.Use(async (httpContext, next) => 
{
    var scoped = httpContext.RequestServices.GetRequiredService<TestScoped>();
    var transient = httpContext.RequestServices.GetRequiredService<TestTransient>();
    Console.WriteLine($"Middleware scoped: {scoped.Id}");
    Console.WriteLine($"Middleware transient: {transient.Id}");
    await next(httpContext);
});

app.MapControllers();

app.Run();

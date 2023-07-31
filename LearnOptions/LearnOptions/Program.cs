using LearnOptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MyOptions>(builder.Configuration.GetSection("MyOptions"));
builder.Services.Configure<MyOptions>("Abcd",builder.Configuration.GetSection("MyOptions"));

builder.Services.AddOptions<MyOptions>("OptionsBuilderOptions")
    .Configure(o => 
    {
        o.Option1 = "OptionsBuilderOptions"; 
        o.Option2 = 999; 
    })
    ;
builder.Services.AddOptions<MyOptions>("ValidateOptions")
    .Configure(o =>
    {
        o.Option1 = null;
        o.Option2 = 999;
    })
    ;
builder.Services.AddSingleton<IValidateOptions
                              <MyOptions>, MyOptionsValidateOptions>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

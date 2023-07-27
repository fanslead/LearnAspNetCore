var builder = WebApplication.CreateBuilder(args);
var dict = new Dictionary<string, string>
        {
           {"TestMemoryKey", "Memory"},
        };

builder.Configuration.AddInMemoryCollection(dict);

builder.Configuration.AddIniFile("appsettings.ini");
builder.Configuration.AddXmlFile("appsettings.xml");
// Add services to the container.

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

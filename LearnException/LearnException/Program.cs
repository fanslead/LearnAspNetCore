using LearnException;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//app.UseExceptionHandler("/Home/Error");

//app.UseExceptionHandler(exceptionHandlerApp =>
//{
//    exceptionHandlerApp.Run(async context =>
//    {
//        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

//        // using static System.Net.Mime.MediaTypeNames;
//        context.Response.ContentType = Text.Plain;

//        await context.Response.WriteAsync("An exception was thrown.");

//        var exceptionHandlerPathFeature =
//            context.Features.Get<IExceptionHandlerPathFeature>();

//        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
//        {
//            await context.Response.WriteAsync(" The file was not found.");
//        }

//        if (exceptionHandlerPathFeature?.Path == "/")
//        {
//            await context.Response.WriteAsync(" Page: Home.");
//        }
//    });
//});

//}
app.UseMiddleware<MyExceptionMiddleware>();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

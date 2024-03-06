using Microsoft.EntityFrameworkCore;
using to_do.Data;
using Microsoft.EntityFrameworkCore.Design;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddLogging(ConfigureLogging((hostingContext, logging) =>
//{
//    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
//    logging.AddConsole();
//    logging.AddDebug();
//    logging.AddEventSourceLogger();
//    // Enable NLog as one of the Logging Provider
//    logging.AddNLog();
//});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConn")
    ));

//builder.Services.AddLogging<NLog>(hostingContext, logging) =>
//{
//    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
//    logging.AddConsole();
//    logging.AddDebug();
//    logging.AddEventSourceLogger();
//    // Enable NLog as one of the Logging Provider
//    logging.AddNLog();
//});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseStatusCodePagesWithRedirects("/Error/{0}");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AppDbContext = MyDotnetWebApp.AppDbContext;
using MyDotnetWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Host=127.0.0.1;Port=5432;Database=mydb;Username=postgres;Password=example";

// Register the database context using PostgreSQL (via Npgsql)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add MVC services to the container (Controllers with Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Optional: configure middleware for error handling, static files, etc.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// Configure the default route for MVC.
// This tells ASP.NET Core to use the Home controller and its Index action by default.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

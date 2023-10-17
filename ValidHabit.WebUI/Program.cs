using ValidHabit.Application;
using ValidHabit.Infrastructure;
using ValidHabit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ValidHabit.Infrastructure.ServiceConfigurations;
using ValidHabit.Application.Interfaces;
using ValidHabit.Infrastructure.Services;
using ValidHabit.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LocalDbSqlServer") 
    ?? throw new InvalidOperationException("Connection string 'LocalDbSqlServer' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.DatabaseEnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
//app.UseMiddleware<RequireAuthenticationMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

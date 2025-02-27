using Angelina_ATM_Machine.Controllers;
using Angelina_ATM_Machine.DataAccess.Repositories;
using CRUDApps.DataAccess.EF.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables().Build();
builder.Services.AddDbContext<Angelina_ATM_MachineContext>(
    optionsAction =>
    {
        optionsAction.UseSqlServer(configuration.GetConnectionString(name: "MyConnectionString"));
    }
);

// Add scoped service in Program.cs
builder.Services.AddScoped<ClientRepository, ClientRepository>();
builder.Services.AddScoped<Angelina_ATM_MachineContext, Angelina_ATM_MachineContext>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

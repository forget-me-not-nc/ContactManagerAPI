using DAL.Settings;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CustomDbContext>(
      options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"),
      new MySqlServerVersion(new Version(8, 0, 28))
   ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.MapFallbackToFile("index.html"); ;

app.Run();

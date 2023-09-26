using DAL.Settings;
using Microsoft.EntityFrameworkCore;
using DAL.Repos.ContactInfoRepo;
using BLL.Configs.AutoMapper;
using BLL.Services.ValidatorService.ContactInfoValidator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CustomDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySQL"),
    new MySqlServerVersion(new Version(8, 0, 28)));
}, ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(p => p.AddProfile(new AutoMapperProfile()));

builder.Services.AddScoped<IContactInfoRepo, ContactInfoRepo>();
builder.Services.AddScoped<IContactInfoValidator, ContactInfoValidator>();

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

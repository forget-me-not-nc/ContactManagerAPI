using DAL.Settings;
using Microsoft.EntityFrameworkCore;
using DAL.Repos.ContactInfoRepo;
using BLL.Configs.AutoMapper;
using BLL.Services.ValidatorService.ContactInfoValidator;
using BLL.Services.ContactInfoServices;
using BLL.Services.ImportServices;
using BLL.Configs.Converter;

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
builder.Services.AddScoped<IContactInfoService, ContactInfoService>();
builder.Services.AddScoped<ICSVImporter, CSVImporter>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
    }); ;

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Redirect}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html");

app.Run();

using pos.Core;
using pos.Products;
using pos.Users;
using pos.Web.Services;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env}.json", true);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TenantConnection");
var isDevelopment = builder.Environment.IsDevelopment();

// register services
builder.Services
    .AddCoreServices(connectionString, !isDevelopment, !isDevelopment)
    .AddInternalServices(builder.Configuration)
    .AddProductServices()
    .AddUserServices()
    .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");


app.Run();
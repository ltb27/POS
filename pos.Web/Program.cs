using pos.Core.Settings;
using pos.Infrastructure;
using pos.Products;
using pos.Users;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env}.json", true);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TenantConnection");
var isDevelopment = builder.Environment.IsDevelopment();

// register services
builder.Services.AddProductServices()
    .AddDataServices(connectionString, !isDevelopment, !isDevelopment)
    .AddUserServices()
    .AddControllersWithViews();

// register options
builder.Services.Configure<TokenSettings>(
    builder.Configuration.GetSection("TokenSettings"));

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
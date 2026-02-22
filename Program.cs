using Auto.Interfaces;
using Auto.Repositories;
using Auto.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Repositories
builder.Services.AddSingleton<ICarRepository, InMemoryCarRepository>();
builder.Services.AddSingleton<ISaleRepository, InMemorySaleRepository>();

// Car services
builder.Services.AddSingleton<CarService>();
builder.Services.AddSingleton<ICarQueryService>(sp => sp.GetRequiredService<CarService>());
builder.Services.AddSingleton<ICarCommandService>(sp => sp.GetRequiredService<CarService>());

// Sale services
builder.Services.AddSingleton<SaleService>();
builder.Services.AddSingleton<SaleAnalyticsService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
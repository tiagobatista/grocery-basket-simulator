using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var host = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
})
.ConfigureServices((context, services) =>
{
    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddTransient<IItemRepository, ItemRepository>();
    services.AddTransient<IBasketService, BasketService>();
})
.Build();

var menu = new Menu(host.Services.GetRequiredService<IBasketService>());

menu.DisplayMenu();


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

var host = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
})
.ConfigureServices((context, services) =>
{
    // Register application services
    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddScoped<IItemRepository, ItemRepository>();
    services.AddTransient<IItemRepository, ItemRepository>();
    services.AddTransient<IBasketService, BasketService>();
})
.Build();


using DesignPatterns.ChainOfResponsibility.contexts;
using DesignPatterns.ChainOfResponsibility.datamanagers;
using DesignPatterns.ChainOfResponsibility.repositories;
using DesignPatterns.ChainOfResponsibility.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesignPatterns.ChainOfResponsibility.hosts
{
    internal class Container
    {
        public static IHost CreateHostBuilder()
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureServices((_, service) =>
                {
                    service.AddSingleton<PizzeriaContext>();
                    service.AddSingleton<DbManager>();
                    service.AddSingleton<OrderService>();
                    service.AddSingleton<ReceiptService>();
                    service.AddSingleton<OrderIngredientService>();
                    service.AddSingleton<OrderRepository>();
                    service.AddSingleton<ReceiptRepository>();
                    service.AddSingleton<OrderIngredientRepository>();
                }).Build();
        }
    }
}

using AsyncBreakfastMVC.DataAccess;
using AsyncBreakfastMVC.Tasks.Interfaces;
using AsyncBreakfastMVC.Tasks.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncBreakfastMVC
{
    public static class ServicesCollectionExtension
    {
        public static void AddApiServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IBreakfastRecipe, BreakfastRecipe>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<IOrderService, OrderService>();
            serviceCollection.AddTransient<IBreakfastService, BreakfastService>();
            serviceCollection.AddHostedService<KitchenHostService>();
            serviceCollection.AddSingleton<IBackgroundOrderTaskQueue, BackgroundOrderTaskQueue>(ctx =>
            {
                if (!int.TryParse(configuration["QueueCapacity"], out var queueCapacity))
                {
                    queueCapacity = 100;
                }

                return new BackgroundOrderTaskQueue(queueCapacity);
            });
        }
    }
}
using System;
using System.Threading.Tasks;
using AsyncBreakfastMVC.DataAccess;
using AsyncBreakfastMVC.Tasks.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AsyncBreakfastMVC.Tasks.Services;

public class BreakfastService : IBreakfastService
{
    private readonly IBreakfastRecipe _breakfastRecipe;
    private readonly ILogger<BreakfastService> _logger;
    private readonly IBackgroundOrderTaskQueue _backgroundOrderTaskQueue;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BreakfastService(IBreakfastRecipe breakfastRecipe, ILogger<BreakfastService> logger,
        IServiceScopeFactory serviceScopeFactory, IBackgroundOrderTaskQueue backgroundOrderTaskQueue)
    {
        _breakfastRecipe = breakfastRecipe;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        _backgroundOrderTaskQueue = backgroundOrderTaskQueue;
    }

    public async Task QueueBreakfastOrder(Guid orderId)
    {
        await _backgroundOrderTaskQueue.QueueBackgroundOrderWorkerItemAsync(async token =>
        {
            _logger.LogInformation("Start cooking...");

            try
            {
                var breakfast = await _breakfastRecipe.MakeBreakfastMultiThreadAsync();
                using var scope = _serviceScopeFactory.CreateScope();
                var scopeServices = scope.ServiceProvider;
                var unitOfWork = scopeServices.GetRequiredService<IUnitOfWork>();

                var order = await unitOfWork.OrderRepository.FirstOrDefaultAsync(orderId);
                order.Breakfast = breakfast;
                order.UpdatedAt = DateTime.Now;
                await unitOfWork.CommitAsync(token);
                _logger.LogInformation("End cooking...");
            }
            catch (Exception e)
            {
                _logger.LogError("{E.Message}", e.Message);
                throw;
            }
        });
    }
}
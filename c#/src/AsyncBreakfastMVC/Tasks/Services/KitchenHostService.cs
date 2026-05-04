using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Tasks.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AsyncBreakfastMVC.Tasks.Services;

public class KitchenHostService : BackgroundService
{
    private readonly ILogger<KitchenHostService> _logger;
    private readonly IBackgroundOrderTaskQueue _backgroundOrderTaskQueue;

    public KitchenHostService(ILogger<KitchenHostService> logger,
        IBackgroundOrderTaskQueue backgroundOrderTaskQueue)
    {
        _logger = logger;
        _backgroundOrderTaskQueue = backgroundOrderTaskQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Kitchen Hosted Service is running. {Environment.NewLine}", Environment.NewLine);

        await BackgroundProcessing(stoppingToken);
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem = await _backgroundOrderTaskQueue.DequeueAsync(stoppingToken);

            try
            {
                await workItem(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing {WorkItem}", nameof(workItem));
            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Kitchen Hosted Service is stopping");

        await base.StopAsync(stoppingToken);
    }
}
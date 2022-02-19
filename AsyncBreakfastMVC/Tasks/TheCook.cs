using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace AsyncBreakfastMVC.Tasks
{
    public class TheCook : BackgroundService
    {
        private readonly BackgroundWorkerQueue _queue;

        public TheCook(BackgroundWorkerQueue queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await _queue.DequeueAsync(stoppingToken);

                await workItem(stoppingToken);
            }
        }
    }
}
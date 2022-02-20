using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBreakfastMVC.Tasks.Interfaces
{
    public interface IBackgroundOrderTaskQueue
    {
        ValueTask QueueBackgroundOrderWorkerItemAsync(Func<CancellationToken, ValueTask> workItem);
        ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);
    }
}
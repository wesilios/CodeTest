namespace AsyncBreakfastMVC.Tasks.Interfaces;

public interface IBackgroundOrderTaskQueue
{
    ValueTask QueueBackgroundOrderWorkerItemAsync(Func<CancellationToken, ValueTask> workItem);
    ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);
}
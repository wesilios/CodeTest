using AsyncBreakfastMVC.DataAccess.Repositories;

namespace AsyncBreakfastMVC.DataAccess;

public interface IUnitOfWork : IDisposable
{
    IOrderRepository OrderRepository { get; }
    Task<int> CommitAsync();
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
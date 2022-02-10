using System;
using System.Threading.Tasks;
using AsyncBreakfastMVC.DataAccess.Repositories;

namespace AsyncBreakfastMVC.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; } 
        Task<int> CommitAsync();
    }
}
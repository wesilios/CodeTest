using System.Threading.Tasks;
using AsyncBreakfastMVC.DataAccess.Repositories;

namespace AsyncBreakfastMVC.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private OrderRepository _orderRepository;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_dataContext);

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task<int> CommitAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.DataAccess.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<ICollection<Order>> GetAllOrdersAsync();
    Task<Order> FirstOrDefaultAsync(Guid orderId);
}
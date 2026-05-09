using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks.Interfaces;

public interface IOrderService
{
    Task<Guid> CreateOrder();
    Task<ICollection<Order>> GetAllOrdersAsync();
}
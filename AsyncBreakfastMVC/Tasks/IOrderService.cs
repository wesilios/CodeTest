using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks
{
    public interface IOrderService
    {
        Task<Guid> CreateOrder();
        Task<ICollection<Order>> GetAllOrdersAsync();
        Task MakeBreakfastAsync(Order order);
    }
}
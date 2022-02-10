using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.DataAccess.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<ICollection<Order>> GetAllOrdersAsync();
    }
}
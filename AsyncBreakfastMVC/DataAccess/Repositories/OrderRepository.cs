using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Tasks.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncBreakfastMVC.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private DataContext DataContext => Context as DataContext;

        public OrderRepository(DbContext context) : base(context)
        {
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await DataContext.Orders.Include(c => c.Breakfast).ToListAsync();
        }

        public async Task<Order> First()
        {
            return await DataContext.Orders
                .Include(c => c.Breakfast)
                .FirstOrDefaultAsync(c => c.Breakfast == null);
        }
    }
}
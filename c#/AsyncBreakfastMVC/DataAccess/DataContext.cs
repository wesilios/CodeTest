using AsyncBreakfastMVC.Tasks.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncBreakfastMVC.DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
        
    public DbSet<Bacon> Bacons { get; set; }
    public DbSet<Breakfast> Breakfasts { get; set; }
    public DbSet<Coffee> Coffees { get; set; }
    public DbSet<Egg> Eggs { get; set; }
    public DbSet<Juice> Juices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Toast> Toasts { get; set; }
}
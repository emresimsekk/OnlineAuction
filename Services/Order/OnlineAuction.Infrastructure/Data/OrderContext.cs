using Microsoft.EntityFrameworkCore;
using OnlineAuction.Domain.Entities;

namespace OnlineAuction.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}

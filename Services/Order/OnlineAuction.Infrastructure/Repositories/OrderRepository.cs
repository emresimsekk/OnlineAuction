using Microsoft.EntityFrameworkCore;
using OnlineAuction.Domain.Entities;
using OnlineAuction.Domain.Repositories.Base;
using OnlineAuction.Infrastructure.Data;
using OnlineAuction.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersBySellerUserName(string username)
        {
            var orderList = await _dbContext.Orders
                                            .Where(x => x.SellerUserName == username)
                                            .ToListAsync();

            return orderList;
        }
    }
}

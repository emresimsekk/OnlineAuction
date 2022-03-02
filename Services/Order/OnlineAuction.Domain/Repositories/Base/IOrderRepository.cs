using OnlineAuction.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineAuction.Domain.Repositories.Base
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersBySellerUserName(string username);
    }
}

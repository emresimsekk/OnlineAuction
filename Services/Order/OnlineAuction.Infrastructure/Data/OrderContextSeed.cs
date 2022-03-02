using OnlineAuction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test1@test@gmail.com",
                    UnitPrice=10,
                    TotalPrice=1000,
                    CreatedAt=DateTime.UtcNow
                },
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test2@test@gmail.com",
                    UnitPrice=20,
                    TotalPrice=2000,
                    CreatedAt=DateTime.UtcNow
                },
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test3@test@gmail.com",
                    UnitPrice=30,
                    TotalPrice=3000,
                    CreatedAt=DateTime.UtcNow
                },
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test4@test@gmail.com",
                    UnitPrice=40,
                    TotalPrice=4000,
                    CreatedAt=DateTime.UtcNow
                }


            };

        }
    }
}

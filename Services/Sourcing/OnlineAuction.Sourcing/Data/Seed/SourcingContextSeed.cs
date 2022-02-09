using MongoDB.Driver;
using OnlineAuction.Sourcing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAuction.Sourcing.Data.Seed
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            bool exist = auctionCollection.Find(p => true).Any();
            if (!exist)
            {
                auctionCollection.InsertManyAsync(GetConfigureAuctions());
            }
        }

        private static IEnumerable<Auction> GetConfigureAuctions()
        {
            return new List<Auction>()
            {
                new Auction()
                {
                    Name="Auction-1",
                    Description="Auction Description-1",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(3),
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                },
                new Auction()
                {
                    Name="Auction-2",
                    Description="Auction Description-2",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(5),
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                },
                new Auction()
                {
                    Name="Auction-3",
                    Description="Auction Description-3",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                }

            };
        }
    }
}

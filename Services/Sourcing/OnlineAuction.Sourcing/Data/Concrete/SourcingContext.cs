using MongoDB.Driver;
using OnlineAuction.Sourcing.Data.Interfaces;
using OnlineAuction.Sourcing.Data.Seed;
using OnlineAuction.Sourcing.Entities;
using OnlineAuction.Sourcing.Settings;

namespace OnlineAuction.Sourcing.Data.Concrete
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));
            SourcingContextSeed.SeedData(Auctions);

        }
        public IMongoCollection<Auction> Auctions { get; }

        public IMongoCollection<Bid> Bids { get; }
    }
}

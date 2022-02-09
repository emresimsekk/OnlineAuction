using MongoDB.Driver;
using OnlineAuction.Sourcing.Entities;

namespace OnlineAuction.Sourcing.Data.Interfaces
{
    public interface ISourcingContext
    {
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bid> Bids { get; }
    }
}

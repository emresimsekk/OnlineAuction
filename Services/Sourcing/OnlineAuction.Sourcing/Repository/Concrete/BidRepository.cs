using MongoDB.Driver;
using OnlineAuction.Sourcing.Data.Interfaces;
using OnlineAuction.Sourcing.Entities;
using OnlineAuction.Sourcing.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.Sourcing.Repository.Concrete
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _sourcingContext;

        public BidRepository(ISourcingContext sourcingContext)
        {
            _sourcingContext = sourcingContext;
        }

        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(a => a.AuctionId, id);
            List<Bid>  bids=await _sourcingContext.Bids.Find(filter).ToListAsync();

            bids = bids.OrderByDescending(a => a.CreatedAt)
                       .GroupBy(a=>a.SellerUsername)
                       .Select(a=>new Bid 
                       { 
                            AuctionId=a.FirstOrDefault().AuctionId,
                            Price=a.FirstOrDefault().Price,
                            CreatedAt=a.FirstOrDefault().CreatedAt,
                            SellerUsername=a.FirstOrDefault().SellerUsername,
                            ProductId=a.FirstOrDefault().ProductId,
                            Id=a.FirstOrDefault().Id

                       }).ToList();
             
            return bids;
        }

        public async Task<Bid> GetWinnerBid(string id)
        {
            List <Bid> bids= await GetBidsByAuctionId(id);
            return bids.OrderByDescending(a => a.Price).FirstOrDefault();
        }

        public async Task SendBid(Bid bid)
        {
             await _sourcingContext.Bids.InsertOneAsync(bid);

        }
    }
}

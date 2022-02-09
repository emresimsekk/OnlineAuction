using DnsClient.Internal;
using MongoDB.Driver;
using OnlineAuction.Sourcing.Data.Interfaces;
using OnlineAuction.Sourcing.Entities;
using OnlineAuction.Sourcing.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineAuction.Sourcing.Repository.Concrete
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _sourcingContext;
      

        public AuctionRepository(ISourcingContext sourcingContext)
        {
            _sourcingContext = sourcingContext;
        }

        public async Task Create(Auction auction)
        {
            await _sourcingContext.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> deletedFilter = Builders<Auction>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult= await _sourcingContext.Auctions.DeleteOneAsync(deletedFilter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Auction> GetAuction(string id)
        {
           return await _sourcingContext.Auctions.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> nameFilter = Builders<Auction>.Filter.Eq(m => m.Name, name);
            return await _sourcingContext.Auctions.Find(nameFilter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            return await _sourcingContext.Auctions.Find(a => true).ToListAsync();
        }

        public async Task<bool> Update(Auction auction)
        {
            var updateResult = await _sourcingContext.Auctions.ReplaceOneAsync(a => a.Id.Equals(auction.Id), auction);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            
        }
    }
}

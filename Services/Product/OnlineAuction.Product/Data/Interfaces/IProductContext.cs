using MongoDB.Driver;

namespace OnlineAuction.Product.Data.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Entities.Product> Products { get; }
    }
}

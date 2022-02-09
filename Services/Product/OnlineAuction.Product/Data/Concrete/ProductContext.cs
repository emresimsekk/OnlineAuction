using MongoDB.Driver;
using OnlineAuction.Product.Data.Interfaces;
using OnlineAuction.Product.Data.Seed;
using OnlineAuction.Product.Settings;

namespace OnlineAuction.Product.Data.Concrete
{
    public class ProductContext : IProductContext
    {

        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Entities.Product>(settings.CollectionName);

            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Entities.Product> Products { get; }



    }
}

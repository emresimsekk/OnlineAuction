using MongoDB.Driver;
using OnlineAuction.Product.Data.Interfaces;
using OnlineAuction.Product.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OnlineAuction.Product.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _productContext;

        public ProductRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task Create(Entities.Product product)
        {
            await _productContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            var deleteFilter = Builders<Entities.Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _productContext.Products.DeleteOneAsync(deleteFilter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Entities.Product> GetProduct(string id)
        {
            return await _productContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<Entities.Product>.Filter.Eq(p => p.Category, categoryName);
            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProductByName(string name)
        {
            var filter = Builders<Entities.Product>.Filter.ElemMatch(p => p.Category, name);
            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts()
        {
            return await _productContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Entities.Product product)
        {
            var updateResult = await _productContext.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}

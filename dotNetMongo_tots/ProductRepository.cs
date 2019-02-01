using dotNetMongo_tots.DBCalls;
using System.Threading.Tasks;
using System.Collections.Generic;
using dotNetMongo_tots.models;
using MongoDB.Driver;

namespace dotNetMongo_tots
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _context;

        public ProductRepository(IProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Find(_ => true).ToListAsync();

        }

        public Task<Product> GetProduct(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.ProductName, name);
            return _context
                    .Products
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);

        }

        public async Task<bool> Update(Product product)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Products
                        .ReplaceOneAsync(
                            filter: g => g.Id == product.Id,
                            replacement: product);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.ProductName, name);
            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }

}

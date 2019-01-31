using System;
using dotNetMongo_tots.models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace dotNetMongo_tots
{
    public class ProductContext : IProductContext
    {
        private readonly IMongoDatabase _db;

        public ProductContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Product> Products => _db.GetCollection<Product>("books");
    }
}

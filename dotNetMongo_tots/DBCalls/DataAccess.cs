using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using dotNetMongo_tots.models;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetMongo_tots.DBCalls
{
    public class DataAccess
    {
        private MongoClient mongoClient;
        private IMongoCollection<Product> productCollection;
        private IMongoDatabase database;


        public DataAccess()
        {
            mongoClient = new MongoClient("mongodb+srv://Mukundh:$2a$10$2OS66nvZ0CEPw4TY6lh7xu5YKcys/adC0yAt.pOfM2gfwtdLYWcKO@clusterdev-ortbw.azure.mongodb.net/test?retryWrites=true");
            database = mongoClient.GetDatabase("products");
            //productCollection = database.GetCollection<Products>("books");


        }

        public async Task<IEnumerable<Products>> findAll()
        {
            return await
        }

    }
}



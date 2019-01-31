using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotNetMongo_tots.models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("ProductId")]
        public int ProductId { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonElement("Price")]
        public int Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }
    }
}

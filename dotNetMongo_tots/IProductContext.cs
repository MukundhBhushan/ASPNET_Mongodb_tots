using System;
using MongoDB.Driver;
using dotNetMongo_tots.models;
namespace dotNetMongo_tots
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

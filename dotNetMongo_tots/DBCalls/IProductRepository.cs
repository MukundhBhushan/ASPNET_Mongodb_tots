using System.Threading.Tasks;
using System.Collections;
using dotNetMongo_tots.models;
using System.Collections.Generic;

namespace dotNetMongo_tots.DBCalls
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string name);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string name);

    }
}

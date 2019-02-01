using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetMongo_tots.DBCalls;
using Microsoft.AspNetCore.Mvc;
using dotNetMongo_tots.models;

namespace dotNetMongo_tots.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productrepository;

        public ProductsController(IProductRepository pr)
        {
            pr = _productrepository;
        }

        //get

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _productrepository.GetAllProducts());
        }

        //GET: api/product/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var game = await _productrepository.GetProduct(name);

            if (game == null)
                return new NotFoundResult();
            return new ObjectResult(game);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productrepository.Create(product);
            return new OkObjectResult(product);
        }

        // PUT: api/Game/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Product product)
        {
            var productFromdb = await _productrepository.GetProduct(name);
            if (productFromdb == null)
                return new NotFoundResult();
            product.Id = productFromdb.Id;
            await _productrepository.Update(product);
            return new OkObjectResult(product);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var gameFromDb = await _productrepository.GetProduct(name);
            if (gameFromDb == null)
                return new NotFoundResult();
            await _productrepository.Delete(name);
            return new OkResult();
        }

    }
}

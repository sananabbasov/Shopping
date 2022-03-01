using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _products;

        public ProductController(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Ecommerce");
            _products = database.GetCollection<Product>("products");
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var product = _products.Find(product=>true).ToList();

            return product;
        }
    }
}

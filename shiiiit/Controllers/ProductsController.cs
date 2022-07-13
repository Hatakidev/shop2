using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shiiiit.Models;
using shiiiit.Repositories;

namespace shiiiit.Controllers
{
    [Route("api/Products")]
    [ApiController]
    //api/Products или api/Products/1
    public class ProductsController
    { 
        private readonly IRepository _repo;

        public ProductsController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {          
            return await _repo.GetAllProducts();
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SearchProducts(string value)
        {
            return await _repo.SearchProducts(value);
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SortByProductName()
        {
            return await _repo.SortByProductName();
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SortByProductNameDescending()
        {
            return await _repo.SortByProductNameDescending();
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SortByProductDate()
        {
            return await _repo.SortByProductDate();
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SortByProductDateDescending()
        {
            return await _repo.SortByProductDateDescending();
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SortByProductPrice()
        {
            return await _repo.SortByProductPrice();
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> SortByProductPriceDescending()
        {
            return await _repo.SortByProductPriceDescending();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _repo.GetProduct(id);
            return product;
        }
        [HttpGet("{catid}")]
        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid catId)
        {
            return await _repo.GetByCategoryProducts(catId);
        }

        [HttpPut("{id}")]
        public async Task PutProduct(Guid id, Product product)
        {
            await _repo.UpdateProduct(product, id);
            return;
        }

        [HttpPost]
        public async Task<Product> PostProduct(Product product)
        {
            await _repo.CreateProduct(product);
            return product;
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(Guid id)
        {
            await _repo.DeleteProduct(id);

            return;
        }
    }
}

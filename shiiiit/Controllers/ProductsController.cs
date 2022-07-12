using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shiiiit.Models;
using shiiiit.Repositories;

namespace shiiiit.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IRepository _repo;

        public ProductsController(ShopContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _repo.GetAllProducts();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(string value)
        {
            if (_context.Products == null) return NotFound();
            if(value == null) return BadRequest();
            return await _repo.SearchProducts(value);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _repo.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("{catid}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(Guid catId)
        {
            if(_context.Products == null) return NotFound();
            return await _repo.GetByCategoryProducts(catId);
           
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            

            try
            {
                await _repo.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _repo.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            await _repo.DeleteProduct(id);

            return NoContent();
        }

        private bool ProductExists(Guid id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shiiiit.Models;
using shiiiit.Repositories;

namespace shiiiit.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    //api/Categories или api/Categories/1
    public class CategoriesController
    {
        private readonly IRepository _repo;

        public CategoriesController(IRepository repo, ShopContext context)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _repo.GetAllCategories();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategory(Guid id)
        {
            return await _repo.GetCategory(id);
        }

        [HttpPut("{id}")]
        public async Task PutCategory(Guid id, Category category)
        {
            await _repo.UpdateCategory(category, id);
            return;
        }

        [HttpPost]
        public async Task<Category> PostCategory(Category category)
        {
            await _repo.CreateCategory(category);
            return category;
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategory(Guid id)
        {
           await _repo.DeleteCategory(id);

            return;
        }
    }
}

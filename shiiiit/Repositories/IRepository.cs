using shiiiit.Models;
using Microsoft.AspNetCore.Mvc;
namespace shiiiit.Repositories
{
    public interface IRepository : IDisposable
    {
        Task<User> GetUser(Guid id);
        Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers();
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
        Task<ActionResult<IEnumerable<Product>>> GetAllProducts();
        Task<ActionResult<IEnumerable<Product>>> GetByCategoryProducts(Guid catid);
        Task<ActionResult<IEnumerable<Product>>> SearchProducts(string value);
        Task<Product> GetProduct(Guid id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
        Task<ActionResult<IEnumerable<Category>>> GetAllCategories();
        Task<Category> GetCategory(Guid id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Guid id);
    }
}

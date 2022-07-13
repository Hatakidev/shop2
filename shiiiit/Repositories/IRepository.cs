using shiiiit.Models;
using Microsoft.AspNetCore.Mvc;
namespace shiiiit.Repositories
{
    public interface IRepository : IDisposable
    {
        Task<UserDTO> GetUser(Guid id);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task CreateUser(User user);
        Task UpdateUser(Guid id, User user);
        Task DeleteUser(Guid id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetByCategoryProducts(Guid catid);
        Task<IEnumerable<Product>> SearchProducts(string value);
        Task<IEnumerable<Product>> SortByProductName();
        Task<IEnumerable<Product>> SortByProductNameDescending();
        Task<IEnumerable<Product>> SortByProductDate();
        Task<IEnumerable<Product>> SortByProductDateDescending();
        Task<IEnumerable<Product>> SortByProductPrice();
        Task<IEnumerable<Product>> SortByProductPriceDescending();
        Task<Product> GetProduct(Guid id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product, Guid id);
        Task DeleteProduct(Guid id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategory(Guid id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category, Guid id);
        Task DeleteCategory(Guid id);
    }
}

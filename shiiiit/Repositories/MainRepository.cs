using shiiiit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace shiiiit.Repositories
{
    public class MainRepository : IRepository
    {
        
        private readonly ShopContext context;
        
        public async Task<UserDTO> GetUser(Guid id)
        {
            var user =  await context.Users.FindAsync(id);
            return UseDTO(user);
        }
        
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return await context.Users.Select(x => UseDTO(x)).ToListAsync();
        }

        public async Task CreateUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUser(Guid id, User user)
        {
            if (id != user.Id) return;
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            User user = await context.Users.FindAsync(id);
            if(user != null) context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryProducts(Guid id)
        {
            return await context.Products.Where(x => x.CategoryID == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProducts(string value)
        {
            return await context.Products.Where(x => x.ProductName.Contains(value) || x.Seller.Contains(value)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByProductName()
        {
            return await context.Products.OrderBy(x => x.ProductName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByProductNameDescending()
        {
            return await context.Products.OrderByDescending(x => x.ProductName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByProductDate()
        {
            return await context.Products.OrderBy(x => x.DateTime).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByProductDateDescending()
        {
            return await context.Products.OrderByDescending(x => x.DateTime).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByProductPrice()
        {
            return await context.Products.OrderBy(x => x.Price).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByProductPriceDescending()
        {
            return await context.Products.OrderByDescending(x => x.Price).ToListAsync();
        }


        public async Task CreateProduct(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task UpdateProduct(Product product, Guid id)
        {
            if (id != product.Id) return;
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid id)
        {
            Product product = await context.Products.FindAsync(id);
            if(product != null) context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task CreateCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            context.SaveChanges();
        }

        public async Task UpdateCategory(Category category, Guid id)
        {
            if (id != category.Id) return;
            context.Entry(category).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid id)
        {
            Category category = await context.Categories.FindAsync(id);
            if(category != null) context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static UserDTO UseDTO(User user) =>
        new()
        {
            Id = user.Id,
            Name = user.Name,
            IsSeller = user.IsSeller
        };
    }
}

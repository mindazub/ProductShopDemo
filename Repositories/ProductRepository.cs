using Microsoft.EntityFrameworkCore;
using ProductShopDemo.Data;
using ProductShopDemo.Models;

namespace ProductShopDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int page, int itemsPerPage)
        {
            return await _context.Products
                .Include(p => p.ProductSubtype)
                    .ThenInclude(s => s.ProductType)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductSubtype)
                    .ThenInclude(s => s.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}



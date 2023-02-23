using Microsoft.EntityFrameworkCore;
using ProductShopDemo.Data;
using ProductShopDemo.Models;

namespace ProductShopDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(int pageNumber, int pageSize)
        {
            return await _context.Products
                .Include(p => p.ProductSubtype)
                .ThenInclude(s => s.ProductType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                .Include(p => p.ProductSubtype)
                .ThenInclude(s => s.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<Product>> GetProductsPaged(int pageNumber, int pageSize)
        {
            var totalItems = await _context.Products.CountAsync();
            var products = await _context.Products
                .Include(p => p.ProductSubtype)
                    .ThenInclude(s => s.ProductType)
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PagedResult<Product>(products, totalItems, pageNumber, pageSize);
        }
    }
}

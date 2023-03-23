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
                .OrderByDescending(p => p.Id)
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

            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductSubtype> GetProductSubtypeByIdAsync(int id)
        {
            return await _context.ProductSubtypes.FindAsync(id);
        }

        public async Task<List<ProductSubtype>> GetProductSubtypesAsync()
        {
            return await _context.ProductSubtypes.ToListAsync();

        }
    }
}



using ProductShopDemo.Models;

namespace ProductShopDemo.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page, int itemsPerPage);
        Task<int> GetProductsCountAsync();
        Task<Product> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
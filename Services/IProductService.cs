using ProductShopDemo.Models;

namespace ProductShopDemo.Services
{
    public interface IProductService
    {
        Task<PaginationResult<Product>> GetProductsAsync(int page);
        Task<Product> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        //
        Task<List<ProductType>> GetProductTypesAsync();
        Task<List<ProductSubtype>> GetProductSubtypesAsync();

    }

}

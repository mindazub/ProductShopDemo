using ProductShopDemo.DTO;
using ProductShopDemo.Models;

namespace ProductShopDemo.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync(ProductInputDTO productInputDTO);
        Task DeleteProductAsync(int id);
        Task<Product> GetProductAsync(int id);
        Task<PaginationResult<Product>> GetProductsAsync(int page);
        Task<PaginationResult<Product>> GetProductsAsync(int page, int pageSize);
        Task<List<ProductSubtype>> GetProductSubtypesAsync();
        Task<List<ProductType>> GetProductTypesAsync();
        Task UpdateProductAsync(Product product);
    }
}
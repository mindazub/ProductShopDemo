using ProductShopDemo.Models;

namespace ProductShopDemo.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(int pageNumber, int pageSize);
        //
        Task<PagedResult<Product>> GetProductsPaged(int pageNumber, int pageSize);
        //
        Task<Product> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        //
        Task<List<ProductType>> GetProductTypes();
        Task<List<ProductSubtype>> GetProductSubtypes();
        //
    }
}

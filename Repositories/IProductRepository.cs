using ProductShopDemo.Models;

namespace ProductShopDemo.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(int pageNumber, int pageSize);
        //
        Task CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<List<ProductSubtype>> GetProductSubtypes();
        Task UpdateProduct(Product product);
    }
}
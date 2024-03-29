﻿using ProductShopDemo.Models;

namespace ProductShopDemo.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page, int itemsPerPage);
        Task<int> GetProductsCountAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

        Task<List<ProductType>> GetProductTypesAsync();
        Task<List<ProductSubtype>> GetProductSubtypesAsync();
    }
}
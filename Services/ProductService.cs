using Microsoft.EntityFrameworkCore;
using ProductShopDemo.DTO;
using ProductShopDemo.Models;
using ProductShopDemo.Repositories;
using ProductShopDemo.Mappers;

namespace ProductShopDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResult<Product>> GetProductsAsync(int page)
        {
            var itemsPerPage = 10;
            var totalItems = await _repository.GetProductsCountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            var products = await _repository.GetProductsAsync(page, itemsPerPage);

            return new PaginationResult<Product>(products, totalPages, page, itemsPerPage);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _repository.GetProductAsync(id);
        }

        public async Task<ProductDTO> CreateProductAsync(ProductInputDTO productInputDTO)
        {
            var product = ProductMapper.mapProductInputDTOToProduct(productInputDTO);

            var createdProduct = await _repository.CreateProductAsync(product);

            var responseDTO = ProductMapper.mapProductToProductDTO(createdProduct);

            return responseDTO;

        }

        public async Task UpdateProductAsync(Product product)
        {
            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }

        public async Task<PaginationResult<Product>> GetProductsAsync(int page, int pageSize)
        {
            var products = await _repository.GetProductsAsync(page, pageSize);
            var totalCount = await _repository.GetProductsCountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return new PaginationResult<Product>(products, totalPages, page, pageSize);
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _repository.GetProductTypesAsync();
        }

        public async Task<List<ProductSubtype>> GetProductSubtypesAsync()
        {
            return await _repository.GetProductSubtypesAsync();
        }

    }

}
    

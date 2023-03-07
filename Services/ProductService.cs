using Microsoft.EntityFrameworkCore;
using ProductShopDemo.DTO;
using ProductShopDemo.Models;
using ProductShopDemo.Repositories;
using ProductShopDemo.Mappers;
using ProductShopDemo.Data;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<ProductDTO> GetProductAsync(int id)
        {
            var productFromDB = await _repository.GetProductAsync(id);
            if(productFromDB == null)
            {
                throw new Exception($"Can't find product Id:{id}");
            }

            var responseDTO = ProductMapper.mapProductToProductDTO(productFromDB); 

            return responseDTO;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductInputDTO productInputDTO)
        {
            var product = ProductMapper.mapProductInputDTOToProduct(productInputDTO);

            var createdProduct = await _repository.CreateProductAsync(product);

            var responseDTO = ProductMapper.mapProductToProductDTO(createdProduct);

            return responseDTO;

        }

        public async Task<ProductDTO> UpdateProductAsync(ProductInputDTO productInputDTO)
        {
            var product = ProductMapper.mapProductInputDTOToProduct(productInputDTO);

            var updatedProduct = await _repository.UpdateProductAsync(product);

            var responseDTO = ProductMapper.mapProductToProductDTO(updatedProduct);

            return responseDTO;
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
    

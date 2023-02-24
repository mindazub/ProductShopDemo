﻿using Microsoft.EntityFrameworkCore;
using ProductShopDemo.Models;
using ProductShopDemo.Repositories;

namespace ProductShopDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts(int pageNumber, int pageSize)
        {
            return await _productRepository.GetProducts(pageNumber, pageSize);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task CreateProduct(Product product)
        {
            await _productRepository.Add(product);
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
        public async Task<List<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<List<ProductSubtype>> GetProductSubtypes()
        {
            return await _context.ProductSubtypes.ToListAsync();
        }
    }
}
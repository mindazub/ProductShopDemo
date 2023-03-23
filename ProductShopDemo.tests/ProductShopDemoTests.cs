using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductShopDemo.DTO;
using ProductShopDemo.Mappers;
using ProductShopDemo.Models;
using ProductShopDemo.Repositories;
using ProductShopDemo.Services;
using Xunit;

namespace ProductShopDemo.tests
{
    public class ProductShopDemoTests
    {


        [Fact]
        public async Task GetProductAsync_ThrowsException_WhenProductNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(repo => repo.GetProductAsync(It.IsAny<int>())).ReturnsAsync((Product)null);
            var productService = new ProductService(mockRepository.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => productService.GetProductAsync(1));
        }

        [Fact]
        public async Task DeleteProductAsync_CallsRepositoryDeleteProductAsync()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productService = new ProductService(mockRepository.Object);

            // Act
            await productService.DeleteProductAsync(1);

            // Assert
            mockRepository.Verify(repo => repo.DeleteProductAsync(1),Times.Once);
        }

        [Fact]
        public async Task GetProductTypesAsync_ReturnsListOfProductTypes()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productTypes = new List<ProductType>();
            mockRepository.Setup(repo => repo.GetProductTypesAsync()).ReturnsAsync(productTypes);
            var productService = new ProductService(mockRepository.Object);

            // Act
            var result = await productService.GetProductTypesAsync();

            // Assert
            Assert.Equal(productTypes, result);
        }

        [Fact]
        public async Task GetProductSubtypesAsync_ReturnsListOfProductSubtypes()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productSubtypes = new List<ProductSubtype>();
            mockRepository.Setup(repo => repo.GetProductSubtypesAsync()).ReturnsAsync(productSubtypes);
            var productService = new ProductService(mockRepository.Object);

            // Act
            var result = await productService.GetProductSubtypesAsync();

            // Assert
            Assert.Equal(productSubtypes, result);
        }
    }
}
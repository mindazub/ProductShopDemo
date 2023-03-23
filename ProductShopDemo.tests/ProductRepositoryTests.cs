using Microsoft.EntityFrameworkCore;
using ProductShopDemo.Data;
using ProductShopDemo.Models;
using ProductShopDemo.Repositories;
using Xunit;

namespace ProductShopDemo.Tests
{
    public class ProductRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductRepository _repository;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new ProductRepository(_context);
        }

        //[Fact]
        //public async Task GetProductsAsync_ReturnsProducts()
        //{
        //    // Arrange
        //    var expectedProducts = new List<Product>
        //{
        //    new Product { Id = GetUniqueProductId(), Name = "Product 1" },
        //    new Product { Id = GetUniqueProductId(), Name = "Product 2" },
        //    new Product { Id = GetUniqueProductId(), Name = "Product 3" },
        //    new Product { Id = GetUniqueProductId(), Name = "Product 4"},
        //    new Product { Id = GetUniqueProductId(), Name = "Product 5"},
        //    new Product { Id = GetUniqueProductId(), Name = "Product 6"},
        //    new Product { Id = GetUniqueProductId(), Name = "Product 7"},
        //    new Product { Id = GetUniqueProductId(), Name = "Product 8"},
        //    new Product { Id = GetUniqueProductId(), Name = "Product 9"},
        //    new Product { Id = GetUniqueProductId(), Name = "Product 10"}
        //};

        //    await _context.Products.AddRangeAsync(expectedProducts);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    var result = await _repository.GetProductsAsync(page: 1, itemsPerPage: 10);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(expectedProducts.Count, result.Count());
        //}

        //private int _nextProductId = 1;
        //private int GetUniqueProductId() => Interlocked.Increment(ref _nextProductId);



        [Fact]
        public async Task GetProductsCountAsync_ReturnsProductsCount()
        {
            // Arrange
            var expectedCount = 10;
            for (var i = 0; i < expectedCount; i++)
            {
                _context.Products.Add(new Product { Name = $"Product {i + 1}" });
            }
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetProductsCountAsync();

            // Assert
            Assert.Equal(expectedCount, result);
        }

        // other tests
    }
}

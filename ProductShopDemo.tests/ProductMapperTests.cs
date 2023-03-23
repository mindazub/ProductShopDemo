using ProductShopDemo.DTO;
using ProductShopDemo.Models;
using ProductShopDemo.Mappers;
using Xunit;

namespace ProductShopDemo.Tests
{
    public class ProductMapperTests
    {
        [Fact]
        public void mapProductInputDTOToProduct_ReturnsProduct()
        {
            // Arrange
            var productInputDTO = new ProductInputDTO
            {
                Name = "Test Product",
                Description = "Test Product Description",
                Price = 10.00M,
                ProductSubtype = new ProductSubtype(),
                ProductSubtypeId = 1
            };

            // Act
            var result = ProductMapper.mapProductInputDTOToProduct(productInputDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productInputDTO.Name, result.Name);
            Assert.Equal(productInputDTO.Description, result.Description);
            Assert.Equal(productInputDTO.Price, result.Price);
            Assert.Equal(productInputDTO.ProductSubtype, result.ProductSubtype);
            Assert.Equal(productInputDTO.ProductSubtypeId, result.ProductSubtypeId);
        }

        [Fact]
        public void mapProductToProductDTO_ReturnsProductDTO()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Product Description",
                Price = 10.0M,
                ProductSubtype = new ProductSubtype(),
                ProductSubtypeId = 1
            };

            // Act
            var result = ProductMapper.mapProductToProductDTO(product);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(product.ProductSubtype, result.ProductSubtype);
            Assert.Equal(product.ProductSubtypeId, result.ProductSubtypeId);
        }
    }
}

using ProductShopDemo.DTO;
using ProductShopDemo.Models;

namespace ProductShopDemo.Mappers
{
    public class ProductMapper
    {
        internal static Product mapProductInputDTOToProduct(ProductInputDTO productInputDTO)
        {
            var product = new Product();
            product.Name = productInputDTO.Name;
            product.Description = productInputDTO.Description;
            product.Price = productInputDTO.Price;
            product.ProductSubtype = productInputDTO.ProductSubtype;
            product.ProductSubtypeId = productInputDTO.ProductSubtypeId;
            return product;
        }

        internal static ProductDTO mapProductToProductDTO(Product product)
        {
            var productDTO = new ProductDTO();
            productDTO.Id = product.Id;
            productDTO.Name = product.Name;
            productDTO.Description = product.Description;
            productDTO.Price = product.Price;
            productDTO.ProductSubtype = product.ProductSubtype;
            productDTO.ProductSubtypeId = product.ProductSubtypeId;
            return productDTO;
        }
    }
}

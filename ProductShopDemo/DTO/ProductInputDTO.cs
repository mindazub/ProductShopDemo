using ProductShopDemo.Models;

namespace ProductShopDemo.DTO
{
    public class ProductInputDTO
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int ProductSubtypeId { get; set; }
        public ProductSubtype? ProductSubtype { get; set; }
    }
}


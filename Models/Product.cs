using System.Data;

namespace ProductShopDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int ProductSubtypeId { get; set; }
        public ProductSubtype? ProductSubtype { get; set; }
    }

}

namespace ProductShopDemo.Models
{
    public class ProductSubtype
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
    }

}

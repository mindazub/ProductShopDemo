namespace ProductShopDemo.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ProductSubtype>? ProductSubtypes { get; set; }
    }

}

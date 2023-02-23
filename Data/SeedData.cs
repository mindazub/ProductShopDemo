using ProductShopDemo.Models;

namespace ProductShopDemo.Data
{
    public static class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var productTypes = new List<ProductType>
            {
                new ProductType
                {
                    Name = "Food",
                    ProductSubtypes = new List<ProductSubtype>
                    {
                        new ProductSubtype { Name = "Milk" },
                        new ProductSubtype { Name = "Bread" },
                        new ProductSubtype { Name = "Cheese" }
                    }
                },
                new ProductType
                {
                    Name = "Electronics",
                    ProductSubtypes = new List<ProductSubtype>
                    {
                        new ProductSubtype { Name = "Mobile" },
                        new ProductSubtype { Name = "Computer" },
                        new ProductSubtype { Name = "Appliances" }
                    }
                },
                new ProductType
                {
                    Name = "Furniture",
                    ProductSubtypes = new List<ProductSubtype>
                    {
                        new ProductSubtype { Name = "Chair" },
                        new ProductSubtype { Name = "Table" },
                        new ProductSubtype { Name = "Wardrobe" }
                    }
                }
            };

                await context.ProductTypes.AddRangeAsync(productTypes);

                var products = new List<Product>
            {
                new Product { Name = "Whole Milk", Price = 2.50M, Description = "A gallon of whole milk.", ProductSubtypeId = 1 },
                new Product { Name = "Wheat Bread", Price = 1.75M, Description = "A loaf of wheat bread.", ProductSubtypeId = 2 },
                new Product { Name = "Cheddar Cheese", Price = 3.00M, Description = "A block of cheddar cheese.", ProductSubtypeId = 3 },
                new Product { Name = "iPhone 13", Price = 999.00M, Description = "The latest iPhone.", ProductSubtypeId = 4 },
                new Product { Name = "Dell Inspiron 15", Price = 899.00M, Description = "The latest Dell Inspiron.", ProductSubtypeId = 4 },
                new Product { Name = "Refrigerator", Price = 799.00M, Description = "A large refrigerator.", ProductSubtypeId = 6 },
                new Product { Name = "Armchair", Price = 199.00M, Description = "A comfortable armchair.", ProductSubtypeId = 7 },
                new Product { Name = "Kitchen Table", Price = 399.00M, Description = "A large kitchen table.", ProductSubtypeId = 8 },
                new Product { Name = "Wardrobe", Price = 599.00M, Description = "A large wardrobe.", ProductSubtypeId = 9 },
                new Product { Name = "2% Milk", Price = 2.25M, Description = "A gallon of 2% milk.", ProductSubtypeId = 1 },
                new Product { Name = "White Bread", Price = 1.50M, Description = "A loaf of white bread.", ProductSubtypeId = 2 },
                new Product { Name = "Swiss Cheese", Price = 2.50M, Description = "A block of swiss cheese.", ProductSubtypeId = 3 },
                new Product { Name = "Samsung Galaxy S21", Price = 799.00M, Description = "A top-of-the-line Samsung phone.", ProductSubtypeId = 4 },
                new Product { Name = "HP Pavilion", Price = 799.00M, Description = "A budget-friendly HP laptop.", ProductSubtypeId = 5 },
                new Product { Name = "Washing Machine", Price = 499.00M, Description = "A top-loading washing machine.", ProductSubtypeId = 6 },
                new Product { Name = "Sofa", Price = 499.00M, Description = "A large sofa.", ProductSubtypeId = 7 },
                new Product { Name = "Coffee Table", Price = 199.00M, Description = "A small coffee table.", ProductSubtypeId = 8 },
                new Product { Name = "Dresser", Price = 299.00M, Description = "A large dresser.", ProductSubtypeId = 9 }
            };

                await context.Products.AddRangeAsync(products);

                await context.SaveChangesAsync();
            }
        }
    }

}

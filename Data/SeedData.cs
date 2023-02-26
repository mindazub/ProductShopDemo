


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductShopDemo.Models;

namespace ProductShopDemo.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                


                // Check if there are any products in the database
                if (context.Products.Any())
                {
                    return; // Database has already been seeded
                }

                // Seed the database with 15 products
                var foodType = new ProductType { Name = "Food" };
                var electronicsType = new ProductType { Name = "Electronics" };
                var furnitureType = new ProductType { Name = "Furniture" };
                context.ProductTypes.AddRange(foodType, electronicsType, furnitureType);

                var milkSubtype = new ProductSubtype { Name = "Milk", ProductType = foodType };
                var breadSubtype = new ProductSubtype { Name = "Bread", ProductType = foodType };
                var cheeseSubtype = new ProductSubtype { Name = "Cheese", ProductType = foodType };
                var mobileSubtype = new ProductSubtype { Name = "Mobile", ProductType = electronicsType };
                var computerSubtype = new ProductSubtype { Name = "Computer", ProductType = electronicsType };
                var appliancesSubtype = new ProductSubtype { Name = "Appliances", ProductType = electronicsType };
                var chairSubtype = new ProductSubtype { Name = "Chair", ProductType = furnitureType };
                var tableSubtype = new ProductSubtype { Name = "Table", ProductType = furnitureType };
                var wardrobeSubtype = new ProductSubtype { Name = "Wardrobe", ProductType = furnitureType };
                context.ProductSubtypes.AddRange(milkSubtype, breadSubtype, cheeseSubtype, mobileSubtype, computerSubtype, appliancesSubtype, chairSubtype, tableSubtype, wardrobeSubtype);

                var products = new[]
                {
                    new Product { Name = "Whole Milk", Price = 2.99m, Description = "Gallon of whole milk", ProductSubtype = milkSubtype },
                    new Product { Name = "Sourdough Bread", Price = 4.99m, Description = "Loaf of sourdough bread", ProductSubtype = breadSubtype },
                    new Product { Name = "Cheddar Cheese", Price = 3.99m, Description = "Block of cheddar cheese", ProductSubtype = cheeseSubtype },
                    new Product { Name = "iPhone 13", Price = 999.99m, Description = "Apple iPhone 13", ProductSubtype = mobileSubtype },
                    new Product { Name = "MacBook Pro", Price = 1999.99m, Description = "Apple MacBook Pro", ProductSubtype = computerSubtype },
                    new Product { Name = "Microwave", Price = 149.99m, Description = "Kitchen microwave", ProductSubtype = appliancesSubtype },
                    new Product { Name = "Recliner Chair", Price = 499.99m, Description = "Leather recliner chair", ProductSubtype = chairSubtype },
                    new Product { Name = "Dining Table", Price = 799.99m, Description = "Solid wood dining table", ProductSubtype = tableSubtype },
                    new Product { Name = "Wardrobe Closet", Price = 599.99m, Description = "Three-door wardrobe closet", ProductSubtype = wardrobeSubtype },
                    new Product { Name = "2% Milk", Price = 2.49m, Description = "Gallon of 2% milk", ProductSubtype = milkSubtype },
                    new Product { Name = "Baguette Bread", Price = 3.99m, Description = "French baguette bread", ProductSubtype = breadSubtype },
                    new Product { Name = "Swiss Cheese", Price = 4.99m, Description = "Block of swiss cheese", ProductSubtype = cheeseSubtype },
                    new Product { Name = "Samsung Galaxy S21", Price = 799.99m, Description = "Samsung Galaxy S21", ProductSubtype = mobileSubtype },
                    new Product { Name = "Dell XPS 13", Price = 1499.99m, Description = "Dell XPS 13 laptop", ProductSubtype = computerSubtype },
                    new Product { Name = "Toaster", Price = 49.99m, Description = "Kitchen toaster", ProductSubtype = appliancesSubtype },
                    };
                context.Products.AddRange(products);

                context.SaveChanges();

                AddMembership();



            }
        }

        private static void AddMembership()
        {
            // add DB insert with Admin and User memberships
        }
    }

}



using JSCRUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JSCRUD.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Product> Product { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Apple MacBook Air 13\"", Price = 1099.99 },
                new Product { ProductId = 2, Name = "Dell XPS 15", Price = 1499.99 },
                new Product { ProductId = 3, Name = "Logitech MX Master 3S Mouse", Price = 99.99 },
                new Product { ProductId = 4, Name = "Keychron K8 Mechanical Keyboard", Price = 89.99 },
                new Product { ProductId = 5, Name = "Samsung 27\" 4K Monitor", Price = 329.99 },
                new Product { ProductId = 6, Name = "Sony WH-1000XM5 Headphones", Price = 399.99 },
                new Product { ProductId = 7, Name = "Apple iPad Air", Price = 599.99 },
                new Product { ProductId = 8, Name = "Kindle Paperwhite", Price = 149.99 },
                new Product { ProductId = 9, Name = "Nintendo Switch OLED", Price = 349.99 },
                new Product { ProductId = 10, Name = "GoPro HERO12 Black", Price = 399.99 },
                new Product { ProductId = 11, Name = "Anker 65W USB-C Charger", Price = 45.99 },
                new Product { ProductId = 12, Name = "SanDisk 1TB Portable SSD", Price = 119.99 },
                new Product { ProductId = 13, Name = "Fitbit Charge 6", Price = 159.95 },
                new Product { ProductId = 14, Name = "Ninja Air Fryer 5-Qt", Price = 109.99 },
                new Product { ProductId = 15, Name = "Dyson V11 Cordless Vacuum", Price = 569.99 },
                new Product { ProductId = 16, Name = "Instant Pot Duo 7-in-1", Price = 99.95 },
                new Product { ProductId = 17, Name = "LEGO Star Wars X-Wing Set", Price = 239.99 },
                new Product { ProductId = 18, Name = "YETI Rambler 30oz Tumbler", Price = 38.00 },
                new Product { ProductId = 19, Name = "Adidas Ultraboost Running Shoes", Price = 189.99 },
                new Product { ProductId = 20, Name = "Patagonia Nano Puff Jacket", Price = 239.00 }
            );
        }
    }
}

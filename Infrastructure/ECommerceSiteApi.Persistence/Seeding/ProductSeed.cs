
using ECommerceSiteApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSiteApi.Persistence.Seeding;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6\" 144Hz Taşınabilir Bilgisayar",
                Price= 31699,
                stock=100,
                Description= "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6 144Hz Taşınabilir Bilgisayar",
                CategoryId=Guid.Parse("3c29f888-65c8-4de8-a723-2771e27eee1c"),
            },
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6\" 144Hz Taşınabilir Bilgisayar",
                Price = 31699,
                stock = 100,
                Description = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6 144Hz Taşınabilir Bilgisayar",
                CategoryId = Guid.Parse("3c29f888-65c8-4de8-a723-2771e27eee1c"),
            },
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6\" 144Hz Taşınabilir Bilgisayar",
                Price = 31699,
                stock = 100,
                Description = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6 144Hz Taşınabilir Bilgisayar",
                CategoryId = Guid.Parse("3c29f888-65c8-4de8-a723-2771e27eee1c"),
            },
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6\" 144Hz Taşınabilir Bilgisayar",
                Price = 31699,
                stock = 100,
                Description = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6 144Hz Taşınabilir Bilgisayar",
                CategoryId = Guid.Parse("3c29f888-65c8-4de8-a723-2771e27eee1c"),
            },
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6\" 144Hz Taşınabilir Bilgisayar",
                Price = 31699,
                stock = 100,
                Description = "Casper Excalibur G870.1265-DVA0X-B Intel Core i7 12650H 32GB 500GB SSD RTX4050 Freedos 15.6 144Hz Taşınabilir Bilgisayar",
                CategoryId = Guid.Parse("3c29f888-65c8-4de8-a723-2771e27eee1c"),
            }
            );
    }
}

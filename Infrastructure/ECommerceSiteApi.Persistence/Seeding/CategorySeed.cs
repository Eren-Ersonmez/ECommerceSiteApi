
using ECommerceSiteApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSiteApi.Persistence.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category
            {
                CreatedDate = DateTime.Now,
                Name = "Bilgisayar",
                Id = Guid.NewGuid(),
            },
            new Category
            {
                CreatedDate = DateTime.Now,
                Name = "Ütü",
                Id = Guid.NewGuid(),
            },
            new Category
            {
                CreatedDate = DateTime.Now,
                Name = "Makyaj",
                Id = Guid.NewGuid(),
            }
            , new Category
            {
                CreatedDate = DateTime.Now,
                Name = "Buzdolabı",
                Id = Guid.NewGuid(),
            },
            new Category
            {
                CreatedDate = DateTime.Now,
                Name = "Çamaşır Makinesi",
                Id = Guid.NewGuid(),
            }
            );
        }
    }
}

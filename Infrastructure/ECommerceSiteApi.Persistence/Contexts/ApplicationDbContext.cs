
 using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Domain.Models.Common;
using ECommerceSiteApi.Persistence.Seeding;
using ECommerceSiteApi.Persistence.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, AppRole, string>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BaseFile> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Iban> Ibans { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImageFile> ProductImages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }

        //public DbSet<UserCommentLike> UserCommentLikes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var EntryEntities = ChangeTracker.Entries<BaseEntity>();

            foreach (var EntryEntity in EntryEntities)
            {
                if (EntryEntity.State == EntityState.Added)
                {
                    EntryEntity.Entity.CreatedDate = DateTime.UtcNow;
                }
                else if (EntryEntity.State == EntityState.Modified)
                {
                    EntryEntity.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.CreditCard)
                .WithMany()
                .HasForeignKey(o => o.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
              .HasOne(o => o.ApplicationUser)
              .WithMany()
              .HasForeignKey(o => o.ApplicationUserId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShoppingCart>()
               .HasOne(o => o.ApplicationUser)
               .WithMany()
               .HasForeignKey(o => o.ApplicationUserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
               .HasOne(o => o.Category)
               .WithMany()
               .HasForeignKey(o => o.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Endpoint>()
             .HasOne(o => o.Menu)
             .WithMany()
             .HasForeignKey(o => o.MenuId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductImageFile>()
                .Property(p => p.ProductId)
                .HasColumnName("ProductId");
            modelBuilder.ApplyConfiguration(new CategorySeed());
            base.OnModelCreating(modelBuilder);
        }
    }
}

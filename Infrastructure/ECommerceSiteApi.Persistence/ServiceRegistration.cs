using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.RoleServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Persistence.Contexts;
using ECommerceSiteApi.Persistence.Repositories;
using ECommerceSiteApi.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("sqlServer"));
        });

        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IShoppingCartReadRepository, ShoppingCartReadRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderDetailsReadRepository, OrderDetailsReadRepository>();
        services.AddScoped<IEndpointReadRepository,EndpointReadRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddIdentity<ApplicationUser, AppRole>(options =>
        {
            options.Password.RequireDigit = false; // Rakam gereksinimini kaldırır
            options.Password.RequireLowercase = false; // Küçük harf gereksinimini kaldırır
            options.Password.RequireUppercase = false; // Büyük harf gereksinimini kaldırır
            options.Password.RequireNonAlphanumeric = false; // Özel karakter gereksinimini kaldırır
            options.Password.RequiredLength = 1; // Minimum karakter sayısını 1'e indirir
            options.Password.RequiredUniqueChars = 1; // Benzersiz karakter sayısını 1'e indirir
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        // Add Data Protection Provider
        services.AddDataProtection();
    }
}

using ECommerceSiteApi.Application.Configuration;
using ECommerceSiteApi.Application.Mapping;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.LoginService.FacebookLogin;
using ECommerceSiteApi.Application.Services.LoginService.GoogleLogin;
using ECommerceSiteApi.Application.Services.LoginServices;
using ECommerceSiteApi.Application.Services.MailServices;
using ECommerceSiteApi.Application.Services.RoleServices;
using ECommerceSiteApi.Application.Services.Storages;
using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Infrastructure.Services;
using ECommerceSiteApi.Infrastructure.Services.DataServices;
using ECommerceSiteApi.Infrastructure.Services.LoginServices.ExternalLogin.FacebookLogin;
using ECommerceSiteApi.Infrastructure.Services.LoginServices.ExternalLogin.GoogleLogin;
using ECommerceSiteApi.Infrastructure.Services.LoginServices.InternalLogin;
using ECommerceSiteApi.Infrastructure.Services.MailServices;
using ECommerceSiteApi.Infrastructure.Services.Storages;
using ECommerceSiteApi.Infrastructure.Services.Storages.Azure;
using ECommerceSiteApi.Infrastructure.Services.Storages.Local;
using ECommerceSiteApi.Infrastructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerceSiteApi.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureService(this IServiceCollection services) 
    {
        services.AddScoped(typeof(IDataService<,>),typeof(DataService<,>));
        services.AddScoped<IProductDataService, ProductDataService>();
        services.AddScoped<IShoppingCartDataService, ShoppingCartDataService>();
        services.AddScoped(typeof(IFileService<,>),typeof(FileService<,>));
        services.AddScoped<IOrderDataService, OrderDataService>();  
        services.AddScoped<IOrderDetailsDataService, OrderDetailsDataService>();
        services.AddScoped<ICommentDataService, CommentDataService>();
        services.AddScoped<IBrandDataService, BrandDataService>();  
        services.AddScoped<IStorageService,StorageService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IGoogleLoginService,GoogleLoginService>();
        services.AddScoped<IFacebookLoginService,FacebookLoginService>();
        services.AddScoped<IInternalLoginService,InternalLoginService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMailService,MailService>();
        services.AddScoped<IRoleService,RoleService>();
        services.AddScoped<IQRCodeService,QRCodeService>();
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
        services.AddHttpClient();
        services.AddAutoMapper(typeof(AddressProfile));
        
    }
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T :Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
        
    }
    public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType,string path,IConfiguration configuration)
    {
        switch (storageType)
        {
            case StorageType.Local:
                serviceCollection.AddScoped<IStorage>(provider => new LocalStorage(path,configuration));
                break;
            case StorageType.Azure:
                serviceCollection.AddScoped<IStorage, AzureStorage>();
                break;
            default:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }

}

using ECommerceSiteApi.Infrastructure;
using ECommerceSiteApi.Application;
using FluentValidation.AspNetCore;
using FluentValidation;
using ECommerceSiteApi.Application.Validators.ProductDtoValidators;
using Microsoft.AspNetCore.Http.Features;
using ECommerceSiteApi.Application.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Serilog.Context;
using ECommerceSiteApi.Api.Configurations;
using ECommerceSiteApi.Api.Middlewares;
using ECommerceSiteApi.SignalR;
using ECommerceSiteApi.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products");
SqlColumn sqlColumn = new SqlColumn() 
{
    ColumnName = "UserName",
    DataType = System.Data.SqlDbType.NVarChar,
    PropertyName = "UserName",
    DataLength = 50,
    AllowNull = true
};
ColumnOptions columnOpt = new ColumnOptions();
columnOpt.Store.Remove(StandardColumn.Properties);
columnOpt.Store.Add(StandardColumn.LogEvent);
columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };
Logger logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(
    builder.Configuration.GetConnectionString("sqlServer"),
    tableName: "Logs",
    autoCreateSqlTable: true,
    appConfiguration: null, 
    columnOptions: columnOpt)
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
    .Enrich.FromLogContext()
    .Enrich.With<CustomUserNameColumn>()
    .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog(logger);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddInfrastructureService();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalRService();
builder.Services.AddStorage(StorageType.Local, path,builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();
builder.Services.AddControllers(options =>
{
    //options.Filters.Add<RolePermissionFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecretKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ?expires>DateTime.UtcNow:false,
            NameClaimType=ClaimTypes.Name,
        };
    });

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
});

builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCustomException<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseStaticFiles();
app.UseSerilogRequestLogging();

app.UseCors();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.ConfigureHubs(); 
});
app.Use(async (context, next) =>
{
    var username=context.User?.Identity?.IsAuthenticated!=null || true ? context.User.Identity.Name:null;
    LogContext.PushProperty("UserName",username);
    await next();
});
app.MapControllers();


app.Run();

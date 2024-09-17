using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Text.Json;

namespace ECommerceSiteApi.Api.Middlewares;

public static class UseCustomExceptionHandler
{
    public static void UseCustomException<T>(this IApplicationBuilder app,ILogger<T> logger)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async (context) =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var statusCode = contextFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, contextFeature.Error.Message);

                    logger.LogError(contextFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }

                
            });
        });
    }
}

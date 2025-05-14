using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using IAgro.Application.Common.Exceptions;
using IAgro.Domain.Common.Enums;
using IAgro.Domain.Common.Messages;

namespace IAgro.API.Extensions;

public static class ErrorHandlerExtensions
{
    public static void UserErrorHandler(this IApplicationBuilder app) => 
        app.UseExceptionHandler(error => 
        {
            error.Run(async context => 
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature is null) return;

                var statusCode = contextFeature.Error switch
                {
                    AppException appError => appError.StatusCode,
                    _ => StatusCode.InternalServerError
                };
                var message = contextFeature.Error switch
                {
                    AppException appError => appError.Message,
                    _ => ExceptionMessages.InternalServerError.Default
                };

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) statusCode;

                var errorResponse = new { statusCode, message };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
}
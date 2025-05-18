using System.Text.Json;
using IAgro.Application.Common.Session;
using IAgro.Application.Contracts;
using IAgro.Domain.Common.Messages;

namespace IAgro.API.Middlewares;

public class AuthenticateMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            string message = JsonSerializer.Serialize(new { message = ExceptionMessages.Unauthorized.MissingToken });
            await context.Response.WriteAsync(message);
            return;
        }

        var token = authHeader["Bearer ".Length..];

        try
        {
            var authService = context.RequestServices.GetRequiredService<IAuthenticator>();
            var scopedSession = context.RequestServices.GetRequiredService<IRequestSession>();

            var sessionPayload = authService.ExtractToken(token);
            scopedSession.SetSession(sessionPayload);

            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            string message = JsonSerializer.Serialize(new { message = ExceptionMessages.Unauthorized.Token });
            await context.Response.WriteAsync(message);
        }
    }
}
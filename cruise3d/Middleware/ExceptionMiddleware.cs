using System.Net;
using System.Text.Json;
using cruise3d.API.Models.DTOs.Common;

namespace cruise3d.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex.Message switch
        {
            var m when m.Contains("not found", StringComparison.OrdinalIgnoreCase) => (int)HttpStatusCode.NotFound,
            var m when m.Contains("unauthorized", StringComparison.OrdinalIgnoreCase) => (int)HttpStatusCode.Unauthorized,
            var m when m.Contains("already exists", StringComparison.OrdinalIgnoreCase) => (int)HttpStatusCode.Conflict,
            var m when m.Contains("already registered", StringComparison.OrdinalIgnoreCase) => (int)HttpStatusCode.Conflict,
            _ => (int)HttpStatusCode.BadRequest
        };

        var response = ApiResponse<string>.Fail(ex.Message);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }
}


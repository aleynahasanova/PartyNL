using FluentValidation;
using System.Text.Json;

namespace PartyNL.API.Middleware;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = exception switch
        {
            KeyNotFoundException => new ExceptionResponse(404, "Not Found", []),
            ValidationException validationException => new ExceptionResponse(
                400,
                "Validation Error",
                validationException.Errors.Select(error => error.ErrorMessage).ToArray()),
            UnauthorizedAccessException => new ExceptionResponse(401, "Unauthorized", []),
            _ => new ExceptionResponse(500, "Internal Server Error", [])
        };

        context.Response.StatusCode = response.StatusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    }

    private sealed record ExceptionResponse(int StatusCode, string Message, IReadOnlyCollection<string> Errors);
}
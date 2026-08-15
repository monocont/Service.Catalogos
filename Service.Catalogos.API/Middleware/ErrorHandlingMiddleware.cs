using System.Text.Json;
using Service.Catalogos.Application.Common;
using Service.Catalogos.Application.Common.Exceptions;

namespace Service.Catalogos.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = ApiResponse<object>.Fail(string.Empty);

        (int statusCode, string title, List<string> errors) = exception switch
        {
            ValidationException validationEx => (
                400,
                "Error de validación",
                validationEx.ValidationErrors
            ),
            ArgumentException argumentEx => (
                400,
                "Error de validación",
                [argumentEx.Message]
            ),
            NotFoundException notFoundEx => (
                404,
                "No encontrado",
                [notFoundEx.Message]
            ),
            UnauthorizedAccessException => (
                401,
                "No autorizado",
                ["Acceso denegado."]
            ),
            _ => (
                500,
                "Error interno",
                ["Error en el proceso"]
            )
        };

        _logger.LogError(exception, "{Title}: {Message}", title, exception.Message);

        response = ApiResponse<object>.Fail(errors);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}
using System.Text.Json;
using API.Exceptions;

namespace API.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(httpContext, e);
        }
    }

    public static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        var httpResponse = httpContext.Response;
        
        var statusCode = StatusCodes.Status500InternalServerError;
        var errorMessage = "An unexpected error occured";
        
        switch (exception)
        {
            case CountryNotFoundException cnfEx:
                statusCode = StatusCodes.Status404NotFound;
                errorMessage = cnfEx.Message;
                break;
            
            default:
                errorMessage = exception.Message;
                break;
        }

        var formattedStackTrace = exception.StackTrace?
            .Split("\n")
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();
        
        var serverResponse = new
        {
            status = "error",
            code = statusCode,
            message = errorMessage,
            stackTrace = formattedStackTrace
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var json = JsonSerializer.Serialize(serverResponse, options);
        
        await httpResponse.WriteAsync(json);
    }
    
}
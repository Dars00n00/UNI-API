using System.Net.Http.Headers;
using System.Text;

namespace API.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    // TODO: finish auth
    private const string Realm = "sth";

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);

            if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeader.Parameter != null)
            { 
                var credentials = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authHeader.Parameter)
                    ).Split(":");
                var username = credentials[0];
                var password = credentials[1];

                if (IsAuthorized(username, password))
                {
                    await _next(context);
                    return; 
                }
            }
        }

        context.Response.Headers["WWW-Authenticate"] = $"Basic Realm={Realm}";
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    }

    public bool IsAuthorized(string username, string password)
    {
        return username == "admin" && password == "password";
    }
    
}
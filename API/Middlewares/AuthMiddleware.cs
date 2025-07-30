using System.Net.Http.Headers;
using System.Text;
using API.Models;
using Microsoft.EntityFrameworkCore;

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
                var dbContext = context.RequestServices.GetRequiredService<UniversityContext>();
                
                var credentials = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authHeader.Parameter)
                    ).Split(":");
                var username = credentials[0];
                var password = credentials[1];

                if (await IsAuthorized(username, password, dbContext))
                {
                    await _next(context);
                    return; 
                }
            }
        }

        context.Response.Headers["WWW-Authenticate"] = $"Basic Realm={Realm}";
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    }

    private async Task<bool> IsAuthorized(string username, string password, UniversityContext dbContext)
    {
        if (username == "admin" && password == "password")
        {
            return true;
        }
        
        // TODO: hashing and salt (in the db too)
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user is null)
        {
            return false;
        }
        
        return username == user.Username && password == user.HashedPassword;
    }
    
}
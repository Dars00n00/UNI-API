using System.ComponentModel;
using API.Middlewares;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddOpenApi();

builder.Services.AddDbContext<UniversityContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentsService, StudentsService>();

/*builder.Services.AddAuthentication();

builder.Services.AddAuthorization(x => 
    x.AddPolicy("basic", new AuthorizationPolicy 
    {
        
    }));*/

builder.Services.AddControllers();


builder.Services.AddSwaggerGen(o =>
{
    o.CustomSchemaIds(x => 
        x.GetCustomAttributes(false)
            .OfType<DisplayNameAttribute>()
            .FirstOrDefault()?
            .DisplayName ?? x.Name);
        
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "University API",
        Description = "API for university e-registry",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Dariusz",
            Email = "email@gmail.com",
            Url = new Uri("https://github.com/Dars00n00")
        }
    });
        
    o.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Name = "Basic Authorization",
        Description = "Basic ",
        In = ParameterLocation.Header,
        Scheme = "basic"
    });
    
    o.AddSecurityRequirement(new OpenApiSecurityRequirement()); 
});


var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "University API v1");
    c.DocExpansion(DocExpansion.List);
    c.DefaultModelExpandDepth(0);
    c.DisplayRequestDuration();
    c.EnableFilter(); 
});


app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

/*app.UseAuthentication();

app.UseAuthorization();*/

app.MapControllers();

app.Run();

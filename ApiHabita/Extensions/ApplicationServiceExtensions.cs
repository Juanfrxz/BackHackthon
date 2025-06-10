using System.Threading.RateLimiting;
using Application.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
namespace ApiHabita.Extensions;

public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()   // WithOrigins("https://dominio.com") 
                       .AllowAnyMethod()   // WithMethods("GET","POST") 
                       .AllowAnyHeader()); // WithHeaders("accept","content-type") 
        });
    public static void AddAplicacionServices(this IServiceCollection services)
    {

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
            {
                services.AddRateLimiter(options =>
                {   
                    options.OnRejected = async (context, token) =>
                    {
                        var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";
                        context.HttpContext.Response.StatusCode = 429;
                        context.HttpContext.Response.ContentType = "application/json";
                        var mensaje = $"{{\"message\": \"Demasiadas peticiones desde la IP {ip}. Intenta más tarde.\"}}";
                        await context.HttpContext.Response.WriteAsync(mensaje, token);
                    };

                    // Aquí no se define GlobalLimiter
                    options.AddPolicy("ipLimiter", httpContext =>
                    {
                        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
                        return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromSeconds(10),
                            QueueLimit = 0,
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                        });
                    });
                    
                });

                return services;
        }
} 

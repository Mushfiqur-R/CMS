using Microsoft.AspNetCore.RateLimiting;
using System.Net;
using System.Threading.RateLimiting;

namespace CMS.Extensions
{
    public static class RateLimiterExtensions
    {
     
        public const string CreateOrganizationPolicy = "create-organization-policy";
        public const string AuthPolicy = "auth-policy";
        public const string GeneralPolicy = "general-policy";

        public static IServiceCollection AddCustomRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                options.OnRejected = async (context, cancellationToken) =>
                {
                    context.HttpContext.Response.ContentType = "application/json";

                    var response = new
                    {
                        success = false,
                        message = "Too many requests. Please slow down and try again later.",
                        statusCode = StatusCodes.Status429TooManyRequests
                    };

                    await context.HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                };

              
                options.AddPolicy(CreateOrganizationPolicy, httpContext =>
                {
                    var clientIp = GetClientIp(httpContext);

                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: clientIp,
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromMinutes(10),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        });
                });

                
                options.AddPolicy(AuthPolicy, httpContext =>
                {
                    var clientIp = GetClientIp(httpContext);

                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: clientIp,
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromMinutes(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        });
                });

                options.AddPolicy(GeneralPolicy, httpContext =>
                {
                    var clientIp = GetClientIp(httpContext);

                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: clientIp,
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 2,
                            Window = TimeSpan.FromMinutes(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 2
                        });
                });
            });

            return services;
        }

        private static string GetClientIp(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor))
            {
                var ip = forwardedFor.FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim();
                if (!string.IsNullOrEmpty(ip))
                {
                    return ip;
                }
            }

            return httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown-ip";
        }
    }
}

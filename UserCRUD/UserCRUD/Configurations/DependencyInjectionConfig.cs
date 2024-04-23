using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace UserCRUD.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjection(
            this IServiceCollection services
            )
        {
            services.AddScoped(provider =>
            {
                var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;

                if (httpContext == null)
                {
                    return CultureInfo.InvariantCulture;
                }

                return httpContext.Request.Headers.TryGetValue("language", out var language)
                    ? new CultureInfo(language!)
                    : CultureInfo.InvariantCulture;
            });

            return services;
        }
    }
}

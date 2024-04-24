using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UserCRUD.Data.Entities;
using UserCRUD.Data.Repositories.UserRepository;
using UserCRUD.Domain.Models;
using UserCRUD.Domain.Queries.Handlers;
using UserCRUD.Domain.Queries.Request;

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

            #region CommandHandlers
            #endregion

            #region QueryHandlers
            services.AddScoped<IRequestHandler<GeAllUsersQuery, IEnumerable<User>>, GetAllUsersQueryHandler>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}

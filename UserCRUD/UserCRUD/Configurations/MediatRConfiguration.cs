using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using UserCRUD.Configurations.FluentValidation;

namespace UserCRUD.Configurations
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

            var assembly = AppDomain.CurrentDomain.Load("UserCRUD.Domain");
            AssemblyScanner
            .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandPipelineValidationBehavior<,>));

            return services;
        }
    }
}

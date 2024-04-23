using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using UserCRUD.Configurations.EnvironmentVariables;
using UserCRUD.Data;
using UserCRUD.Domain.Models;

namespace UserCRUD.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, AppSettingsModel appSettings)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DataContext>(options =>
            {
                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = appSettings.ConnectionSettings.POSTGRES_HOST,
                    Port = int.Parse(appSettings.ConnectionSettings.POSTGRES_PORT),
                    Database = appSettings.ConnectionSettings.POSTGRES_DATABASE,
                    Username = appSettings.ConnectionSettings.POSTGRES_USERNAME,
                    Password = appSettings.ConnectionSettings.POSTGRES_PASSWORD,
                };

                var connectionString = builder.ToString();
#if DEBUG
                options
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging(
                        AspnetcoreEnvironment.IsCurrentAspnetcoreEnvironmentValue(AspnetcoreEnvironmentEnum.Docker)
                        || AspnetcoreEnvironment.IsCurrentAspnetcoreEnvironmentValue(AspnetcoreEnvironmentEnum.Development));
#endif
                options
                    .UseNpgsql(connectionString,
                        builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            });

            return services;
        }
    }
}

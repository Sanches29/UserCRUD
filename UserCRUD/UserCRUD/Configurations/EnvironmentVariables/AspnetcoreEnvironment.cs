using System.Collections.Generic;
using System;

namespace UserCRUD.Configurations.EnvironmentVariables
{
    public static class AspnetcoreEnvironment
    {
        public static bool IsCurrentAspnetcoreEnvironmentValue(AspnetcoreEnvironmentEnum environmentEnum)
        {
            if (!new Dictionary<AspnetcoreEnvironmentEnum, string>
        {
            {
                AspnetcoreEnvironmentEnum.Production,
                "production"
            },
            {
                AspnetcoreEnvironmentEnum.Development,
                "development"
            },
            {
                AspnetcoreEnvironmentEnum.Docker,
                "docker"
            }
        }.TryGetValue(environmentEnum, out var value))
            {
                return false;
            }

            return value == Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();
        }
    }

    public enum AspnetcoreEnvironmentEnum
    {
        Production,
        Development,
        Docker
    }
}

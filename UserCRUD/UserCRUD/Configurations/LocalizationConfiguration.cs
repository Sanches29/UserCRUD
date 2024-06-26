﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace UserCRUD.Configurations
{
    public static class LocalizationConfiguration
    {
        public static void UseLocalizationConfiguration(this IApplicationBuilder app)
        {
            var supportedCultures = new[]{
                new CultureInfo("pt-BR"), new CultureInfo("es-MX")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        }
    }
}

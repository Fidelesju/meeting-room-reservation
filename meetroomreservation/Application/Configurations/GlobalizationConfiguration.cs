using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;

namespace meetroomreservation.Controller
{
    public static class GlobalizationConfiguration
    {
        public static IApplicationBuilder UseGlobalizationConfiguration(this IApplicationBuilder app)
        {
            CultureInfo defaultCulture = new CultureInfo("pt-BR");
            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> {defaultCulture},
                SupportedUICultures = new List<CultureInfo> {defaultCulture}
            };
            app.UseRequestLocalization(localizationOptions);

            return app;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace meetroomreservation.Controller
{
    public static class DependecyInjectionConfiguration
    {
        public static void RegisterService(this IServiceCollection services)
        {
            ConfigurationDbsDependeyInjection(services);
            ConfigurationServicesDependeyInjection(services);
            ConfigurationRepositoriesDependeyInjection(services);
            ConfigurationMapperDependeyInjection(services);
        }

        private static void ConfigurationServicesDependeyInjection(IServiceCollection services)
        {

        }
        private static void ConfigurationDbsDependeyInjection(IServiceCollection services)
        {
            
        }
        private static void ConfigurationMapperDependeyInjection(IServiceCollection services)
        {
            
        }
         private static void ConfigurationRepositoriesDependeyInjection(IServiceCollection services)
        {
            
        }
    }
}
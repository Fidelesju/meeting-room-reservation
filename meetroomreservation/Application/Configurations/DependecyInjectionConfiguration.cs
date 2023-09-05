using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Business.Mapper;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Services;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.Data.Repositories;
using meetroomreservation.Data.Repositories.Interfaces;
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
            //services.AddScoped<IUserService,UserService>();
        }
        private static void ConfigurationDbsDependeyInjection(IServiceCollection services)
        {
            
        }
        private static void ConfigurationMapperDependeyInjection(IServiceCollection services)
        {
            //services.AddScoped<IUserCreateMapper,UserCreateMapper>();
        }
         private static void ConfigurationRepositoriesDependeyInjection(IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Business.CoreServices;
using meetroomreservation.Business.Mapper;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Services;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.CoreServices;
using meetroomreservation.CoreServices.Interfaces;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileManagementService, FileManagementService>();
            services.AddScoped<ICryptographyService, CryptographyService>();
            services.AddScoped<IEmailManagementService, EmailManagementService>();
            services.AddScoped<ILoggerService, LoggerService>();

        }
        private static void ConfigurationDbsDependeyInjection(IServiceCollection services)
        {

        }
        private static void ConfigurationMapperDependeyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserCreateMapper,UserCreateMapper>();
        }
        private static void ConfigurationRepositoriesDependeyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
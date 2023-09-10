using meetroomreservation.Business.CoreServices;
using meetroomreservation.Business.Mapper;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Services;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.CoreServices;
using meetroomreservation.CoreServices.Interfaces;
using meetroomreservation.Data.Dao;
using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.Repositories;
using meetroomreservation.Data.Repositories.Interfaces;

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
            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<ISchedulingService, SchedulingService>();

        }
        private static void ConfigurationDbsDependeyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserDb, UserDb>();
            services.AddScoped<IAuthDb, AuthDb>();
        }
        private static void ConfigurationMapperDependeyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserCreateMapper, UserCreateMapper>();
            services.AddScoped<ISchedulingCreateMapper, SchedulingCreateMapper>();
            services.AddScoped<ISchedulingUpdateMapper, SchedulingUpdateMapper>();
            services.AddScoped<IUserUpdateMapper, UserUpdateMapper>();
        }
        private static void ConfigurationRepositoriesDependeyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
        }
    }
}
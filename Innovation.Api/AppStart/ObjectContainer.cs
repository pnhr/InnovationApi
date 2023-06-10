using Innovation.Api.Auth;
using Innovation.Api.AutoMapperProfiles;
using Innovation.Api.Services.Definitions;
using Innovation.Api.Services.Interfaces;
using Innovation.Data;
using Innovation.Data.Definitions;
using Innovation.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Innovation.Api.AppStart
{
    public static class ObjectContainer
    {
        public static IServiceCollection AddApplicationObjects(this IServiceCollection services)
        {
            services.AddServiceDependencies();
            services.AddRepository();
            services.AddOthes();
            return services;
        }

        private static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthorizationHandler, AppSpecificHandler>();
            services.AddScoped<IAuthorizationHandler, WindowsAuthNHandler>();
        }
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository, AppRepository>();
        }
        private static void AddOthes(this IServiceCollection services)
        {
            services.AddScoped<LogAttribute>();
            services.AddAutoMapper(typeof(EmployeeAutoMapperProfile));
        }
    }
}

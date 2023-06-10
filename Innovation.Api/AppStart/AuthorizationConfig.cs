using Innovation.Api.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;

namespace Innovation.Api.AppStart
{
    public static class AuthorizationConfig
    {
        public static IServiceCollection AddAppAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthorization();
            return services;
        }
    }
}

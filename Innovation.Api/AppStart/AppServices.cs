using Innovation.Data.Constants;
using Microsoft.IdentityModel.Logging;

namespace Innovation.Api.AppStart
{
    public static class AppServices
    {
        public static WebApplicationBuilder AddAppServices(this WebApplicationBuilder builder)
        {
            IdentityModelEventSource.ShowPII = true;
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddApplicationObjects();
            builder.Services.AddAuthenticationSchemes(builder.Configuration);
            builder.Services.AddAppAuthorization(builder.Configuration);
            builder.Services.AddSwaggerWithAutherization(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AppConstants.APP_CORS_POLICY,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials();
                                  });
            });


            return builder;
        }
    }
}

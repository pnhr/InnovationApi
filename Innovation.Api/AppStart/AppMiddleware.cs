
using Innovation.Data.Constants;

namespace Innovation.Api.AppStart
{
    public static class AppMiddleware
    {
        public static void AddMiddlewares(this WebApplication app, IConfiguration configuration)
        {
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId(configuration["SwaggerAzureAd:ClientId"]);
                c.OAuthUsePkce();
                c.OAuthScopeSeparator(" "); //It is requried only when there are more then one scope exists. in our case we have only one scope and not requried

            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(AppConstants.APP_CORS_POLICY);

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapRazorPages();
            app.MapControllers();

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.MapFallbackToFile("index.html");
            app.Run();
        }
    }
}

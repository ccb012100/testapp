using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WebApp.Extensions
{
    public static class AppBuilderExtensions
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static IApplicationBuilder ConfigureEndpoints(this IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration config)
        {
            return app.UseStaticFiles()
                .UseEndpoints(endpoints =>
                {
                    if (env.IsDevelopment())
                    {
                        // view app settings at ~/debug
                        endpoints.MapGet("/debug",
                            async context =>
                            {
                                string configRoot = (config as IConfigurationRoot).GetDebugView();
                                await context.Response.WriteAsync(configRoot);
                            });
                    }

                    endpoints.MapControllers();
                });
        }
    }
}

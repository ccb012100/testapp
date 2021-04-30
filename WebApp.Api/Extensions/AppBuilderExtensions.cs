using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WebApp.Api.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder ConfigureEndpoints(this IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration config)
        {
            return app.UseEndpoints(endpoints =>
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
                    endpoints.MapGet("/",
                        async context =>
                        {
                            await context.Response.WriteAsync(
                                $"{Assembly.GetExecutingAssembly().Location}\n\n{DateTime.Now}");
                        });
                }

                endpoints.MapControllers();
            });
        }
    }
}

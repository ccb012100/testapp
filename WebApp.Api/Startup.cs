using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // ReSharper disable once CA1822
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApp", Version = "v1"}); })
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once CA1822
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory,
            IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Playlister v1"));
            }

            app.UseHttpsRedirection().UseRouting().UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    if (env.IsDevelopment())
                    {
                        // view app settings at ~/debug
                        endpoints.MapGet("/debug",
                            async context =>
                            {
                                string config = (Configuration as IConfigurationRoot).GetDebugView();
                                await context.Response.WriteAsync(config);
                            });
                        endpoints.MapGet("/",
                            async context =>
                            {
                                await context.Response.WriteAsync($"{GetType().Namespace} - {DateTime.Now}");
                            });
                    }

                    endpoints.MapControllers();
                });

            ILogger<Startup> logger = loggerFactory.CreateLogger<Startup>();
            appLifetime.ApplicationStarted.Register(() => OnStarted(logger));
            appLifetime.ApplicationStopping.Register(() => OnStopping(logger));
            appLifetime.ApplicationStopped.Register(() => OnStopped(logger));
        }

        private void OnStarted(ILogger logger) => logger.LogInformation($"{GetType().Namespace} Started");

        private void OnStopping(ILogger logger) => logger.LogInformation($"{GetType().Namespace} Stopping");

        private void OnStopped(ILogger logger) => logger.LogInformation($"{GetType().Namespace} Stopped");
    }
}
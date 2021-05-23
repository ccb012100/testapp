using System.IO;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApp.Extensions;

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
            services
                .AddAppSettingsOptions(Configuration)
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddHttpClients()
                .AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApp", Version = "v1"}); })
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
                    .UseSwagger()
                    .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp v1");
                        c.RoutePrefix = ""; // serve on ~/
                    });
            }

            // The default HSTS value is 30 days.
            // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseStaticFiles(new StaticFileOptions
                {
                    // host Pages/* at ~/app/*
                    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Pages")),
                    RequestPath = "/app"
                })
                .ConfigureEndpoints(env, Configuration);

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

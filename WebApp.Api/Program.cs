using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace WebApp
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(LogDevelopmentConfiguration)
                .UseStartup<Startup>();

        private static void LogDevelopmentConfiguration(WebHostBuilderContext context, KestrelServerOptions options)
        {
            if (context.HostingEnvironment.IsDevelopment())
            {
                ShowConfig(context.Configuration);
            }
        }

        private static void ShowConfig(IConfiguration configuration)
        {
            foreach (IConfigurationSection pair in configuration.GetChildren())
            {
                Console.WriteLine($"{pair.Path} - {pair.Value}");
                ShowConfig(pair);
            }
        }
    }
}

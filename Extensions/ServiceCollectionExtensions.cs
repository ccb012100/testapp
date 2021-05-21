using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using WebApp.HttpClients;
using WebApp.Options;

namespace WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppSettingsOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<JsonPlaceholderApiOptions>()
                .Bind(configuration.GetSection(JsonPlaceholderApiOptions.JsonPlaceholderApi))
                .ValidateDataAnnotations();

            services.AddOptions<ReqResApiOptions>()
                .Bind(configuration.GetSection(ReqResApiOptions.ReqResApi))
                .ValidateDataAnnotations();

            return services;
        }

        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddRefitClient<IJsonPlaceholderApi>()
                .ConfigureHttpClient((svc, client) =>
                {
                    client.BaseAddress = svc.GetService<IOptions<JsonPlaceholderApiOptions>>()?.Value.BaseAddress;
                });

            services.AddRefitClient<IReqResApi>(new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver =
                                new DefaultContractResolver
                                {
                                    NamingStrategy = new SnakeCaseNamingStrategy()
                                }
                        })
                })
                .ConfigureHttpClient((svc, client) =>
                {
                    client.BaseAddress = svc.GetService<IOptions<ReqResApiOptions>>()?.Value.BaseAddress;
                });

            return services;
        }
    }
}

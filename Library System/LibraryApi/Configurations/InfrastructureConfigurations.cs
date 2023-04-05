using LibraryInfrastructure.NationalLibraryApi;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace LibraryDatabase.Configurations
{
    public static class InfrastructureConfigurations
    {
        public static IServiceCollection AddInfrastructureConfigurations(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<HttpClient>()
                .AddScoped<INationalLibraryApiClient, NationalLibraryApiClient>();
        }
    }
}

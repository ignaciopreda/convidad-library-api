using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LibraryDatabase.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Library API", 
                    Version = "v1" ,
                    Description = "Swagger UI to a Library API"
                });
            });
        }

        public static IApplicationBuilder UseSwaggerApi(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing Library API V1");
                });
        }

    }
}

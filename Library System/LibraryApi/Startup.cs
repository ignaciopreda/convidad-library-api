using AutoMapper;
using Books.Api.Configuration;
using LibraryDatabase.Configurations;
using LibraryDomain.MappingConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryDatabase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddSingleton<Dictionary<int, Book>>(new Dictionary<int, Book>());
            services.AddLibraryDbContext(Configuration.GetConnectionString("DefaultConnection"));

            services.AddDomainConfiguration();

            services.AddInfrastructureConfigurations();

            services.AddRepositoryConfiguration();

            services.ConfigureSwagger();

            services.AddHttpClient();

            var mapperConfiguration = new MapperConfiguration(mc => {
                mc.AddProfile(new MapProfile());
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerApi();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
using LibraryPersistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryDatabase.Configurations
{
    public static class DbContextConfigurations
    {
        public static IServiceCollection AddLibraryDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            return serviceCollection
                .AddDbContext<LibraryDbContext>(options =>
                    options.UseSqlServer(connectionString),
                    ServiceLifetime.Transient
                    );
        }
    }
}

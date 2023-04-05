using LibraryDomain.Authors;
using LibraryDomain.Books;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Api.Configuration
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomainConfiguration(this IServiceCollection serviceCollection) 
        {
            return serviceCollection
                .AddScoped<IAuthorDomain, AuthorDomain>()
                .AddScoped<IBookDomain, BookDomain>();
        }
    }
}

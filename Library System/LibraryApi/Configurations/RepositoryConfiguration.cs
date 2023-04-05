using LibraryPersistence.Entities;
using LibraryPersistence.ExpressionMapper;
using LibraryPersistence.Filters;
using LibraryPersistence.Mappers;
using LibraryPersistence.Persistence.Authors;
using LibraryPersistence.Persistence.Books;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Api.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection serviceCollection) 
        {
            serviceCollection
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IBookRepository, BookRepository>();

            serviceCollection
                .AddTransient<IExpressionMapperPersistence<Book, BookFiltersModel>, BookExpressionMapper>();

            return serviceCollection;
        }
    }
}

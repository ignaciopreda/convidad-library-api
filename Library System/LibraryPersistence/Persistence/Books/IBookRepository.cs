using LibraryPersistence.Entities;
using LibraryPersistence.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryPersistence.Persistence.Books
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);
        Task<Book> GetBookAsync(int id);
        Task<IEnumerable<Book>> GetBooksByFiltersAsync(BookFiltersModel bookFilters);
        Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);
    }
}

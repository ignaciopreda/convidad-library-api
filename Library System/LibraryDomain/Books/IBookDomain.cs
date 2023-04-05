using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryDomain.Books
{
    public interface IBookDomain
    {
        Task<CreatedBookDto> AddBookAsync(CreateBookDto createBookDto);
        Task<BookDto> GetBookAsync(int id);
        Task<IEnumerable<BookDto>> GetBooksByFiltersAsync(BookFiltersDto bookFiltersDto);
        Task<IEnumerable<BookDto>> GetExternalBooksAsync();
    }
}
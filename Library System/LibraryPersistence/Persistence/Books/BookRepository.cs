using LibraryPersistence.Data;
using LibraryPersistence.Data.SampleData;
using LibraryPersistence.Entities;
using LibraryPersistence.Filters;
using LibraryPersistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryPersistence.Persistence.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IExpressionMapperPersistence<Book, BookFiltersModel> _bookExpressionMapper;
        public BookRepository(
            LibraryDbContext dbContext,
            IExpressionMapperPersistence<Book, BookFiltersModel> bookExpressionMapper
            )
        {
            _dbContext = dbContext;
            _bookExpressionMapper = bookExpressionMapper;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);

            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksByFiltersAsync(BookFiltersModel bookFilters)
        {
            var result = GetQueryBuilt(bookFilters);

            return result.ToList();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        private IQueryable<Book> GetQueryBuilt(BookFiltersModel bookFilters)
        { 
            var expression = _bookExpressionMapper.CreateExpression(bookFilters);

            var query = _dbContext.Books
                .Include(b => b.Author)
                .Where(expression)
                .AsNoTracking();

            return query;
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId)
        {
            var books = _dbContext.Books
                .Where(b => b.AuthorId == authorId)
                .AsNoTracking()
                .ToList();

            return books;
        }
    }
}

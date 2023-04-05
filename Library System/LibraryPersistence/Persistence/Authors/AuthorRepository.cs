using LibraryPersistence.Data;
using LibraryPersistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryPersistence.Persistence.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;
        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _dbContext.Authors.Add(author);

            await _dbContext.SaveChangesAsync();

            return author;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

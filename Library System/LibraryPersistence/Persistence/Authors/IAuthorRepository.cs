using LibraryPersistence.Entities;
using System.Threading.Tasks;

namespace LibraryPersistence.Persistence.Authors
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> GetByIdAsync(int id);
    }
}

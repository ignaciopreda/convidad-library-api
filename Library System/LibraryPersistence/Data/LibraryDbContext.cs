using LibraryPersistence.Entities;
using LibraryPersistence.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureLibraryModels();
        }
    }
}

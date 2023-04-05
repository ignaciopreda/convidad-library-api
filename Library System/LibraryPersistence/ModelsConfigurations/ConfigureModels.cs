using LibraryPersistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.ModelsConfigurations
{
    public static class ConfigureModels
    {
        public static void ConfigureLibraryModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

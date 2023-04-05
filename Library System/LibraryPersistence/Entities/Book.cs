using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryPersistence.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
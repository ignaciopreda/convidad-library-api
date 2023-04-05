using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPersistence.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
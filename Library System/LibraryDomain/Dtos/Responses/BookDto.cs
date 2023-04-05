using System;

namespace LibraryDomain.Dtos.Responses
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime PublicationDate { get; set; }
        public AuthorDto Author { get; set; }
    }
}

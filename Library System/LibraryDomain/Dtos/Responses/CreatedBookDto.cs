using System;

namespace LibraryDomain.Dtos.Responses
{
    public class CreatedBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
    }
}

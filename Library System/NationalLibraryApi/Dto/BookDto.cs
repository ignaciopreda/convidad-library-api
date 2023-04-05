using LibraryDomain.Dtos.Responses;
using System;

namespace NationalLibraryApi.Dto
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

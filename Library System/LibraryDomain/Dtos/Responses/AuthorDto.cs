using System;

namespace LibraryDomain.Dtos.Responses
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

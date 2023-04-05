using System;
using System.Collections.Generic;

namespace LibraryDomain.Dtos.Responses
{
    public class CreatedAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<CreatedBookDto> Books {get; set;}
    }
}

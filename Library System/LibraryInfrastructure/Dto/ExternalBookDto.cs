using System;

namespace LibraryInfrastructure.Dto
{
    public class ExternalBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime PublicationDate { get; set; }
        public ExternalAuthorDto Author { get; set; }
    }
}

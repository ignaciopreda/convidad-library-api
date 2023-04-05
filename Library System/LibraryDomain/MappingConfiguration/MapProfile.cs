using AutoMapper;
using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using LibraryInfrastructure.Dto;
using LibraryPersistence.Entities;
using LibraryPersistence.Filters;

namespace LibraryDomain.MappingConfiguration
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            AuthorMapping();
            BookMapping();
        }

        private void AuthorMapping()
        {
            CreateMap<CreateAuthorDto, Author>();

            CreateMap<Author, CreatedAuthorDto>();
            CreateMap<Author, AuthorDto>();

            CreateMap<ExternalAuthorDto, AuthorDto>();
        }

        private void BookMapping()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<CreateBookForAuthorDto, Book>();
            CreateMap<BookFiltersDto, BookFiltersModel>();

            CreateMap<Book, CreatedBookDto>();
            CreateMap<Book, BookDto>();

            CreateMap<ExternalBookDto, BookDto>();
        }
    }
}

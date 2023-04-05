using AutoMapper;
using LibraryCommon.Handlers.ErrorHandling;
using LibraryDomain.Books;
using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using LibraryInfrastructure.NationalLibraryApi;
using LibraryPersistence.Entities;
using LibraryPersistence.Filters;
using LibraryPersistence.Persistence.Authors;
using LibraryPersistence.Persistence.Books;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryDomain.Authors
{
    public class BookDomain : IBookDomain
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly INationalLibraryApiClient _nationalLibraryApiClient;
        private readonly IConfiguration _configuration;

        public BookDomain(
            IMapper mapper,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            INationalLibraryApiClient nationalLibraryApiClient,
            IConfiguration configuration
            )
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _nationalLibraryApiClient = nationalLibraryApiClient;
            _configuration = configuration;
        }

        public async Task<CreatedBookDto> AddBookAsync(CreateBookDto createBookDto)
        {
            var author = await _authorRepository.GetByIdAsync(createBookDto.AuthorId);

            if (author is null)
                throw new NotFoundException(ExceptionMessages.InvalidAuthorId);

            var bookMapped = _mapper.Map<Book>(createBookDto);

            var book = await _bookRepository.AddBookAsync(bookMapped);

            return _mapper.Map<CreatedBookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByFiltersAsync(BookFiltersDto bookFiltersDto)
        {
            var bookFilersMapped = _mapper.Map<BookFiltersModel>(bookFiltersDto);

            var books = await _bookRepository.GetBooksByFiltersAsync(bookFilersMapped);

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookAsync(int id)
        {
            var book = await _bookRepository.GetBookAsync(id);

            if (book is null)
                throw new NotFoundException(ExceptionMessages.InvalidBookId);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetExternalBooksAsync()
        {
            string externalServiceUrl = _configuration.GetValue<string>("ExternalServices:NationalLibraryApiUrl");

            var externalBooks = await _nationalLibraryApiClient.GetBooksAsync(externalServiceUrl);

            var externalBooksMapped= _mapper.Map<IEnumerable<BookDto>>(externalBooks);

            return externalBooksMapped;
        }
    }
}

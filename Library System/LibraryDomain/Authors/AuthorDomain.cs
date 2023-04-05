using AutoMapper;
using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using LibraryPersistence.Entities;
using LibraryPersistence.Persistence.Authors;
using System.Threading.Tasks;

namespace LibraryDomain.Authors
{
    public class AuthorDomain : IAuthorDomain
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorDomain(
            IMapper mapper,
            IAuthorRepository authorRepository
            )
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<CreatedAuthorDto> AddAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = await _authorRepository.AddAuthorAsync(_mapper.Map<Author>(createAuthorDto));

            return _mapper.Map<CreatedAuthorDto>(author);
        }
    }
}

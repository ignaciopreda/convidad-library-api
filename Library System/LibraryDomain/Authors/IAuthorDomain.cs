using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using System.Threading.Tasks;

namespace LibraryDomain.Authors
{
    public interface IAuthorDomain
    {
        Task<CreatedAuthorDto> AddAuthorAsync(CreateAuthorDto createAuthorDto);
    }
}

using LibraryInfrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryInfrastructure.NationalLibraryApi
{
    public interface INationalLibraryApiClient
    {
        Task<IEnumerable<ExternalBookDto>> GetBooksAsync(string externalServiceUrl);
    }
}

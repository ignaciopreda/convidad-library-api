using LibraryCommon.Handlers.ErrorHandling;
using LibraryInfrastructure.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryInfrastructure.NationalLibraryApi
{
    public class NationalLibraryApiClient : INationalLibraryApiClient
    {
        private readonly HttpClient _httpClient;

        public NationalLibraryApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ExternalBookDto>> GetBooksAsync(string externalServiceUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{externalServiceUrl}/{ConstantControllers.NationalLibraryApi.GetBooksAsync}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<ExternalBookDto>>(content);
                    return result;
                }
                else
                    throw new ExternalServiceException(response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new ExternalServiceException(ex.Message, ex);
            }
        }
    }
}

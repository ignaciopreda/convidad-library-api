using LibraryDatabase;
using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryIntegrationTest.Controllers
{
    public class AuthorsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AuthorsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task AddAuthorAsync_ValidRequest_ReturnsCreatedAuthor()
        {
            // Arrange
            var client = _factory.CreateClient();
            var createAuthorDto = new CreateAuthorDto
            {
                Name = "Charles Dickens",
                Nationality = "British",
                BirthDate = new System.DateTime(1870, 7, 31)
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(createAuthorDto), Encoding.UTF8, "application/json");

            // Act
            var postResponse = await client.PostAsync("/authors", stringContent);
            postResponse.EnsureSuccessStatusCode();

            var responseContent = await postResponse.Content.ReadAsStringAsync();
            var createdAuthor = JsonConvert.DeserializeObject<AuthorDto>(responseContent);

            // Assert
            Assert.NotNull(createdAuthor.Id);
            Assert.Equal(createAuthorDto.Name, createdAuthor.Name);
            Assert.Equal(createAuthorDto.Nationality, createdAuthor.Nationality);
            Assert.Equal(createAuthorDto.BirthDate, createdAuthor.BirthDate);
        }

        [Fact]
        public async Task GetRandomAuthorsAsync_ReturnsRandomAuthors()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var getResponse = await client.GetAsync("/authors/random");
            getResponse.EnsureSuccessStatusCode();

            var responseContent = await getResponse.Content.ReadAsStringAsync();
            var authors = JsonConvert.DeserializeObject<AuthorDto[]>(responseContent);

            // Assert
            Assert.NotNull(authors);
            Assert.NotEmpty(authors);
        }
    }
}

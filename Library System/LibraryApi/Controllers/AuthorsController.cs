using Bogus;
using LibraryDomain.Authors;
using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Controllers
{
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorDomain _authorDomain;

        public AuthorsController(
            IAuthorDomain authorDomain
            )
        {
            _authorDomain = authorDomain;
        }

        // POST /authors
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAuthorAsync([FromBody] CreateAuthorDto createAuthorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authorDomain.AddAuthorAsync(createAuthorDto);

            return Ok(result);
        }

        // GET /authors/random
        [HttpGet("/Authors/random")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRandomAuthorsAsync()
        {
            var authorId = 1;

            var authors = new Faker<AuthorDto>()
                .RuleFor(x => x.Id, authorId++)
                .RuleFor(x => x.Name, f => f.Name.Random.ToString())
                .RuleFor(x => x.Nationality, f => f.Locale.ToString())
                .RuleFor(x => x.BirthDate, f => f.Date.Past(100, DateTime.Now.AddYears(-18)))
                .Generate(3_000_000);

            return File(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(authors)), "application/json", "random-authors.json");
        }

    }
}
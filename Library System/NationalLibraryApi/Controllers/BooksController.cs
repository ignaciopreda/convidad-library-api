using Bogus;
using LibraryDomain.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalLibraryApi.Dto;
using System;
using System.Threading.Tasks;

namespace NationalLibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        // GET /books
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetBooksAsync()
        {
            int bookId = 1;
            int authorId = 1;

            var result = new Faker<BookDto>()
                .RuleFor(x => x.Id, f => bookId++)
                .RuleFor(x => x.Title, f => f.Name.Random.ToString())
                .RuleFor(x => x.Isbn, f => f.Hashids.ToString())
                .RuleFor(x => x.PublicationDate, f => f.Date.Past(100, DateTime.Now.AddYears(-18)))
                .RuleFor(x => x.Author, f => new Faker<AuthorDto>()
                    .RuleFor(a => a.Id, f => authorId++)
                    .RuleFor(a => a.Name, f => f.Name.Random.ToString())
                    .RuleFor(a => a.Nationality, f => f.Locale.ToString())
                    .RuleFor(a => a.BirthDate, f => f.Date.Past(80))
                    .Generate(1)[0])
                .Generate(10);

            return Ok(result);
        }

    }
}

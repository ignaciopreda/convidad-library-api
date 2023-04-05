using LibraryCommon.Handlers.ErrorHandling;
using LibraryDomain.Books;
using LibraryDomain.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryDatabase.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookDomain _bookDomain;

        public BooksController(
            IBookDomain bookDomain
            )
        {
            _bookDomain = bookDomain;
        }

        // POST /books
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookAsync([FromBody] CreateBookDto createBookDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _bookDomain.AddBookAsync(createBookDto);

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST /books/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookAsync([FromRoute] int id)
        {
            try
            {
                var book = await _bookDomain.GetBookAsync(id);

                return Ok(book);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBooksByFiltersAsync([FromQuery] BookFiltersDto bookFiltersDto)
        {
            var books = await _bookDomain.GetBooksByFiltersAsync(bookFiltersDto);

            return Ok(books);
        }

        // POST /books/external
        [HttpGet("/Books/external")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExternalBooksAsync()
        {
            var books = await _bookDomain.GetExternalBooksAsync();

            return Ok(books);
        }

    }
}
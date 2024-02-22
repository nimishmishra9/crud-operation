using CodeFistApproach.Models;
using CodeFistApproach.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFistApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        //[HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _authorsService.GetAuthors();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorsService.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<Author>>PostAuthor(Author author)
        {
            await _authorsService.PostAuthor(author);
            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            try
            {
               await _authorsService.PutAuthor(id, author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorsService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            await _authorsService.DeleteAuthor(id);
            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _authorsService.AuthorExists(id);
        }

    }
}

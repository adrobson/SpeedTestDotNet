using Microsoft.AspNetCore.Mvc;
using SpeedTest.API.Controllers.DTOs;
using SpeedTest.Context.Models;
using SpeedTest.Repository;
using SpeedTest.Repository.Interfaces;
using SpeedTest.Repository.ViewModels;

namespace SpeedTest.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(ILogger<AuthorController> logger,
            IAuthorRepository AuthorRepository
            )
        {
            _logger = logger;
            _authorRepository = AuthorRepository;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> AddAuthor(AuthorDTO newAuthorDTO)
        {
            var newAuthor = new Author
            {
                AuthorName = newAuthorDTO.AuthorName,
                CompanyId = newAuthorDTO.CompanyId
            };

            await _authorRepository.Insert(newAuthor);

            return CreatedAtAction(nameof(GetAuthor),
                new { id = newAuthor.AuthorId },
                ItemToDTO(newAuthor));
        }

        [HttpPut]
        public async Task<ActionResult<Author>> UpdateAuthor(Author author)
        {
            await _authorRepository.Update(author);

            return author;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await _authorRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var Author = await _authorRepository.GetOne(id);
            if(Author == null)
            {
                return NotFound();
            }

            return await _authorRepository.GetOne(id);
        }

        [HttpGet("[action]/{numAuthors}")]
        public IEnumerable<AuthorRating> Top(int numAuthors)
        {
            return _authorRepository.Top(numAuthors);
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _authorRepository.All();
        }

        private static AuthorDTO ItemToDTO(Author Author) =>
            new AuthorDTO
            {
                AuthorId = Author.AuthorId,
                AuthorName = Author.AuthorName
            };
    }
}

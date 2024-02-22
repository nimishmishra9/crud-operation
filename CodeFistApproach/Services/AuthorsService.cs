using CodeFistApproach.Models;
using CodeFistApproach.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CodeFistApproach.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsService(IAuthorsRepository authorsRepository)
        { 
            _authorsRepository = authorsRepository;
        }

        public Task<ActionResult<Author>> GetAuthor(int id)
        {
            return _authorsRepository.GetAuthor(id);
        }

        public Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return _authorsRepository.GetAuthors();
        }

        public Task<int> PostAuthor(Author author)
        {
            return _authorsRepository.PostAuthor(author);
        }

        public Task<int> PutAuthor(int id, Author author)
        {
            return _authorsRepository.PutAuthor(id, author);
        }
        public Task<int> DeleteAuthor(int id)
        {
            return _authorsRepository.DeleteAuthor(id);
        }
        public bool AuthorExists(int id)
        {
            return _authorsRepository.AuthorExists(id);
        }
    }
}

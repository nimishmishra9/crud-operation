using CodeFistApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFistApproach.Repository
{
    public interface IAuthorsRepository
    {
        public Task<ActionResult<IEnumerable<Author>>> GetAuthors();
        public Task<ActionResult<Author>> GetAuthor(int id);
        public Task<int> PostAuthor(Author author);
        public Task<int> PutAuthor(int id, Author author);
        public Task<int> DeleteAuthor(int id);
        public bool AuthorExists(int id);
    }
}

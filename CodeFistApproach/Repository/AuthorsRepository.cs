using CodeFistApproach.Entity;
using CodeFistApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CodeFistApproach.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BookDBContext _bookDBContext;
        public AuthorsRepository(BookDBContext bookDBContext) 
        {
               _bookDBContext = bookDBContext;
        }
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _bookDBContext.Authors.ToListAsync();
        }

        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
          return await _bookDBContext.Authors.FindAsync(id);   
        }

        [HttpPost]
        public async Task<int> PostAuthor(Author author)
        {
            _bookDBContext.Authors.Add(author);
            return  await _bookDBContext.SaveChangesAsync();
        }

        public async Task<int> PutAuthor(int id, Author author)
        {
            _bookDBContext.Entry(author).State = EntityState.Modified;
            try
            {
              return await _bookDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteAuthor(int id)
        {
            var author = await _bookDBContext.Authors.FindAsync(id);
            _bookDBContext.Authors.Remove(author);
            return await _bookDBContext.SaveChangesAsync();
        }

        public bool AuthorExists(int id)
        {
            return _bookDBContext.Authors.Any(e => e.Id == id);
        }

    }
}

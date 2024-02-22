using CodeFistApproach.Entity;
using CodeFistApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFistApproach.Repository
{
    public class BooksRepository : IBookRepository
    {
        private readonly BookDBContext _dbContext;
        public BooksRepository(BookDBContext bookDBContext) 
        { 
          _dbContext = bookDBContext;
        }

        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _dbContext.Book.ToListAsync();
        }
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _dbContext.Book.FindAsync(id);
        }
        public async Task<int> PostBook(Book book)
        {
            _dbContext.Book.Add(book);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> PutBook(int id, Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            try
            {
              return  await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task<int> DeleteBook(int id)
        {
            var book = await _dbContext.Book.FindAsync(id);
            _dbContext.Book.Remove(book);
           return await _dbContext.SaveChangesAsync();
        }
        public bool BookExists(int id)
        {
            return _dbContext.Book.Any(e => e.Id == id);
        }
       
    }
}

using CodeFistApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFistApproach.Repository
{
    public interface IBookRepository
    {
        public Task<ActionResult<IEnumerable<Book>>> GetBooks();
        public Task<ActionResult<Book>> GetBook(int id);
        public Task<int> PostBook(Book book);
        public Task<int> PutBook(int id, Book book);
        public Task<int> DeleteBook(int id);
        public bool BookExists(int id);
    }
}

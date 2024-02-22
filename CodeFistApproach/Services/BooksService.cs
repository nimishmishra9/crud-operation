using CodeFistApproach.Models;
using CodeFistApproach.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CodeFistApproach.Services
{
    public class BooksService : IBooksService
    {
        IBookRepository _bookRepository;
        public BooksService(IBookRepository bookRepository) 
        {
            _bookRepository=bookRepository;
        }
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _bookRepository.GetBook(id);
        }
        public async Task<int> PostBook(Book book)
        {
            return await _bookRepository.PostBook(book);
        }
        public async Task<int> PutBook(int id, Book book)
        {
            return await  _bookRepository.PutBook(id, book);
        }
        public async Task<int> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }
        public bool BookExists(int id)
        {
            return  _bookRepository.BookExists(id);
        }
       
    }
}

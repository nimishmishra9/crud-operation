using CodeFistApproach.Repository;

namespace CodeFistApproach.Services
{
    public class BooksService : IBooksService
    {
        IBookRepository _bookRepository;
        public BooksService(IBookRepository bookRepository) 
        {
            _bookRepository=bookRepository;
        }
       
    }
}

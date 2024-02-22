using CodeFistApproach.Entity;

namespace CodeFistApproach.Repository
{
    public class BooksRepository : IBookRepository
    {
        private readonly BookDBContext _dbContext;
        public BooksRepository(BookDBContext bookDBContext) 
        { 
          _dbContext = bookDBContext;
        }
      
    }
}

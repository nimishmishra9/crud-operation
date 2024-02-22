using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFistApproach.Models
{
    public class Author
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id  { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

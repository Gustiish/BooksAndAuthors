using BooksAndAuthors.Data;
using BooksAndAuthors.Models;

namespace BooksAndAuthors.Classes
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
        public double PaidRevenue { get; set; }

        public virtual List<BookViewModel> Books { get; set; }


    }
}

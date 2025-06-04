using BooksAndAuthors.Data;
using BooksAndAuthors.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Classes
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
        public double PaidRevenue { get; set; }

        public virtual List<BookViewModel>? Books { get; set; }

        [NotMapped]
        public BookViewModel Book { get; set; }


    }
}

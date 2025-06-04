

using BooksAndAuthors.Classes;
using BooksAndAuthors.Data;

namespace BooksAndAuthors.Models
{
    public class BookViewModel : IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Release { get; set; } = DateOnly.FromDateTime(DateTime.Now);


    }
}

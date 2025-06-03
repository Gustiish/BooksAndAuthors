using BooksAndAuthors.Data;

namespace BooksAndAuthors.Classes
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PaidRevenue { get; set; }



    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Classes.Author> Authors { get; set; }
        public DbSet<Models.BookViewModel> Books { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}


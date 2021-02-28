using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Book.Infrastructure
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Domain.Book> Books { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Author.Infrastructure
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Domain.Author> Authors { get; set; }
    }
}

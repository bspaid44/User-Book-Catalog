using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserLibrary.Models
{
    public class UserLibraryDbContext : IdentityDbContext 
    {
        public UserLibraryDbContext(DbContextOptions<UserLibraryDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}

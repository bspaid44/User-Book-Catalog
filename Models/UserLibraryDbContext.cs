using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserLibrary.Models
{
    public class UserLibraryDbContext : IdentityDbContext 
    {
        public UserLibraryDbContext()
        {
        }

        public UserLibraryDbContext(DbContextOptions<UserLibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<UserBooks> UserBooks { get; set; }
    }
}

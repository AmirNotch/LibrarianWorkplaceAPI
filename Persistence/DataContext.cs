using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.MigrateAsync();
        }
        
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
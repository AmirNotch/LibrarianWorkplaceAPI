using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.MigrateAsync();
        }
        
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReader> BookReaders { get; set; }
        //public DbSet<HistoryBook> HistoryBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<BookReader>(x => x.HasKey(br => new {br.BookGuid, br.ReaderGuid}));

            builder.Entity<BookReader>()
                .HasOne(u => u.Book)
                .WithMany(u => u.Readers)
                .HasForeignKey(br => br.BookGuid);
            
            builder.Entity<BookReader>()
                .HasOne(u => u.Reader)
                .WithMany(u => u.Books)
                .HasForeignKey(br => br.ReaderGuid);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Booking.Domain;
using Booking.Persistence.Database.Configuration;

namespace Booking.Persistence.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Booking");

            new BookConfiguration(builder.Entity<Book>());
        }

    }
}

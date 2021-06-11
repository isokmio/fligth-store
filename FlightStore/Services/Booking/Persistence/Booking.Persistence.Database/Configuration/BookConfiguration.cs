using Booking.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Persistence.Database.Configuration
{
    public class BookConfiguration
    {
        public BookConfiguration(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(x => x.BookId);
            builder.HasIndex(x => x.ReservationCode);

            builder.Property(x => x.ReservationCode).IsRequired();
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
        }
    }
}

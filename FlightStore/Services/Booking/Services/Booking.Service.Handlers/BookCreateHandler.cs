using Booking.Domain;
using Booking.Persistence.Database;
using Booking.Service.Handlers.Commands;
using MediatR;
using Service.Common.RandomEx;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Service.Handlers
{
    public class BookCreateHandler : INotificationHandler<CreateBookCommand>
    {
        private ApplicationDbContext _context;

        public BookCreateHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            Random rand = new Random();
            string fligthNumber = rand.NextString(6);

            await _context.AddAsync(new Book
            {
                FullName = command.FullName,
                Email = command.Email,
                Phone = command.Phone,
                FlightId = command.FlightId,
                FligthNumber = fligthNumber,
            });

            await _context.SaveChangesAsync();
        }
    }
}

using Booking.Domain;
using Booking.Persistence.Database;
using Booking.Service.Handlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            string code = rand.NextString(10);
            var book = new Book
            {
                FullName = command.FullName,
                Email = command.Email,
                Phone = command.Phone,
                FlightId = command.FlightId,
                ReservationCode = code,
            };

            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();

        }
    }
}

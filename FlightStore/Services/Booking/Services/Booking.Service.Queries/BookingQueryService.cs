using Booking.Domain;
using Booking.Persistence.Database;
using Booking.Service.Queries.DTO;
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapper;
using System;
using System.Threading.Tasks;

namespace Booking.Service.Queries
{
    public interface IBookingQueryService
    {
        Task<BookDto> GetBookById(int id);

        Task<BookDto> GetBookByFlightNumder(string flightNumber);
    }

    public class BookingQueryService: IBookingQueryService
    {
        ApplicationDbContext _context = null;

        public BookingQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var book = new Book();

            if (await _context.Books.CountAsync() > 0) {
                book = await _context.Books.SingleAsync(x => x.BookId == id);
            }            

            return book.MapTo<BookDto>();
        }

        public async Task<BookDto> GetBookByFlightNumder(string flightNumber)
        {
            var book = new Book();

            if (await _context.Books.CountAsync() > 0)
            {
                book = await _context.Books.SingleAsync(x => x.FligthNumber == flightNumber);
            }

            return book.MapTo<BookDto>();
        }
    }
}

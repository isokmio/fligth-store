using Booking.Domain;
using Booking.Persistence.Database;
using Booking.Service.Queries.DTO;
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapper;
using System.Threading.Tasks;

namespace Booking.Service.Queries
{
    public interface IBookingQueryService
    {
        Task<BookDto> GetBookById(int id);
        Task<BookDto> GetBook(string flightNumber, string email);
        Task<BookDto> GetBookByReservationCode(string code);
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

            if (await _context.Books.CountAsync() > 0) 
            {
                book = await _context.Books.SingleAsync(x => x.BookId == id);
            }            

            return book.MapTo<BookDto>();
        }

        public async Task<BookDto> GetBook(string numberFlight, string email)
        {
            var book = new Book();

            if (await _context.Books.CountAsync() > 0)
            {
                book = await _context.Books.SingleAsync(x => x.NumberFlight == numberFlight && x.Email == email);
            }

            return book.MapTo<BookDto>();
        }

        public async Task<BookDto> GetBookByReservationCode(string code)
        {
            var book = new Book();

            if (await _context.Books.CountAsync() > 0)
            {
                book = await _context.Books.SingleAsync(x => x.ReservationCode == code);
            }

            return book.MapTo<BookDto>();
        }
    }
}

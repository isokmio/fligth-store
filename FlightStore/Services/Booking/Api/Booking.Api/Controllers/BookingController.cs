using Booking.Persistence.Database;
using Booking.Service.Handlers.Commands;
using Booking.Service.Queries;
using Booking.Service.Queries.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookingController : Controller
    {
        private readonly IBookingQueryService _bookingQueryService;
        private readonly IMediator _mediator;

        public BookingController(IBookingQueryService bookingQueryService, IMediator mediator)
        {
            _bookingQueryService = bookingQueryService;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetById(int id)
        {
            return await _bookingQueryService.GetBookById(id);
        }

        [HttpGet("token/{flightNumber}")]
        public async Task<BookDto> GetByFlightNumber(string flightNumber)
        {
            return await _bookingQueryService.GetBookByReservationCode(flightNumber);
        }

        [HttpPost]
        public async Task<BookDto> Create(CreateBookCommand command)
        {
            // Verify flight availability

            // Create number flight reservation

            // Create book entry
            await _mediator.Publish(command);

            return await _bookingQueryService.GetBook(command.NumberFlight, command.Email);
        }
    }
}

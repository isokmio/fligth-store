using MediatR;

namespace Booking.Service.Handlers.Commands
{
    public class CreateBookCommand: INotification
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int FlightId { get; set; }
        public string NumberFlight { get; set; }
    }
}

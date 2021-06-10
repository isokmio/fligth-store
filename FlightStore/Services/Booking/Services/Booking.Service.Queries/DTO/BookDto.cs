using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Service.Queries.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int FlightId { get; set; }
        public string FligthNumber { get; set; }
    }
}

using System;

namespace Schedule.Service.Queries.DTO
{
    public class FlightDto
    {
        public int FlightId { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}

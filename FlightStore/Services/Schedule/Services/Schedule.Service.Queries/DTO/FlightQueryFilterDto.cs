using System;

namespace Schedule.Service.Queries.DTO
{
    public class FlightQueryFilterDto
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime From { get; set; }
    }
}

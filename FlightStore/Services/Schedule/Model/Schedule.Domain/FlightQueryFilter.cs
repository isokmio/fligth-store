using System;

namespace Schedule.Domain
{
    public class FlightQueryFilter
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
    }
}

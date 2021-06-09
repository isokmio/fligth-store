using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Domain
{
    public class Transport
    {
        public int TransportId { get; set; }
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }

    }
}

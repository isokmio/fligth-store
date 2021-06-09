using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain;
using Service.Common.MasterCollection;
using Service.Common.RandomEx;
using System;
using System.Collections.Generic;

namespace Schedule.Persistence.Database.Configuration
{

    public static class CurrencyCode
    {
        public static string Colombia = "$";
    }

    public class ScheduleFlightConfiguration
    {

        public ScheduleFlightConfiguration(EntityTypeBuilder<Flight> builder)
        {
            builder.HasIndex(x => x.FlightId);
            builder.Property(x => x.DepartureStation).IsRequired();
            builder.Property(x => x.ArrivalStation).IsRequired();
            builder.Property(x => x.DepartureDate).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Currency).IsRequired();

            List<string> AirportCodes = MasterCollection.GetAirportIataCodeList();
            List <Flight> flights = new List<Flight>();
            Random rand = new Random();
            DateTime basetime = DateTime.Now;

            for (int i = 0; i < AirportCodes.Count; i++)
            {
                for (int j = 0; j < AirportCodes.Count; j++)
                {
                    if (i != j)
                    {
                        int index = (i * AirportCodes.Count) + j;
                        DateTime departureDate = basetime.AddHours(index);

                        flights.Add(new Flight
                        {
                            FlightId = index,
                            DepartureStation = AirportCodes[i],
                            ArrivalStation = AirportCodes[j],
                            DepartureDate = departureDate,
                            Price = rand.Next(200, 1000),
                            Currency = CurrencyCode.Colombia
                        });
                    }
                }
            }

            builder.HasData(flights);
        }
    }

    public class ScheduleTransportConfiguration 
    {
        public ScheduleTransportConfiguration(EntityTypeBuilder<Transport> builder)
        {
            builder.HasIndex(x => x.TransportId);
            builder.Property(x => x.FlightId).IsRequired();
            builder.Property(x => x.FlightNumber).IsRequired().HasMaxLength(6);

            List<Transport> transports = new List<Transport>();
            Random rand = new Random();

            for (int i = 1; i <= 400; i++) 
            {
                transports.Add(new Transport
                {
                    TransportId = i,
                    FlightId = rand.Next(1, 100),
                    FlightNumber = rand.NextString(6)
                });
            }

            builder.HasData(transports);
        }

    }

    

}

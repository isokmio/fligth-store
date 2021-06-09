using Microsoft.EntityFrameworkCore;
using Schedule.Domain;
using Schedule.Persistence.Database.Configuration;
using System;

namespace Schedule.Persistence.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Schedule");

            new ScheduleFlightConfiguration(builder.Entity<Flight>());
            new ScheduleTransportConfiguration(builder.Entity<Transport>());
        }
    }
}

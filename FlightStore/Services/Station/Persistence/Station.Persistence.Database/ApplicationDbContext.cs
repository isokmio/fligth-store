using Microsoft.EntityFrameworkCore;
using Station.Model;
using Station.Persistence.Database.Configurations;
using System;

namespace Station.Persistence.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<StationNode> Stations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Master");

            new StationConfiguration(builder.Entity<StationNode>());
        }

    }
}

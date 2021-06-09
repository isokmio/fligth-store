using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Common.MasterCollection;
using Station.Model;
using System.Collections.Generic;

namespace Station.Persistence.Database.Configurations
{
    public class StationConfiguration
    {
        public StationConfiguration(EntityTypeBuilder<StationNode> builder) 
        {
            builder.HasIndex(x => x.StationNodeId);
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();

            List<StationNode> nodes = new List<StationNode>();
            int index = 1;

            foreach(KeyValuePair<string, string> node in MasterCollection.AirportIata)
            {
                nodes.Add(new StationNode
                {
                    StationNodeId = index++,
                    Code = node.Key,
                    Name = node.Value
                });
            }

            builder.HasData(nodes);

        }
    }
}

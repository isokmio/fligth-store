using System;
using System.Collections.Generic;

namespace Service.Common.MasterCollection
{
    public static class MasterCollection
    {

        public static readonly Dictionary<string, string> AirportIata 
            = new Dictionary<string, string> 
            { 
                {"AXM", "Armenia" },
                {"BAQ", "Barranquilla" },
                {"BOG", "Bogota" },
                {"BGA", "Bucaramanga" },
                {"CLO", "Cali" },
                {"CUC", "Cucuta" },
                {"CTG", "Cartagena" },
                {"LET", "Leticia" },
                {"MDE", "Medellin" },
                {"PEI", "Pereira" },              
            };


        public static List<string> GetAirportIataCodeList() 
        {
            return new List<string>(AirportIata.Keys);
        }
    }
}

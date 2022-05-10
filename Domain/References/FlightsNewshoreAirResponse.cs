using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.References
{
    public class FlightsNewshoreAirResponse
    {
        public string? DepartureStation { get; set; }

        public string? ArrivalStation { get; set; }

        public string? FlightCarrier { get; set; }

        public int FlightNumber { get; set; }

        public decimal Price { get; set; }
    }
}

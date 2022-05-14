using Domain.Entities;
using Domain.References;

namespace Application.Contracts.Infrastructure
{
    public interface IMapperService
    {
        public Flight ConvertFlightNewShoreToFlight(FlightsNewshoreAirResponse flightsNewshoreAirResponse);

        public Transport ConvertFlightNewShoreToTransport(FlightsNewshoreAirResponse flightsNewshoreAirResponse);
    }
}

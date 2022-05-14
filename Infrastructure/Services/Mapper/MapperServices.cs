using Application.Contracts.Infrastructure;
using AutoMapper;
using Domain.Entities;
using Domain.References;

namespace Infrastructure.Services.Mapper
{
    public class MapperServices : IMapperService
    {
        private readonly IMapper mapper;

        public MapperServices(IMapper mapper)
        {
            this.mapper = mapper;
        }


        public Flight ConvertFlightNewShoreToFlight(FlightsNewshoreAirResponse flightsNewshoreAirResponse)
        {
            return mapper.Map<Flight>(flightsNewshoreAirResponse);
        }

        public Transport ConvertFlightNewShoreToTransport(FlightsNewshoreAirResponse flightsNewshoreAirResponse)
        {
            return mapper.Map<Transport>(flightsNewshoreAirResponse);
        }


    }
}

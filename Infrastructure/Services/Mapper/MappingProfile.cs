using AutoMapper;
using Domain.Entities;
using Domain.References;

namespace Infrastructure.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FlightsNewshoreAirResponse, Flight>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.DepartureStation))
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.ArrivalStation)); 
            CreateMap<FlightsNewshoreAirResponse, Transport>();
        }

    }
}

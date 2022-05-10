using Domain.References;

namespace Application.Contracts.Infrastructure
{
    public interface INewshoreAirServices
    {
        public List<FlightsNewshoreAirResponse> GetFlights(int route);
    }
}

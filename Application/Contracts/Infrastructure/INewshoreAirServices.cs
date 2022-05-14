using Domain.Entities;

namespace Application.Contracts.Infrastructure
{
    public interface INewshoreAirServices
    {
        public List<Flight> GetFlights(int route);
    }
}

using Application.Contracts.Infrastructure;
using Domain.Dtos;
using Domain.Entities;
using Domain.References;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Services.Integration
{
    public class NewshoreAirServices: INewshoreAirServices
    {
        private readonly IMapperService mapperService;
        private readonly HttpClient client;
        private readonly Credential credential;

        public NewshoreAirServices(IOptions<Credential> _credential, IMapperService mapperService)
        {
            this.credential = _credential.Value;
            client = new HttpClient();
            this.mapperService = mapperService;
        }

        public List<Flight> GetFlights(int route)
        {
            var flights = new List<Flight>();
            var flightsNewshoreResponse = JsonConvert.DeserializeObject<List<FlightsNewshoreAirResponse>>(Get(route));

            foreach (var flightNewshore in flightsNewshoreResponse)
            {
                var flight = mapperService.ConvertFlightNewShoreToFlight(flightNewshore);
                flight.Transport = mapperService.ConvertFlightNewShoreToTransport(flightNewshore);
                flights.Add(flight);
            }

            return flights;
        }

        private string Get(int route)
        {
            var response = client.GetAsync(credential.Url + route).Result;
            var result = response.Content.ReadAsStringAsync();
            return result.Result;
        }

    }
}

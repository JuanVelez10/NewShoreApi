using Application.Contracts.Infrastructure;
using Domain.Dtos;
using Domain.References;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Services.Integration
{
    public class NewshoreAirServices: INewshoreAirServices
    {

        private readonly HttpClient client;
        private readonly Credential credential;

        public NewshoreAirServices(IOptions<Credential> _credential)
        {
            this.credential = _credential.Value;
            client = new HttpClient();
        }

        public List<FlightsNewshoreAirResponse> GetFlights(int route)
        {
            return JsonConvert.DeserializeObject<List<FlightsNewshoreAirResponse>>(Get(route));
        }

        private string Get(int route)
        {
            var response = client.GetAsync(credential.Url + route).Result;
            var result = response.Content.ReadAsStringAsync();
            return result.Result;
        }

    }
}

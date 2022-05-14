using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Interfaces;
using Application.References;
using Domain.Entities;
using Newtonsoft.Json;
using static Domain.Enums.Enums;

namespace Application.Services
{
    public class JourneyServices : IJourneyServices
    {
        private readonly IStoreRepository storeRepository;
        private readonly IMessageServices messageServices;
        private readonly INewshoreAirServices newshoreAirServices;

        public JourneyServices(IStoreRepository storeRepository, IMessageServices messageServices, INewshoreAirServices newshoreAirServices)
        {
            this.storeRepository = storeRepository;
            this.messageServices = messageServices;
            this.newshoreAirServices = newshoreAirServices;
        }

        public async Task<BaseResponse<List<Journey>>> Get(string origin, string destination, int route)
        {
            var response = ValidateRoute(origin, destination, route);
            if (response.Code > 0) return response;

            response = FindStore(origin, destination, route);
            if (response.Code > 0) return response;

            var flights = newshoreAirServices.GetFlights(route);

            var routes = GetAllRoutes(flights,origin, destination);
            var jourynes = GetJourneys(flights, routes, origin, destination);

            if (route == 2) {
               var routes_return =  GetAllRoutes(flights, destination, origin);
               jourynes.AddRange(GetJourneys(flights, routes_return, destination, origin));
            }

            NewStore(origin, destination, route, jourynes);

            response = MessageResponse(1, MessageType.Success, "Journeys");
            response.Data = jourynes;

            return response;
        }

        //Method new store
        private void NewStore(string origin, string destination, int route, List<Journey> journeys)
        {
            var store = new Store();
            store.Origin = origin;
            store.Destination = destination;
            store.Route = route;
            store.Response = JsonConvert.SerializeObject(journeys);
            storeRepository.Insert(store);
        }

        //Method to calculate and return trips by routes
        private List<Journey> GetJourneys(List<Flight> flights, List<List<string>> routes, string origin, string destination)
        {
            var journeys = new List<Journey>();
            foreach (var route in routes)
            {
                var journey = new Journey();
                journey.Origin = origin;
                journey.Destination = destination;
                journey.Flights = new List<Flight>();

                for (var i=0; i < route.Count() - 1 ;i++)
                {
                    var flight = flights.Where(x => x.Origin == route[i] && x.Destination == route[i+1]).FirstOrDefault();
                    journey.Price = journey.Price + flight.Price;
                    journey.Flights.Add(flight);
                }

                journeys.Add(journey);

            }

            return journeys;
        }

        //Method for calculating routes Inicial
        private List<List<string>> GetAllRoutes(List<Flight> flights, string origin, string destination)
        {
            var routes = new List<List<string>>();

            var flihtsFind = flights.Where(x => x.Origin == origin);

            foreach (var fliht in flihtsFind)
            {
                var route = GetRoute(flights, new List<string>(), fliht.Origin, fliht.Destination,origin,destination);
                if (route.Any()) routes.Add(route); 
            }

            return routes;
        }

        //Method for calculating recursive routes
        private List<string> GetRoute(List<Flight> flights,List<string> route, string origin, string destination,string originInitial,string destinationInitial)
        {
            route.Add(origin);

            if (destination == destinationInitial)
            {
                route.Add(destination);
            }
            else
            {
                var flihtsFind = flights.Where(x => x.Origin == destination);

                foreach (var fliht in flihtsFind)
                {
                    if (!route.Contains(fliht.Origin))
                        GetRoute(flights, route, fliht.Origin, fliht.Destination, originInitial, destinationInitial);
                }

            }

            if (route.Any() && route.First() == originInitial && route.Last() != destinationInitial) route.Remove(origin);
            return route;
        }

        //Method Validate if the route already exists in store and return it if it exists
        private BaseResponse<List<Journey>> FindStore(string origin, string destination, int route)
        {
            var response = new BaseResponse<List<Journey>>();
            var store = storeRepository.GetAll().Where(x => x.Origin == origin && x.Destination == destination && x.Route == route).FirstOrDefault();
          
            if (store != null && !string.IsNullOrEmpty(store.Response))
            {
                response = MessageResponse(1, MessageType.Success, "Journeys");
                response.Data = JsonConvert.DeserializeObject<List<Journey>>(store.Response);
            }

            return response;
        }

        //Method Validate if the incoming values are valid if not return error
        private BaseResponse<List<Journey>> ValidateRoute(string origin, string destination, int route)
        {
            if (string.IsNullOrEmpty(origin)) return MessageResponse(4, MessageType.Error, "Origin");
            if (string.IsNullOrEmpty(destination)) return MessageResponse(4, MessageType.Error, "destination");
            if (route < 0 || route > 2) return MessageResponse(4, MessageType.Error, "Route");
            return new BaseResponse<List<Journey>>();
        }

        //Method to return response message
        private BaseResponse<List<Journey>> MessageResponse(int code, MessageType messageType, string additionalMessage = "")
        {
            var response = new BaseResponse<List<Journey>>();
            response.Code = code;
            response.Message = String.Format("{0} {1}", messageServices.GetMessage(code, messageType), additionalMessage);
            response.MessageType = messageType;
            return response;
        }


    }
}

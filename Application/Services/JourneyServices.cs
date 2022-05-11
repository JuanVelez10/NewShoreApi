using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Interfaces;
using Application.References;
using Domain.Entities;

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
            throw new NotImplementedException();
        }



    }
}

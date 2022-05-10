using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
    }
}

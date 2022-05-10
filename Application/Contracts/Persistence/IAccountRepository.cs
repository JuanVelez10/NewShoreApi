using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IAccountRepository
    {
        Account Get(Guid? id);
        List<Account> GetAll();
    }
}

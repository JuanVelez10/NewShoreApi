using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly NewshoreContext dbContext;

        public AccountRepository(NewshoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Account Get(Guid? id)
        {
            return dbContext.Account.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Account> GetAll()
        {
            return dbContext.Account.ToList();
        }

    }
}

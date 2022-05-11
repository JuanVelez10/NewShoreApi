using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly NewshoreContext dbContext;

        public StoreRepository(NewshoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Store> GetAll()
        {
            return dbContext.Store.ToList();
        }

        public bool Insert(Store store)
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    store.Id = Guid.NewGuid();

                    dbContext.Store.Add(store);

                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }

        }

    }
}

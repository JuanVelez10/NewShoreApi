using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly NewshoreContext dbContext;

        public MessageRepository(NewshoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Message> GetAll()
        {
            return dbContext.Message.ToList();
        }

    }
}

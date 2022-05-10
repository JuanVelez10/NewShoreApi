using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataBase
{
    public class NewshoreContext : DbContext
    {

        public NewshoreContext(DbContextOptions<NewshoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasKey(table => new {
                table.Code,
                table.MessageType
            });

        }

        public virtual DbSet<Store>? Store { get; set; }
        public virtual DbSet<Account>? Account { get; set; }
        public virtual DbSet<Message>? Message { get; set; }
    }
}

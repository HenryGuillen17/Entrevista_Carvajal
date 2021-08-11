using Microsoft.EntityFrameworkCore;
using UserBackEnd.Infraestructure.Contracts.Context;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.EntityConfig;

namespace UserBackEnd.Infraestructure.Context
{
    public class UserDbContext : DbContext, IUserDbContext
    {

        public DbSet<IdentificationTypeEntity> IdentificationTypeEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        
        
        public UserDbContext()
        {
        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserEntity>());
            IdentificationTypeEntityConfig.SetEntityBuilder(modelBuilder.Entity<IdentificationTypeEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}

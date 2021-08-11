using Microsoft.EntityFrameworkCore;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.Contracts.Context
{
    public interface IUserDbContext : IDbContext
    {
        public DbSet<IdentificationTypeEntity> IdentificationTypeEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
    
    }
}

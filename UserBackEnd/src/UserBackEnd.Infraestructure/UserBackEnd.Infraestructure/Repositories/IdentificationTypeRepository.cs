using Microsoft.EntityFrameworkCore;
using UserBackEnd.Infraestructure.Contracts.Context;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.Contracts.Repository;

namespace UserBackEnd.Infraestructure.Repositories
{
    public class IdentificationTypeRepository : Repository<IdentificationTypeEntity>, IIdentificationTypeRepository
    {
        public IdentificationTypeRepository(IUserDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<IdentificationTypeEntity> DbEntity => UserDbContext.IdentificationTypeEntities;
    }
}
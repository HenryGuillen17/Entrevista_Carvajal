using UserBackEnd.Infraestructure.Contracts.Context;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.Repositories
{
    public abstract class Repository<T> : BaseRepository<T>
        where T : class, IBaseEntity
    {

        protected IUserDbContext UserDbContext => _dbContext as IUserDbContext;

        protected Repository(IUserDbContext dbContext) : base(dbContext) { }
    }
}

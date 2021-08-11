using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserBackEnd.Infraestructure.Contracts.Context;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.Contracts.Repository;


namespace UserBackEnd.Infraestructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(IUserDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<UserEntity> DbEntity => UserDbContext.UserEntities;


        public UserEntity GetByEmail(UserEntity user)
        {
            return DbEntity.FirstOrDefault(x => x.Email == user.Email);
        }
    }
}

using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.Contracts.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByEmail(UserEntity map);
    }
}

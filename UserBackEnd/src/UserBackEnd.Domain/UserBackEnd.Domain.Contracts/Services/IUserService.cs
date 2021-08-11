using UserBackEnd.Domain.Contracts.Model;

namespace UserBackEnd.Domain.Contracts.Services
{
    public interface IUserService : IBaseCrudService<User>
    {
        User Login(User login);
    }
}

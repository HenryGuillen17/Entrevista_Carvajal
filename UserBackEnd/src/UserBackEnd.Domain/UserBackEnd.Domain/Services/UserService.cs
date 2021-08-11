using System.Threading.Tasks;
using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Domain.Contracts.Services;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.Contracts.Repository;
using UserBackEnd.Infraestructure.Mapper;

namespace UserBackEnd.Domain.Services
{
    public class UserService : BaseService<User, UserEntity>, IUserService
    {
        private new readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base(repository, new UserMapper())
        {
            _repository = repository;
        }


        public User Login(User login)
        {
            var model = _repository.GetByEmail(_mapper.Map(login));
            if (model != null && BCrypt.Net.BCrypt.Verify(login.Password, model.Password))
            {
                return _mapper.Map(model);
            }

            return null;
        }

        public new async Task<User> Add(User form)
        {
            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            var result = await base.Add(form);
            return result;
        }

        public new async Task<User> Update(User form)
        {
            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            var result = await base.Update(form);
            return result;
        }
    }
}

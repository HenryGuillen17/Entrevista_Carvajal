using UserBackEnd.Domain.Contracts.Mapper;
using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.Mapper
{
    public class UserMapper : IMapper<User, UserEntity>
    {
        public UserEntity Map(User dto)
        {
            return new UserEntity
            {
                UserId = dto.UserId,
                Name = dto.Name,
                LastName = dto.LastName,
                IdentificationTypeId = dto.IdentificationTypeId,
                IdentificationNumber = dto.IdentificationNumber,
                Email = dto.Email,
                Password = dto.Password,
            };
        }

        public User Map(UserEntity dto)
        {
            return new User
            {
                UserId = dto.UserId,
                Name = dto.Name,
                LastName = dto.LastName,
                IdentificationTypeId = dto.IdentificationTypeId,
                IdentificationNumber = dto.IdentificationNumber,
                Email = dto.Email,
                Password = dto.Password,
            };
        }
    }
}

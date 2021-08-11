using UserBackEnd.Domain.Contracts.Mapper;
using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.Mapper
{
    public class IdentificationTypeMapper : IMapper<IdentificationType, IdentificationTypeEntity>
    {
        public IdentificationType Map(IdentificationTypeEntity dto)
        {
            return new IdentificationType
            {
                Description = dto.Description,
                IdentificationTypeId = dto.IdentificationTypeId
            };
        }

        public IdentificationTypeEntity Map(IdentificationType dto)
        {
            return new IdentificationTypeEntity
            {
                Description = dto.Description,
                IdentificationTypeId = dto.IdentificationTypeId
            };
        }
    }
}
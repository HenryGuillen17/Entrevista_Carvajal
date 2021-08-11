using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Domain.Contracts.Services;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.Contracts.Repository;
using UserBackEnd.Infraestructure.Mapper;

namespace UserBackEnd.Domain.Services
{
    public class IdentificationTypeService 
        : BaseService<IdentificationType, IdentificationTypeEntity>, 
            IIdentificationTypeService
    {
        private new readonly IIdentificationTypeRepository _repository;

        public IdentificationTypeService(
            IIdentificationTypeRepository repository
        ) : base(repository, new IdentificationTypeMapper())
        {
            _repository = repository;
        }
    }
}
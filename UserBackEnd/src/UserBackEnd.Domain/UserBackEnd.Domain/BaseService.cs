using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBackEnd.Domain.Contracts.Mapper;
using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Domain.Contracts.Services;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.Contracts.Repository;

namespace UserBackEnd.Domain
{
    /// <summary>
    /// Base class for 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TS"></typeparam>
    public abstract class BaseService<T, TS> : IBaseCrudService<T>
        where T : IBaseModelDomain
        where TS : class, IBaseEntity
    {

        protected readonly IRepository<TS> _repository;
        protected readonly IMapper<T, TS> _mapper;

        protected BaseService(IRepository<TS> repository, IMapper<T, TS> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<T> Add(T entity)
        {
            var addedEntity = await _repository.Add(_mapper.Map(entity));
            return _mapper.Map(addedEntity);
        }

        public async Task<bool> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<T> Get(int id)
        {
            var entidad = await _repository.Get(id);
            return _mapper.Map(entidad);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var allEntities = await _repository.GetAll();
            return allEntities.Select(o => _mapper.Map(o));
        }

        public async Task<T> Update(T entity)
        {
            var map = _mapper.Map(entity);
            var updatedEntity = await _repository.Update(map);
            return _mapper.Map(updatedEntity);
        }

    }
}

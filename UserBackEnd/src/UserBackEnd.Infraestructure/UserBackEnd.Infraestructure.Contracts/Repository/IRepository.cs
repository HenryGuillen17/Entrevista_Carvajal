using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.Contracts.Repository
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task DeleteAsync(int id);
        Task Delete(Expression<Func<T, bool>> where);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
    }
}

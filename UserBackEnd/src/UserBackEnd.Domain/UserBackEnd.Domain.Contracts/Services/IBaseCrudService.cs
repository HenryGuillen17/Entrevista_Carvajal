using System.Collections.Generic;
using System.Threading.Tasks;
using UserBackEnd.Domain.Contracts.Model;

namespace UserBackEnd.Domain.Contracts.Services
{
    public interface IBaseCrudService<T>
        where T : IBaseModelDomain
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<bool> Delete(int id);
        Task<T> Update(T entity);

    }
}

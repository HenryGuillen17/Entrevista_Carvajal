using UserBackEnd.Domain.Contracts.Model;

namespace UserBackEnd.Domain.Contracts.Mapper
{
    public interface IMapper<T, TS>
        where T : IBaseModelDomain
        where TS : class
    {

        T Map(TS dto);
        TS Map(T dto);

    }
}

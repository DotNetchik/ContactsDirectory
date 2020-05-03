using System.Threading.Tasks;

namespace ContactsDirectory.Domain.Application
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);

        Task<T> Get(int id);

        Task Update(T entity);

        Task Delete(T entity);
    }
}

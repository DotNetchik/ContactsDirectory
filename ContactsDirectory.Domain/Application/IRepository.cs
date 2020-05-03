using System;
using System.Collections.Generic;
using System.Text;
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

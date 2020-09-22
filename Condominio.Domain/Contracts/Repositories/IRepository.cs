using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Domain.Contracts.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> Get();
    }
}

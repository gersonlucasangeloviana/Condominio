using GestaoGestaoCondominio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoCondominio.Domain.Contracts.Repositories
{
    public interface IMoradorRepository : IRepository<Morador>
    {
        Task<IEnumerable<Morador>> GetWithFamiliaAsync();
    }
}

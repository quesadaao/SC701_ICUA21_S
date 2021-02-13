using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    // Interfase encargada de definir como vamos a implementar los metodos de include
    // Esta misma Interfase implementa la interfase de repository para poder acceder a los metodos basicos
    public interface IRepositoryFoci: IRepository<Foci>
    {
        Task<IEnumerable<Foci>> GetAllWithAsync();
        Task<Foci> GetOneByIdWithAsync(int id);
    }
}

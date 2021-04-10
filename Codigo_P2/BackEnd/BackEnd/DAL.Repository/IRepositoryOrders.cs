using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Objects;

namespace DAL.Repository
{
    // Interfase encargada de definir como vamos a implementar los metodos de include
    // Esta misma Interfase implementa la interfase de repository para poder acceder a los metodos basicos
    public interface IRepositoryOrders : IRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetAllWithAsync();
        Task<Orders> GetOneByIdWithAsync(int id);
    }
}

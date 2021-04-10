using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    // Clase ques una extension de repository
    // Implementa la interfase IRepositoryOrders
    // Esta interfase se encarga de implementar los metodos que se necesitan implementar el include para devolver informacion relacionada
    public class RepositoryOrders : Repository<Orders>, IRepositoryOrders
    {
        //Constructor correspondiente a la clase
        //Parametro Context para poderlo recibir y utilizar
        public RepositoryOrders(SolutionDbContext solutionDBContext) : base(solutionDBContext)
        {

        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        public async Task<IEnumerable<Orders>> GetAllWithAsync()
        {
            return await context.Orders.Include(m => m.Customer).ToListAsync();
        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        // Solo trae un objeto
        public async Task<Orders> GetOneByIdWithAsync(int id)
        {
            return await context.Orders.Include(m => m.Customer).SingleOrDefaultAsync(m => m.OrderId == id);
        }

        // Metodo para obtener el context de Repository inicializado en el constructor de esta clase. 
        private SolutionDbContext context
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}

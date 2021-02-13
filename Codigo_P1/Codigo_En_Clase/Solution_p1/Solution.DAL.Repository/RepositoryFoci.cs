using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DO.Objects;
using Solution.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Solution.DAL.Repository
{
    // Clase ques una extension de repository
    // Implementa la interfase IRepositoryFoci
    // Esta interfase se encarga de implementar los metodos que se necesitan implementar el include para devolver informacion relacionada
    public class RepositoryFoci : Repository<Foci>, IRepositoryFoci
    {
        //Constructor correspondiente a la clase
        //Parametro Context para poderlo recibir y utilizar
        public RepositoryFoci(SolutionDBContext solutionDBContext):base(solutionDBContext) {
        
        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        public async Task<IEnumerable<Foci>> GetAllWithAsync()
        {
            return await context.Foci.Include(m => m.Group).ToListAsync();
        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        // Solo trae un objeto
        public async Task<Foci> GetOneByIdWithAsync(int id)
        {
            return await context.Foci.Include(m => m.Group).SingleOrDefaultAsync(m => m.FocusId == id);
        }

        // Metodo para obtener el context de Repository inicializado en el constructor de esta clase. 
        private SolutionDBContext context {
            get{ return dbContext as SolutionDBContext; }
        }
    }
}

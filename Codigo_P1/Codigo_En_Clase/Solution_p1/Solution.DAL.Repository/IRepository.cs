using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Solution.DAL.Repository
{
    // Patron Repository con .Net Core 
    // Uso de Generics con Repository 
    public interface IRepository<T> where T:class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();

        // Expression usada para queries especificos de una clase compleja
        // Retorna una lista 
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);

        // Expression usada para queries especificos de una clase compleja
        // Se puede hacer busquedas por nombres, por fechas o lo que uses como filtro en el predicado
        // Retorna un objeto 
        T GetOne(Expression<Func<T, bool>> predicado);

        // Obtengo un objeto donde su id es el primary key 
        T GetOneById(int id);

        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        void Commit();
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}

using Solution.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Solution.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SolutionDBContext dbContext;

        public Repository(SolutionDBContext context) 
        {
            this.dbContext = context;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
        }

        public IQueryable<T> AsQueryable()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Delete(T t)
        {
            try
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception ee)
            {
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else {
                dbContext.Set<T>().Add(t);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado);
        }

        public void Update(T t)
        {
            if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                dbContext.Set<T>().Attach(t);
            }

            dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
    }
}

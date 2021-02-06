using Solution.DAL.EF;
using Solution.DO.Interfaces;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.BS
{
    public class Group : ICRUD<Groups>
    {
        private SolutionDBContext dbContext = null;

        public Group(SolutionDBContext context) {
            this.dbContext = context;
        }

        public void Delete(Groups t)
        {
            new DAL.Group(dbContext).Delete(t);
        }

        public IEnumerable<Groups> GetAll()
        {
            return new DAL.Group(dbContext).GetAll();
        }

        public Groups GetOneById(int id)
        {
            return new DAL.Group(dbContext).GetOneById(id);
        }

        public void Insert(Groups t)
        {
            new DAL.Group(dbContext).Insert(t);
        }

        public void Update(Groups t)
        {
            new DAL.Group(dbContext).Update(t);
        }
    }
}

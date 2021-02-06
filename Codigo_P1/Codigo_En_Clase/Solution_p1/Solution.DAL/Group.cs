using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO;

namespace Solution.DAL
{
    public class Group : ICRUD<data.Objects.Groups>
    {
        private Repository<data.Objects.Groups> _repo = null;

        public Group(SolutionDBContext solutionDbContext) {
            _repo = new Repository<data.Objects.Groups>(solutionDbContext);
        }

        public void Delete(Groups t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<Groups> GetAll()
        {
            return _repo.GetAll();
        }

        public Groups GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(Groups t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(Groups t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}

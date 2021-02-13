using Solution.DAL.EF;
using Solution.DO.Interfaces;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class Foci : ICRUD<data.Foci>
    {
        private SolutionDBContext _repo = null;

        public Foci(SolutionDBContext solutionDBContext) {
            _repo = solutionDBContext;
        }

        public void Delete(data.Foci t)
        {
            new DAL.Foci(_repo).Delete(t);
        }

        public IEnumerable<data.Foci> GetAll()
        {
            return new DAL.Foci(_repo).GetAll();
        }

        public data.Foci GetOneById(int id)
        {

            return new DAL.Foci(_repo).GetOneById(id);
        }

        public void Insert(data.Foci t)
        {

            new DAL.Foci(_repo).Insert(t);
        }

        public void Update(data.Foci t)
        {

            new DAL.Foci(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Foci>> GetAllInclude()
        {
            return await new DAL.Foci(_repo).GetAllInclude();
        }

        public async Task<data.Foci> GetOneByIdInclude(int id)
        {
            return await new DAL.Foci(_repo).GetOneByIdInclude(id);
        }
    }
}

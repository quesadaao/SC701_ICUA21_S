using Solution.DAL.EF;
using Solution.DO.Interfaces;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class GroupRequests : ICRUD<data.GroupRequests>
    {
        private SolutionDBContext _repo = null;

        public GroupRequests(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.GroupRequests t)
        {
            new DAL.GroupRequests(_repo).Delete(t);
        }

        public IEnumerable<data.GroupRequests> GetAll()
        {
            return new DAL.GroupRequests(_repo).GetAll();
        }

        public data.GroupRequests GetOneById(int id)
        {

            return new DAL.GroupRequests(_repo).GetOneById(id);
        }

        public void Insert(data.GroupRequests t)
        {

            new DAL.GroupRequests(_repo).Insert(t);
        }

        public void Update(data.GroupRequests t)
        {

            new DAL.GroupRequests(_repo).Update(t);
        }

        public async Task<IEnumerable<data.GroupRequests>> GetAllInclude()
        {
            return await new DAL.GroupRequests(_repo).GetAllInclude();
        }

        public async Task<data.GroupRequests> GetOneByIdInclude(int id)
        {
            return await new DAL.GroupRequests(_repo).GetOneByIdInclude(id);
        }
    }
}

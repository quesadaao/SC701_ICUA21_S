using Solution.DAL.EF;
using Solution.DO.Interfaces;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class GroupComments : ICRUD<data.GroupComments>
    {
        private SolutionDBContext _repo = null;

        public GroupComments(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.GroupComments t)
        {
            new DAL.GroupComments(_repo).Delete(t);
        }

        public IEnumerable<data.GroupComments> GetAll()
        {
            return new DAL.GroupComments(_repo).GetAll();
        }

        public data.GroupComments GetOneById(int id)
        {

            return new DAL.GroupComments(_repo).GetOneById(id);
        }

        public void Insert(data.GroupComments t)
        {

            new DAL.GroupComments(_repo).Insert(t);
        }

        public void Update(data.GroupComments t)
        {

            new DAL.GroupComments(_repo).Update(t);
        }

        public async Task<IEnumerable<data.GroupComments>> GetAllInclude()
        {
            return await new DAL.GroupComments(_repo).GetAllInclude();
        }

        public async Task<data.GroupComments> GetOneByIdInclude(int id)
        {
            return await new DAL.GroupComments(_repo).GetOneByIdInclude(id);
        }
    }
}

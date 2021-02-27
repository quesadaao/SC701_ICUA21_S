using Solution.DAL.EF;
using Solution.DO.Interfaces;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class GroupInvitations : ICRUD<data.GroupInvitations>
    {
        private SolutionDBContext _repo = null;

        public GroupInvitations(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(_repo).Delete(t);
        }

        public IEnumerable<data.GroupInvitations> GetAll()
        {
            return new DAL.GroupInvitations(_repo).GetAll();
        }

        public data.GroupInvitations GetOneById(int id)
        {

            return new DAL.GroupInvitations(_repo).GetOneById(id);
        }

        public void Insert(data.GroupInvitations t)
        {

            new DAL.GroupInvitations(_repo).Insert(t);
        }

        public void Update(data.GroupInvitations t)
        {

            new DAL.GroupInvitations(_repo).Update(t);
        }

        public async Task<IEnumerable<data.GroupInvitations>> GetAllInclude()
        {
            return await new DAL.GroupInvitations(_repo).GetAllInclude();
        }

        public async Task<data.GroupInvitations> GetOneByIdInclude(int id)
        {
            return await new DAL.GroupInvitations(_repo).GetOneByIdInclude(id);
        }
    }
}

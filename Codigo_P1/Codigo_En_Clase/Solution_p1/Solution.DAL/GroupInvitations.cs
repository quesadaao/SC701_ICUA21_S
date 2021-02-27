using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class GroupInvitations : ICRUD<data.GroupInvitations>
    {
        private RepositoryGroupInvitations _repo = null;

        public GroupInvitations(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryGroupInvitations(solutionDbContext);
        }

        public void Delete(data.GroupInvitations t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.GroupInvitations GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupInvitations t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.GroupInvitations t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupInvitations> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.GroupInvitations>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.GroupInvitations> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}

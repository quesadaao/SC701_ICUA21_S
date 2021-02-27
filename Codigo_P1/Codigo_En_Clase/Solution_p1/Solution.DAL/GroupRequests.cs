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
    public class GroupRequests : ICRUD<data.GroupRequests>
    {
        private RepositoryGroupRequests _repo = null;

        public GroupRequests(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryGroupRequests(solutionDbContext);
        }

        public void Delete(data.GroupRequests t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.GroupRequests GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupRequests t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.GroupRequests t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupRequests> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.GroupRequests>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.GroupRequests> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}

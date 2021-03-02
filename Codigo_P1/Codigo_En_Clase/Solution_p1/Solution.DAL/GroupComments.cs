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

    public class GroupComments : ICRUD<data.GroupComments>
    {
        private RepositoryGroupComments _repo = null;

        public GroupComments(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryGroupComments(solutionDbContext);
        }

        public void Delete(data.GroupComments t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.GroupComments GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupComments t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.GroupComments t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupComments> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.GroupComments>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.GroupComments> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}

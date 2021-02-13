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
    public class Foci : ICRUD<data.Foci>
    {
        private RepositoryFoci _repo = null;

        public Foci(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryFoci(solutionDbContext);
        }

        public void Delete(data.Foci t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.Foci GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Foci t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.Foci t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.Foci> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Foci>> GetAllInclude() {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Foci> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}

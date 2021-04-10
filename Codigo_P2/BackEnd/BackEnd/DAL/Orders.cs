using DAL.EF;
using DAL.Repository;
using DAL.DO.Interfaces;
using DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Orders : ICRUD<data.Orders>
    {
        private RepositoryOrders _repo = null;

        public Orders(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryOrders(solutionDbContext);
        }

        public void Delete(data.Orders t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.Orders GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Orders t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.Orders t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.Orders> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Orders>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Orders> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}

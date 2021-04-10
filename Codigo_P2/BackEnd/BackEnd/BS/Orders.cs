using DAL.EF;
using DAL.DO.Interfaces;
using data = DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
    public class Orders : ICRUD<data.Orders>
    {
        private SolutionDbContext _repo = null;

        public Orders(SolutionDbContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.Orders t)
        {
            new DAL.Orders(_repo).Delete(t);
        }

        public IEnumerable<data.Orders> GetAll()
        {
            return new DAL.Orders(_repo).GetAll();
        }

        public data.Orders GetOneById(int id)
        {

            return new DAL.Orders(_repo).GetOneById(id);
        }

        public void Insert(data.Orders t)
        {

            new DAL.Orders(_repo).Insert(t);
        }

        public void Update(data.Orders t)
        {

            new DAL.Orders(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Orders>> GetAllInclude()
        {
            return await new DAL.Orders(_repo).GetAllInclude();
        }

        public async Task<data.Orders> GetOneByIdInclude(int id)
        {
            return await new DAL.Orders(_repo).GetOneByIdInclude(id);
        }
    }
}

using DAL.EF;
using DAL.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace BS
{
    public class Staffs : ICRUD<data.Staffs>
    {
        private SolutionDbContext context;
        public Staffs(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Staffs t)
        {
            new DAL.Staffs(context).Delete(t);
        }

        public IEnumerable<data.Staffs> GetAll()
        {
            return new DAL.Staffs(context).GetAll();
        }

        public data.Staffs GetOneById(int id)
        {
            return new DAL.Staffs(context).GetOneById(id);
        }

        public void Insert(data.Staffs t)
        {
            new DAL.Staffs(context).Insert(t);
        }

        public void Update(data.Staffs t)
        {
            new DAL.Staffs(context).Update(t);
        }
    }
}

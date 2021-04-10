using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using data = DAL.DO.Objects;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public StaffsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Staffs>>> GetStaffs()
        {
            // carga de datos
            var aux = new BS.Staffs(_context).GetAll().ToList();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Staffs>, IEnumerable<DataModels.Staffs>>(aux).ToList();
            return mappaux.ToList();
        }
    }
}

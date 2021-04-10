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
    public class CustomersController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Customer>>> GetCustomers()
        {
            // carga de datos
            var aux = new BS.Customers(_context).GetAll().ToList();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Customers>, IEnumerable<DataModels.Customer>>(aux).ToList();
            return mappaux.ToList();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Customer>> GetCustomers(int id)
        {
            var customers = new BS.Customers(_context).GetOneById(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Customers, DataModels.Customer>(customers);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, DataModels.Customer customers)
        {
            if (id != customers.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                //implementacion del automapper
                var mappaux = _mapper.Map<DataModels.Customer, data.Customers>(customers);

                new BS.Customers(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Customer>> PostCustomers(DataModels.Customer customers)
        {
            var mappaux = _mapper.Map<DataModels.Customer, data.Customers>(customers);

            new BS.Customers(_context).Insert(mappaux);

            return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Customer>> DeleteCustomers(int id)
        {
            var customers = new BS.Customers(_context).GetOneById(id);
            if (customers == null)
            {
                return NotFound();
            }

            new BS.Customers(_context).Delete(customers);
            var mappaux = _mapper.Map<data.Customers, DataModels.Customer>(customers);

            return mappaux;
        }

        private bool CustomersExists(int id)
        {
            return (new BS.Customers(_context).GetOneById(id) != null);
        }
    }
}

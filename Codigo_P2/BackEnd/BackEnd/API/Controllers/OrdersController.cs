using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using data = DAL.DO.Objects;
using AutoMapper;
using API.DataModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            // carga de datos
            var aux = await new BS.Orders(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Orders>, IEnumerable<DataModels.Orders>>(aux).ToList();
            return mappaux;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            // carga de datos
            var aux = await new BS.Orders(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Orders, DataModels.Orders>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.OrderId)
            {
                return BadRequest();
            }

            

            try
            {

                var mappaux = _mapper.Map<DataModels.Orders, data.Orders>(orders);
                new BS.Orders(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            var mappaux = _mapper.Map<DataModels.Orders, data.Orders>(orders);
            new BS.Orders(_context).Insert(mappaux);

            return CreatedAtAction("GetOrders", new { id = orders.OrderId }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int id)
        {
            var orders = new BS.Orders(_context).GetOneById(id);
            if (orders == null)
            {
                return NotFound();
            }

            new BS.Orders(_context).Delete(orders);
            var mappaux = _mapper.Map<data.Orders, DataModels.Orders>(orders);

            return mappaux;
        }

        private bool OrdersExists(int id)
        {
            return (new BS.Orders(_context).GetOneById(id) != null);
        }
    }
}

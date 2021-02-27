using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solution.DAL.EF;
using data = Solution.DO.Objects;
using AutoMapper;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupRequestsController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupRequestsController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/GroupRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.GroupRequests>>> GetGroupRequests()
        {
            // carga de datos
            var aux = await new BS.GroupRequests(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.GroupRequests>, IEnumerable<DataModels.GroupRequests>>(aux).ToList();
            return mappaux;
        }

        // GET: api/GroupRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.GroupRequests>> GetGroupRequests(int id)
        {
            var groupRequests = await new BS.GroupRequests(_context).GetOneByIdInclude(id);
            //implementacion del automapper
            var mappaux = _mapper.Map<data.GroupRequests, DataModels.GroupRequests>(groupRequests);
            if (groupRequests == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/GroupRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupRequests(int id, DataModels.GroupRequests groupRequests)
        {
            if (id != groupRequests.GroupRequestId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.GroupRequests, data.GroupRequests>(groupRequests);
                new BS.GroupRequests(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!GroupRequestsExists(id))
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

        // POST: api/GroupRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.GroupRequests>> PostGroupRequests(DataModels.GroupRequests groupRequests)
        {
            var mappaux = _mapper.Map<DataModels.GroupRequests, data.GroupRequests>(groupRequests);
            new BS.GroupRequests(_context).Insert(mappaux);

            return CreatedAtAction("GetGroupRequests", new { id = groupRequests.GroupRequestId }, groupRequests);
        }

        // DELETE: api/GroupRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.GroupRequests>> DeleteGroupRequests(int id)
        {
            var groupRequests = new BS.GroupRequests(_context).GetOneById(id);
            if (groupRequests == null)
            {
                return NotFound();
            }

            new BS.GroupRequests(_context).Delete(groupRequests);
            var mappaux = _mapper.Map<data.GroupRequests, DataModels.GroupRequests>(groupRequests);

            return mappaux;
        }

        private bool GroupRequestsExists(int id)
        {
            return (new BS.GroupRequests(_context).GetOneById(id) != null);
        }
    }
}

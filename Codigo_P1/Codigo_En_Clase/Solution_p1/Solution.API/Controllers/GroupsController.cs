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
    public class GroupsController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupsController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Groups>>> GetGroups()
        {
            // carga de datos
            var aux = new BS.Group(_context).GetAll().ToList();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Groups>, IEnumerable<DataModels.Groups>>(aux).ToList();
            return mappaux.ToList();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Groups>> GetGroups(int id)
        {
            var groups = new BS.Group(_context).GetOneById(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Groups, DataModels.Groups>(groups);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, DataModels.Groups groups)
        {
            if (id != groups.GroupId)
            {
                return BadRequest();
            }

            try
            {
                //implementacion del automapper
                var mappaux = _mapper.Map<DataModels.Groups, data.Groups>(groups);

                new BS.Group(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Groups>> PostGroups(DataModels.Groups groups)
        {
            //

            var mappaux = _mapper.Map<DataModels.Groups, data.Groups>(groups);

            new BS.Group(_context).Insert(mappaux);

            return CreatedAtAction("GetGroups", new { id = groups.GroupId }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Groups>> DeleteGroups(int id)
        {
            var groups = new BS.Group(_context).GetOneById(id);
            if (groups == null)
            {
                return NotFound();
            }

            new BS.Group(_context).Delete(groups);
            var mappaux = _mapper.Map<data.Groups, DataModels.Groups>(groups);

            return mappaux;
        }

        private bool GroupsExists(int id)
        {
            return (new BS.Group(_context).GetOneById(id) != null);
        }
    }
}

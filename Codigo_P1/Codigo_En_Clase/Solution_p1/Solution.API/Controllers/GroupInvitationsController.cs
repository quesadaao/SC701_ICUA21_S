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
    public class GroupInvitationsController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupInvitationsController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/GroupInvitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.GroupInvitations>>> GetGroupInvitations()
        {
            var aux = await new BS.GroupInvitations(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.GroupInvitations>, IEnumerable<DataModels.GroupInvitations>>(aux).ToList();
            return mappaux;
        }

        // GET: api/GroupInvitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.GroupInvitations>> GetGroupInvitations(int id)
        {
            var groupInvitations = await new BS.GroupInvitations(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.GroupInvitations, DataModels.GroupInvitations>(groupInvitations);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/GroupInvitations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupInvitations(int id, DataModels.GroupInvitations groupInvitations)
        {
            if (id != groupInvitations.GroupInvitationId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.GroupInvitations, data.GroupInvitations>(groupInvitations);
                new BS.GroupInvitations(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!GroupInvitationsExists(id))
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

        // POST: api/GroupInvitations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.GroupInvitations>> PostGroupInvitations(DataModels.GroupInvitations groupInvitations)
        {
            var mappaux = _mapper.Map<DataModels.GroupInvitations, data.GroupInvitations>(groupInvitations);
            new BS.GroupInvitations(_context).Insert(mappaux);

            return CreatedAtAction("GetGroupInvitations", new { id = groupInvitations.GroupInvitationId }, groupInvitations);
        }

        // DELETE: api/GroupInvitations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.GroupInvitations>> DeleteGroupInvitations(int id)
        {
            var groupInvitations = new BS.GroupInvitations(_context).GetOneById(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            new BS.GroupInvitations(_context).Delete(groupInvitations);
            var mappaux = _mapper.Map<data.GroupInvitations, DataModels.GroupInvitations>(groupInvitations);

            return mappaux;
        }

        private bool GroupInvitationsExists(int id)
        {
            return (new BS.GroupInvitations(_context).GetOneById(id) != null);
        }
    }
}

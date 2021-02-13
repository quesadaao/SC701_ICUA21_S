using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solution.DAL.EF;
using data = Solution.DO.Objects;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public GroupsController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Groups>>> GetGroups()
        {
            return new BS.Group(_context).GetAll().ToList();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Groups>> GetGroups(int id)
        {
            var groups = new BS.Group(_context).GetOneById(id);

            if (groups == null)
            {
                return NotFound();
            }

            return groups;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, data.Groups groups)
        {
            if (id != groups.GroupId)
            {
                return BadRequest();
            }

            try
            {
                new BS.Group(_context).Update(groups);
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
        public async Task<ActionResult<data.Groups>> PostGroups(data.Groups groups)
        {
            new BS.Group(_context).Insert(groups);

            return CreatedAtAction("GetGroups", new { id = groups.GroupId }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Groups>> DeleteGroups(int id)
        {
            var groups = new BS.Group(_context).GetOneById(id);
            if (groups == null)
            {
                return NotFound();
            }

            new BS.Group(_context).Delete(groups);

            return groups;
        }

        private bool GroupsExists(int id)
        {
            return (new BS.Group(_context).GetOneById(id) != null);
        }
    }
}

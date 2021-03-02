using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupCommentsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupCommentsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupComments>>> GetGroupComments()
        {
            return await _context.GroupComments.ToListAsync();
        }

        // GET: api/GroupComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupComments>> GetGroupComments(int id)
        {
            var groupComments = await _context.GroupComments.FindAsync(id);

            if (groupComments == null)
            {
                return NotFound();
            }

            return groupComments;
        }

        // PUT: api/GroupComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupComments(int id, GroupComments groupComments)
        {
            if (id != groupComments.GroupCommentId)
            {
                return BadRequest();
            }

            _context.Entry(groupComments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupCommentsExists(id))
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

        // POST: api/GroupComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupComments>> PostGroupComments(GroupComments groupComments)
        {
            _context.GroupComments.Add(groupComments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupComments", new { id = groupComments.GroupCommentId }, groupComments);
        }

        // DELETE: api/GroupComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupComments>> DeleteGroupComments(int id)
        {
            var groupComments = await _context.GroupComments.FindAsync(id);
            if (groupComments == null)
            {
                return NotFound();
            }

            _context.GroupComments.Remove(groupComments);
            await _context.SaveChangesAsync();

            return groupComments;
        }

        private bool GroupCommentsExists(int id)
        {
            return _context.GroupComments.Any(e => e.GroupCommentId == id);
        }
    }
}

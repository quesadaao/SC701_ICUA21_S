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
    public class GroupCommentsController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupCommentsController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/GroupComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.GroupComments>>> GetGroupComments()
        {
            // carga de datos
            var aux = await new BS.GroupComments(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.GroupComments>, IEnumerable<DataModels.GroupComments>>(aux).ToList();
            return mappaux;
        }

        // GET: api/GroupComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.GroupComments>> GetGroupComments(int id)
        {
            // carga de datos
            var aux = await new BS.GroupComments(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.GroupComments, DataModels.GroupComments>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/GroupComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupComments(int id, DataModels.GroupComments groupComments)
        {
            if (id != groupComments.GroupCommentId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.GroupComments, data.GroupComments>(groupComments);
                new BS.GroupComments(_context).Update(mappaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<DataModels.GroupComments>> PostGroupComments(DataModels.GroupComments groupComments)
        {
            var mappaux = _mapper.Map<DataModels.GroupComments, data.GroupComments>(groupComments);
            new BS.GroupComments(_context).Insert(mappaux);

            return CreatedAtAction("GetGroupComments", new { id = groupComments.GroupCommentId }, groupComments);
        }

        // DELETE: api/GroupComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.GroupComments>> DeleteGroupComments(int id)
        {
            var groupComments = new BS.GroupComments(_context).GetOneById(id);
            if (groupComments == null)
            {
                return NotFound();
            }

            new BS.GroupComments(_context).Delete(groupComments);
            var mappaux = _mapper.Map<data.GroupComments, DataModels.GroupComments>(groupComments);


            return mappaux;
        }

        private bool GroupCommentsExists(int id)
        {
            return (new BS.GroupComments(_context).GetOneById(id) != null);
        }
    }
}

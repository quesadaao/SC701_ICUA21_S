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
    public class FociController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public FociController(SolutionDBContext context,IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Foci>>> GetFoci()
        {
            // carga de datos
            var aux = await new BS.Foci(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Foci>, IEnumerable<DataModels.Foci>>(aux).ToList();
            return mappaux;

        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Foci>> GetFoci(int id)
        {
            // carga de datos
            var aux = await new BS.Foci(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Foci, DataModels.Foci>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoci(int id, DataModels.Foci foci)
        {
            if (id != foci.FocusId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Foci, data.Foci>(foci);
                new BS.Foci(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!FociExists(id))
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

        // POST: api/Foci
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Foci>> PostFoci(DataModels.Foci foci)
        {
            var mappaux = _mapper.Map<DataModels.Foci, data.Foci>(foci);
            new BS.Foci(_context).Insert(mappaux);

            return CreatedAtAction("GetFoci", new { id = foci.FocusId }, foci);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Foci>> DeleteFoci(int id)
        {
            var foci = new BS.Foci(_context).GetOneById(id);
            if (foci == null)
            {
                return NotFound();
            }

            new BS.Foci(_context).Delete(foci);
            var mappaux = _mapper.Map<data.Foci, DataModels.Foci>(foci);

            return mappaux;
        }

        private bool FociExists(int id)
        {
            return (new BS.Foci(_context).GetOneById(id)!=null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientService.Data;

namespace ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly DataContext _context;

        public TeamsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TeamEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamEntity>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: api/TeamEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamEntity>> GetTeamEntity(int id)
        {
            var teamEntity = await _context.Teams.FindAsync(id);

            if (teamEntity == null)
            {
                return NotFound();
            }

            return teamEntity;
        }

        // PUT: api/TeamEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamEntity(int id, TeamEntity teamEntity)
        {
            if (id != teamEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamEntityExists(id))
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

        // POST: api/TeamEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TeamEntity>> PostTeamEntity(TeamEntity teamEntity)
        {
            _context.Teams.Add(teamEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamEntity", new { id = teamEntity.Id }, teamEntity);
        }

        // DELETE: api/TeamEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeamEntity>> DeleteTeamEntity(int id)
        {
            var teamEntity = await _context.Teams.FindAsync(id);
            if (teamEntity == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(teamEntity);
            await _context.SaveChangesAsync();

            return teamEntity;
        }

        private bool TeamEntityExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}

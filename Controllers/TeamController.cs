using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Taskbook_ASPNETCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController: ControllerBase{

        private readonly TaskbookDBContext _context;
        public TeamController(TaskbookDBContext context){
            _context = context;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.teams.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(long id)
        {
            var team = await _context.teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // POST: api/Team
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeams), new { id = team.teamId }, team);
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.teamId)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            _context.teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
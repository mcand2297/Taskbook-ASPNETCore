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
    public class ActivityController: ControllerBase{

        private readonly TaskbookDBContext _context;
        public ActivityController(TaskbookDBContext context){
            _context = context;
        }

        // GET: api/Activity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return await _context.activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var activity = await _context.activities.FindAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        // POST: api/Activity
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            _context.activities.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivities), new { id = activity.activityId }, activity);
        }

        // PUT: api/Activity/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity)
        {
            if (id != activity.activityId)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Activity/5
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
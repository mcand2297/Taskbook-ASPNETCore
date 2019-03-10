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
    public class ResponseController: ControllerBase{

        private readonly TaskbookDBContext _context;
        public ResponseController(TaskbookDBContext context){
            _context = context;
        }

        // GET: api/Response
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetResponses()
        {
            return await _context.responses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetResponse(int id)
        {
            var response = await _context.responses.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        // POST: api/Response
        [HttpPost]
        public async Task<ActionResult<Response>> PostResponse(Response response)
        {
            _context.responses.Add(response);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResponses), new { id = response.responseId }, response);
        }

        // PUT: api/Reponse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponse(int id, Response response)
        {
            if (id != response.responseId)
            {
                return BadRequest();
            }

            _context.Entry(response).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Response/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            var response = await _context.responses.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            _context.responses.Remove(response);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
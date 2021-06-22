using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models;

namespace Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubUsersController : ControllerBase
    {
        private readonly HubDbContext _context;

        public HubUsersController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/HubUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HubUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/HubUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HubUser>> GetHubUser(Guid id)
        {
            var hubUser = await _context.Users.FindAsync(id);

            if (hubUser == null)
            {
                return NotFound();
            }

            return hubUser;
        }

        // PUT: api/HubUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHubUser(Guid id, HubUser hubUser)
        {
            if (id != hubUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(hubUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubUserExists(id))
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

        // POST: api/HubUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HubUser>> PostHubUser(HubUser hubUser)
        {
            _context.Users.Add(hubUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHubUser", new { id = hubUser.Id }, hubUser);
        }

        // DELETE: api/HubUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHubUser(Guid id)
        {
            var hubUser = await _context.Users.FindAsync(id);
            if (hubUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(hubUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HubUserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

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
    public class HubRolesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public HubRolesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/HubRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HubRole>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/HubRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HubRole>> GetHubRole(Guid id)
        {
            var hubRole = await _context.Roles.FindAsync(id);

            if (hubRole == null)
            {
                return NotFound();
            }

            return hubRole;
        }

        // PUT: api/HubRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHubRole(Guid id, HubRole hubRole)
        {
            if (id != hubRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(hubRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubRoleExists(id))
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

        // POST: api/HubRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HubRole>> PostHubRole(HubRole hubRole)
        {
            _context.Roles.Add(hubRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHubRole", new { id = hubRole.Id }, hubRole);
        }

        // DELETE: api/HubRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHubRole(Guid id)
        {
            var hubRole = await _context.Roles.FindAsync(id);
            if (hubRole == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(hubRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HubRoleExists(Guid id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}

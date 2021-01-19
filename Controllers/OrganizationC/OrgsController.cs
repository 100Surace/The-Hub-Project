using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Organization;

namespace Hub.Controllers.OrganizationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public OrgsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/Orgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Org>>> GetOrg()
        {
            return await _context.Org.ToListAsync();
        }

        // GET: api/Orgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Org>> GetOrg(int id)
        {
            var org = await _context.Org.FindAsync(id);

            if (org == null)
            {
                return NotFound();
            }

            return org;
        }

        // PUT: api/Orgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrg(int id, Org org)
        {
            if (id != org.Ids)
            {
                return BadRequest();
            }

            _context.Entry(org).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrgExists(id))
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

        // POST: api/Orgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Org>> PostOrg(Org org)
        {
            _context.Org.Add(org);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrg", new { id = org.Ids }, org);
        }

        // DELETE: api/Orgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrg(int id)
        {
            var org = await _context.Org.FindAsync(id);
            if (org == null)
            {
                return NotFound();
            }

            _context.Org.Remove(org);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrgExists(int id)
        {
            return _context.Org.Any(e => e.Ids == id);
        }
    }
}

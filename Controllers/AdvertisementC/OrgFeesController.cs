using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Advertisement;

namespace Hub.Controllers.AdvertisementC
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgFeesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public OrgFeesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/OrgFees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgFee>>> GetOrgFee()
        {
            return await _context.OrgFee.ToListAsync();
        }

        // GET: api/OrgFees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrgFee>> GetOrgFee(int id)
        {
            var orgFee = await _context.OrgFee.FindAsync(id);

            if (orgFee == null)
            {
                return NotFound();
            }

            return orgFee;
        }

        // PUT: api/OrgFees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgFee(int id, OrgFee orgFee)
        {
            if (id != orgFee.OrgFeeId)
            {
                return BadRequest();
            }

            _context.Entry(orgFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrgFeeExists(id))
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

        // POST: api/OrgFees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrgFee>> PostOrgFee(OrgFee orgFee)
        {
            _context.OrgFee.Add(orgFee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrgFee", new { id = orgFee.OrgFeeId }, orgFee);
        }

        // DELETE: api/OrgFees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgFee(int id)
        {
            var orgFee = await _context.OrgFee.FindAsync(id);
            if (orgFee == null)
            {
                return NotFound();
            }

            _context.OrgFee.Remove(orgFee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrgFeeExists(int id)
        {
            return _context.OrgFee.Any(e => e.OrgFeeId == id);
        }
    }
}

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
    public class HubAddressesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public HubAddressesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/HubAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HubAddress>>> GetHubAddress()
        {
            return await _context.HubAddress.ToListAsync();
        }

        // GET: api/HubAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HubAddress>> GetHubAddress(int id)
        {
            var hubAddress = await _context.HubAddress.FindAsync(id);

            if (hubAddress == null)
            {
                return NotFound();
            }

            return hubAddress;
        }

        // PUT: api/HubAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHubAddress(int id, HubAddress hubAddress)
        {
            if (id != hubAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(hubAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubAddressExists(id))
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

        // POST: api/HubAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HubAddress>> PostHubAddress(HubAddress hubAddress)
        {
            _context.HubAddress.Add(hubAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHubAddress", new { id = hubAddress.Id }, hubAddress);
        }

        // DELETE: api/HubAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHubAddress(int id)
        {
            var hubAddress = await _context.HubAddress.FindAsync(id);
            if (hubAddress == null)
            {
                return NotFound();
            }

            _context.HubAddress.Remove(hubAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HubAddressExists(int id)
        {
            return _context.HubAddress.Any(e => e.Id == id);
        }
    }
}

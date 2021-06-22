using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Ecommerce.Admin;

namespace Hub.Controllers.Ecommerce.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryLocationsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public InventoryLocationsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/InventoryLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryLocation>>> GetInventoryLocation()
        {
            return await _context.InventoryLocation.ToListAsync();
        }

        // GET: api/InventoryLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryLocation>> GetInventoryLocation(int id)
        {
            var inventoryLocation = await _context.InventoryLocation.FindAsync(id);

            if (inventoryLocation == null)
            {
                return NotFound();
            }

            return inventoryLocation;
        }

        // PUT: api/InventoryLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryLocation(int id, InventoryLocation inventoryLocation)
        {
            if (id != inventoryLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryLocationExists(id))
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

        // POST: api/InventoryLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryLocation>> PostInventoryLocation(InventoryLocation inventoryLocation)
        {
            _context.InventoryLocation.Add(inventoryLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryLocation", new { id = inventoryLocation.Id }, inventoryLocation);
        }

        // DELETE: api/InventoryLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryLocation(int id)
        {
            var inventoryLocation = await _context.InventoryLocation.FindAsync(id);
            if (inventoryLocation == null)
            {
                return NotFound();
            }

            _context.InventoryLocation.Remove(inventoryLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryLocationExists(int id)
        {
            return _context.InventoryLocation.Any(e => e.Id == id);
        }
    }
}

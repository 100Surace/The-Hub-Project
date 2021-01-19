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
    public class AnnualsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public AnnualsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/Annuals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Annual>>> GetAnnual()
        {
            return await _context.Annual.ToListAsync();
        }

        // GET: api/Annuals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Annual>> GetAnnual(int id)
        {
            var annual = await _context.Annual.FindAsync(id);

            if (annual == null)
            {
                return NotFound();
            }

            return annual;
        }

        // PUT: api/Annuals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnual(int id, Annual annual)
        {
            if (id != annual.AnnualId)
            {
                return BadRequest();
            }

            _context.Entry(annual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnualExists(id))
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

        // POST: api/Annuals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Annual>> PostAnnual(Annual annual)
        {
            _context.Annual.Add(annual);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnnual", new { id = annual.AnnualId }, annual);
        }

        // DELETE: api/Annuals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnual(int id)
        {
            var annual = await _context.Annual.FindAsync(id);
            if (annual == null)
            {
                return NotFound();
            }

            _context.Annual.Remove(annual);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnualExists(int id)
        {
            return _context.Annual.Any(e => e.AnnualId == id);
        }
    }
}

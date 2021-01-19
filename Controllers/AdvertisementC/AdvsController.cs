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
    public class AdvsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public AdvsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/Advs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adv>>> GetAdv()
        {
            return await _context.Adv.ToListAsync();
        }

        // GET: api/Advs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adv>> GetAdv(int id)
        {
            var adv = await _context.Adv.FindAsync(id);

            if (adv == null)
            {
                return NotFound();
            }

            return adv;
        }

        // PUT: api/Advs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdv(int id, Adv adv)
        {
            if (id != adv.AdvId)
            {
                return BadRequest();
            }

            _context.Entry(adv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvExists(id))
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

        // POST: api/Advs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adv>> PostAdv(Adv adv)
        {
            _context.Adv.Add(adv);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdv", new { id = adv.AdvId }, adv);
        }

        // DELETE: api/Advs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdv(int id)
        {
            var adv = await _context.Adv.FindAsync(id);
            if (adv == null)
            {
                return NotFound();
            }

            _context.Adv.Remove(adv);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvExists(int id)
        {
            return _context.Adv.Any(e => e.AdvId == id);
        }
    }
}

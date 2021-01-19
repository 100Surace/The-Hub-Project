using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Event;

namespace Hub.Controllers.EventC
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegoesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public EventRegoesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/EventRegoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventRego>>> GetEventRego()
        {
            return await _context.EventRego.ToListAsync();
        }

        // GET: api/EventRegoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventRego>> GetEventRego(int id)
        {
            var eventRego = await _context.EventRego.FindAsync(id);

            if (eventRego == null)
            {
                return NotFound();
            }

            return eventRego;
        }

        // PUT: api/EventRegoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventRego(int id, EventRego eventRego)
        {
            if (id != eventRego.EventRegoId)
            {
                return BadRequest();
            }

            _context.Entry(eventRego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventRegoExists(id))
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

        // POST: api/EventRegoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventRego>> PostEventRego(EventRego eventRego)
        {
            _context.EventRego.Add(eventRego);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventRego", new { id = eventRego.EventRegoId }, eventRego);
        }

        // DELETE: api/EventRegoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventRego(int id)
        {
            var eventRego = await _context.EventRego.FindAsync(id);
            if (eventRego == null)
            {
                return NotFound();
            }

            _context.EventRego.Remove(eventRego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventRegoExists(int id)
        {
            return _context.EventRego.Any(e => e.EventRegoId == id);
        }
    }
}

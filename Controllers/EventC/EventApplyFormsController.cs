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
    public class EventApplyFormsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public EventApplyFormsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/EventApplyForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventApplyForm>>> GetEventApplyForm()
        {
            return await _context.EventApplyForm.ToListAsync();
        }

        // GET: api/EventApplyForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventApplyForm>> GetEventApplyForm(int id)
        {
            var eventApplyForm = await _context.EventApplyForm.FindAsync(id);

            if (eventApplyForm == null)
            {
                return NotFound();
            }

            return eventApplyForm;
        }

        // PUT: api/EventApplyForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventApplyForm(int id, EventApplyForm eventApplyForm)
        {
            if (id != eventApplyForm.EventApplyId)
            {
                return BadRequest();
            }

            _context.Entry(eventApplyForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventApplyFormExists(id))
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

        // POST: api/EventApplyForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventApplyForm>> PostEventApplyForm(EventApplyForm eventApplyForm)
        {
            _context.EventApplyForm.Add(eventApplyForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventApplyForm", new { id = eventApplyForm.EventApplyId }, eventApplyForm);
        }

        // DELETE: api/EventApplyForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventApplyForm(int id)
        {
            var eventApplyForm = await _context.EventApplyForm.FindAsync(id);
            if (eventApplyForm == null)
            {
                return NotFound();
            }

            _context.EventApplyForm.Remove(eventApplyForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventApplyFormExists(int id)
        {
            return _context.EventApplyForm.Any(e => e.EventApplyId == id);
        }
    }
}

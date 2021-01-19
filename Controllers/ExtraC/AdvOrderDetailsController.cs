using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Extra;

namespace Hub.Controllers.ExtraC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvOrderDetailsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public AdvOrderDetailsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/AdvOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvOrderDetail>>> GetAdvOrderDetail()
        {
            return await _context.AdvOrderDetail.ToListAsync();
        }

        // GET: api/AdvOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvOrderDetail>> GetAdvOrderDetail(int id)
        {
            var advOrderDetail = await _context.AdvOrderDetail.FindAsync(id);

            if (advOrderDetail == null)
            {
                return NotFound();
            }

            return advOrderDetail;
        }

        // PUT: api/AdvOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvOrderDetail(int id, AdvOrderDetail advOrderDetail)
        {
            if (id != advOrderDetail.AdvOrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(advOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvOrderDetailExists(id))
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

        // POST: api/AdvOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdvOrderDetail>> PostAdvOrderDetail(AdvOrderDetail advOrderDetail)
        {
            _context.AdvOrderDetail.Add(advOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvOrderDetail", new { id = advOrderDetail.AdvOrderDetailId }, advOrderDetail);
        }

        // DELETE: api/AdvOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvOrderDetail(int id)
        {
            var advOrderDetail = await _context.AdvOrderDetail.FindAsync(id);
            if (advOrderDetail == null)
            {
                return NotFound();
            }

            _context.AdvOrderDetail.Remove(advOrderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvOrderDetailExists(int id)
        {
            return _context.AdvOrderDetail.Any(e => e.AdvOrderDetailId == id);
        }
    }
}

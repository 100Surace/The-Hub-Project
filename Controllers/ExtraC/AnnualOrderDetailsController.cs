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
    public class AnnualOrderDetailsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public AnnualOrderDetailsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/AnnualOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnualOrderDetail>>> GetAnnualOrderDetail()
        {
            return await _context.AnnualOrderDetail.ToListAsync();
        }

        // GET: api/AnnualOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnualOrderDetail>> GetAnnualOrderDetail(int id)
        {
            var annualOrderDetail = await _context.AnnualOrderDetail.FindAsync(id);

            if (annualOrderDetail == null)
            {
                return NotFound();
            }

            return annualOrderDetail;
        }

        // PUT: api/AnnualOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnualOrderDetail(int id, AnnualOrderDetail annualOrderDetail)
        {
            if (id != annualOrderDetail.AnnualOrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(annualOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnualOrderDetailExists(id))
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

        // POST: api/AnnualOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnnualOrderDetail>> PostAnnualOrderDetail(AnnualOrderDetail annualOrderDetail)
        {
            _context.AnnualOrderDetail.Add(annualOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnnualOrderDetail", new { id = annualOrderDetail.AnnualOrderDetailId }, annualOrderDetail);
        }

        // DELETE: api/AnnualOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnualOrderDetail(int id)
        {
            var annualOrderDetail = await _context.AnnualOrderDetail.FindAsync(id);
            if (annualOrderDetail == null)
            {
                return NotFound();
            }

            _context.AnnualOrderDetail.Remove(annualOrderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnualOrderDetailExists(int id)
        {
            return _context.AnnualOrderDetail.Any(e => e.AnnualOrderDetailId == id);
        }
    }
}

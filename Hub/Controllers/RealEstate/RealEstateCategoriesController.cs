using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.RealEstate;

namespace Hub.Controllers.RealEstate
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateCategoriesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public RealEstateCategoriesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/RealEstateCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealEstateCategory>>> GetRealEstateCategory()
        {
            return await _context.RealEstateCategory.ToListAsync();
        }

        // GET: api/RealEstateCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RealEstateCategory>> GetRealEstateCategory(int id)
        {
            var realEstateCategory = await _context.RealEstateCategory.FindAsync(id);

            if (realEstateCategory == null)
            {
                return NotFound();
            }

            return realEstateCategory;
        }

        // PUT: api/RealEstateCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealEstateCategory(int id, RealEstateCategory realEstateCategory)
        {
            if (id != realEstateCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(realEstateCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateCategoryExists(id))
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

        // POST: api/RealEstateCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealEstateCategory>> PostRealEstateCategory(RealEstateCategory realEstateCategory)
        {
            _context.RealEstateCategory.Add(realEstateCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealEstateCategory", new { id = realEstateCategory.Id }, realEstateCategory);
        }

        // DELETE: api/RealEstateCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstateCategory(int id)
        {
            var realEstateCategory = await _context.RealEstateCategory.FindAsync(id);
            if (realEstateCategory == null)
            {
                return NotFound();
            }

            _context.RealEstateCategory.Remove(realEstateCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealEstateCategoryExists(int id)
        {
            return _context.RealEstateCategory.Any(e => e.Id == id);
        }
    }
}

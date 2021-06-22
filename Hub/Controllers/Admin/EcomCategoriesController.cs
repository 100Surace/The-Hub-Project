using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Admin;

namespace Hub.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcomCategoriesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public EcomCategoriesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/EcomCategories
        [HttpGet]
        public IQueryable<Object> GetEcomCategory()
        {
            return _context.EcomCategory.Select(c => new {c.Id, c.CategoryName, c.ParentcategoryId });
        }

        // GET: api/EcomCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EcomCategory>> GetEcomCategory(int id)
        {
            var ecomCategory = await _context.EcomCategory.FindAsync(id);

            if (ecomCategory == null)
            {
                return NotFound();
            }

            return ecomCategory;
        }

        // PUT: api/EcomCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcomCategory(int id, EcomCategory ecomCategory)
        {
            if (id != ecomCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(ecomCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EcomCategoryExists(id))
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

        // POST: api/EcomCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EcomCategory>> PostEcomCategory(EcomCategory ecomCategory)
        {
            _context.EcomCategory.Add(ecomCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEcomCategory", new { id = ecomCategory.Id }, ecomCategory);
        }

        // DELETE: api/EcomCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEcomCategory(int id)
        {
            var ecomCategory = await _context.EcomCategory.FindAsync(id);
            if (ecomCategory == null)
            {
                return NotFound();
            }

            _context.EcomCategory.Remove(ecomCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EcomCategoryExists(int id)
        {
            return _context.EcomCategory.Any(e => e.Id == id);
        }
    }
}

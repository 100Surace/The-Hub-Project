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
    public class ModuleCategoriesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public ModuleCategoriesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/ModuleCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleCategory>>> GetModuleCategory()
        {
            return await _context.ModuleCategory.ToListAsync();
        }

        // GET: api/ModuleCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleCategory>> GetModuleCategory(int id)
        {
            var moduleCategory = await _context.ModuleCategory.FindAsync(id);

            if (moduleCategory == null)
            {
                return NotFound();
            }

            return moduleCategory;
        }

        // PUT: api/ModuleCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuleCategory(int id, ModuleCategory moduleCategory)
        {
            if (id != moduleCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(moduleCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleCategoryExists(id))
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

        // POST: api/ModuleCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModuleCategory>> PostModuleCategory(ModuleCategory moduleCategory)
        {
            _context.ModuleCategory.Add(moduleCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModuleCategory", new { id = moduleCategory.Id }, moduleCategory);
        }

        // DELETE: api/ModuleCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModuleCategory(int id)
        {
            var moduleCategory = await _context.ModuleCategory.FindAsync(id);
            if (moduleCategory == null)
            {
                return NotFound();
            }

            _context.ModuleCategory.Remove(moduleCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleCategoryExists(int id)
        {
            return _context.ModuleCategory.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Organization;

namespace Hub.Controllers.OrganizationC
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
        public IQueryable<Object> GetModuleCategory()
        {
            return _context.ModuleCategory.Include(a => a.Module).Select(
               a => new
               {
                   ids = a.Ids,
                   name = a.ModuleCategoryName,
                   module = a.Module.ModuleName,
                   moduleId = a.Module.Ids
                   //modulecategories = a.Module.Select(p => new
                   //{
                   //    categoryname = p.ModuleName,
                   //    id = p.Ids
                   //})
               });
        }
        // GET: api/ModuleCategories
        //[HttpGet]
        //public List<ModuleCategory> GetModule()
        //{
        //    var result = new List<ModuleCategory>();
        //    //result = _context.ModuleCategory.ToList();
        //    result = (from c in _context.ModuleCategory
        //              join m in _context.Module on c.ModuleId equals m.Ids
        //              select new
        //              {
        //                  ids = c.Ids,
        //                  moduleCategory = c.ModuleCategoryName,
        //                  moduleId = m.Ids,
        //                  moduleName = m.ModuleName
        //              }
        //              ).ToList();
        //    return result;
        //}

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
            if (id != moduleCategory.Ids)
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

            return CreatedAtAction("GetModuleCategory", new { id = moduleCategory.Ids }, moduleCategory);
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
            return _context.ModuleCategory.Any(e => e.Ids == id);
        }
    }
}

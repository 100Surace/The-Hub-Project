using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Ecommerce.Admin;

namespace Hub.Controllers.Ecommerce.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTagsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public ProductTagsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTag>>> GetProductTag()
        {
            return await _context.ProductTag.ToListAsync();
        }

        // GET: api/ProductTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTag>> GetProductTag(int id)
        {
            var productTag = await _context.ProductTag.FindAsync(id);

            if (productTag == null)
            {
                return NotFound();
            }

            return productTag;
        }

        // PUT: api/ProductTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTag(int id, ProductTag productTag)
        {
            if (id != productTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(productTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTagExists(id))
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

        // POST: api/ProductTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTag>> PostProductTag(ProductTag productTag)
        {
            _context.ProductTag.Add(productTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTag", new { id = productTag.Id }, productTag);
        }

        // DELETE: api/ProductTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTag(int id)
        {
            var productTag = await _context.ProductTag.FindAsync(id);
            if (productTag == null)
            {
                return NotFound();
            }

            _context.ProductTag.Remove(productTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTagExists(int id)
        {
            return _context.ProductTag.Any(e => e.Id == id);
        }
    }
}

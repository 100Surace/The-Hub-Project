using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Controllers.Info;
using Hub.Data;

namespace Hub.Controllers.InfoC
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsRegistersController : ControllerBase
    {
        private readonly HubDbContext _context;

        public NewsRegistersController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/NewsRegisters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsRegister>>> GetNewsRegister()
        {
            return await _context.NewsRegister.ToListAsync();
        }

        // GET: api/NewsRegisters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsRegister>> GetNewsRegister(int id)
        {
            var newsRegister = await _context.NewsRegister.FindAsync(id);

            if (newsRegister == null)
            {
                return NotFound();
            }

            return newsRegister;
        }

        // PUT: api/NewsRegisters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsRegister(int id, NewsRegister newsRegister)
        {
            if (id != newsRegister.NewsId)
            {
                return BadRequest();
            }

            _context.Entry(newsRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsRegisterExists(id))
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

        // POST: api/NewsRegisters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewsRegister>> PostNewsRegister(NewsRegister newsRegister)
        {
            _context.NewsRegister.Add(newsRegister);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsRegister", new { id = newsRegister.NewsId }, newsRegister);
        }

        // DELETE: api/NewsRegisters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsRegister(int id)
        {
            var newsRegister = await _context.NewsRegister.FindAsync(id);
            if (newsRegister == null)
            {
                return NotFound();
            }

            _context.NewsRegister.Remove(newsRegister);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsRegisterExists(int id)
        {
            return _context.NewsRegister.Any(e => e.NewsId == id);
        }
    }
}

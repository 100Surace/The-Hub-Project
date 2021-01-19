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
    public class WatchListsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public WatchListsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/WatchLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchList>>> GetWatchList()
        {
            return await _context.WatchList.ToListAsync();
        }

        // GET: api/WatchLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchList>> GetWatchList(int id)
        {
            var watchList = await _context.WatchList.FindAsync(id);

            if (watchList == null)
            {
                return NotFound();
            }

            return watchList;
        }

        // PUT: api/WatchLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchList(int id, WatchList watchList)
        {
            if (id != watchList.WatchListId)
            {
                return BadRequest();
            }

            _context.Entry(watchList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListExists(id))
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

        // POST: api/WatchLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WatchList>> PostWatchList(WatchList watchList)
        {
            _context.WatchList.Add(watchList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchList", new { id = watchList.WatchListId }, watchList);
        }

        // DELETE: api/WatchLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchList(int id)
        {
            var watchList = await _context.WatchList.FindAsync(id);
            if (watchList == null)
            {
                return NotFound();
            }

            _context.WatchList.Remove(watchList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchListExists(int id)
        {
            return _context.WatchList.Any(e => e.WatchListId == id);
        }
    }
}

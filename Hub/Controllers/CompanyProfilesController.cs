using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models;

namespace Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfilesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public CompanyProfilesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyProfile>>> GetCompanyProfile()
        {
            return await _context.CompanyProfile.ToListAsync();
        }

        // GET: api/CompanyProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyProfile>> GetCompanyProfile(int id)
        {
            var companyProfile = await _context.CompanyProfile.FindAsync(id);

            if (companyProfile == null)
            {
                return NotFound();
            }

            return companyProfile;
        }

        // PUT: api/CompanyProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyProfile(int id, CompanyProfile companyProfile)
        {
            if (id != companyProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyProfileExists(id))
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

        // POST: api/CompanyProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyProfile>> PostCompanyProfile(CompanyProfile companyProfile)
        {
            _context.CompanyProfile.Add(companyProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyProfile", new { id = companyProfile.Id }, companyProfile);
        }

        // DELETE: api/CompanyProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyProfile(int id)
        {
            var companyProfile = await _context.CompanyProfile.FindAsync(id);
            if (companyProfile == null)
            {
                return NotFound();
            }

            _context.CompanyProfile.Remove(companyProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyProfileExists(int id)
        {
            return _context.CompanyProfile.Any(e => e.Id == id);
        }
    }
}

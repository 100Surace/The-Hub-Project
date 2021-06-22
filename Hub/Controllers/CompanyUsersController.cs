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
    public class CompanyUsersController : ControllerBase
    {
        private readonly HubDbContext _context;

        public CompanyUsersController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyUser>>> GetCompanyUser()
        {
            return await _context.CompanyUser.ToListAsync();
        }

        // GET: api/CompanyUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyUser>> GetCompanyUser(int id)
        {
            var companyUser = await _context.CompanyUser.FindAsync(id);

            if (companyUser == null)
            {
                return NotFound();
            }

            return companyUser;
        }

        // PUT: api/CompanyUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyUser(int id, CompanyUser companyUser)
        {
            if (id != companyUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyUserExists(id))
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

        // POST: api/CompanyUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyUser>> PostCompanyUser(CompanyUser companyUser)
        {
            _context.CompanyUser.Add(companyUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyUser", new { id = companyUser.Id }, companyUser);
        }

        // DELETE: api/CompanyUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyUser(int id)
        {
            var companyUser = await _context.CompanyUser.FindAsync(id);
            if (companyUser == null)
            {
                return NotFound();
            }

            _context.CompanyUser.Remove(companyUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyUserExists(int id)
        {
            return _context.CompanyUser.Any(e => e.Id == id);
        }
    }
}

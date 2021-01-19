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
    public class UserPaymentsController : ControllerBase
    {
        private readonly HubDbContext _context;

        public UserPaymentsController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/UserPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPayment>>> GetUserPayment()
        {
            return await _context.UserPayment.ToListAsync();
        }

        // GET: api/UserPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPayment>> GetUserPayment(int id)
        {
            var userPayment = await _context.UserPayment.FindAsync(id);

            if (userPayment == null)
            {
                return NotFound();
            }

            return userPayment;
        }

        // PUT: api/UserPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPayment(int id, UserPayment userPayment)
        {
            if (id != userPayment.UserPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(userPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPaymentExists(id))
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

        // POST: api/UserPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPayment>> PostUserPayment(UserPayment userPayment)
        {
            _context.UserPayment.Add(userPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPayment", new { id = userPayment.UserPaymentId }, userPayment);
        }

        // DELETE: api/UserPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPayment(int id)
        {
            var userPayment = await _context.UserPayment.FindAsync(id);
            if (userPayment == null)
            {
                return NotFound();
            }

            _context.UserPayment.Remove(userPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPaymentExists(int id)
        {
            return _context.UserPayment.Any(e => e.UserPaymentId == id);
        }
    }
}

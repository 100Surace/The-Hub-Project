using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.OrganizationFeature;

namespace Hub.Controllers.OrganizationFeatureC
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRepliesController : ControllerBase
    {
        private readonly HubDbContext _context;

        public CommentRepliesController(HubDbContext context)
        {
            _context = context;
        }

        // GET: api/CommentReplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentReply>>> GetCommentReply()
        {
            return await _context.CommentReply.ToListAsync();
        }

        // GET: api/CommentReplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentReply>> GetCommentReply(int id)
        {
            var commentReply = await _context.CommentReply.FindAsync(id);

            if (commentReply == null)
            {
                return NotFound();
            }

            return commentReply;
        }

        // PUT: api/CommentReplies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentReply(int id, CommentReply commentReply)
        {
            if (id != commentReply.CommentReplyId)
            {
                return BadRequest();
            }

            _context.Entry(commentReply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentReplyExists(id))
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

        // POST: api/CommentReplies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommentReply>> PostCommentReply(CommentReply commentReply)
        {
            _context.CommentReply.Add(commentReply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentReply", new { id = commentReply.CommentReplyId }, commentReply);
        }

        // DELETE: api/CommentReplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentReply(int id)
        {
            var commentReply = await _context.CommentReply.FindAsync(id);
            if (commentReply == null)
            {
                return NotFound();
            }

            _context.CommentReply.Remove(commentReply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentReplyExists(int id)
        {
            return _context.CommentReply.Any(e => e.CommentReplyId == id);
        }
    }
}

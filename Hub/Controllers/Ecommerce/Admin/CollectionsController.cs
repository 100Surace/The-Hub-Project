using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Ecommerce.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Hub.Controllers.Ecommerce.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly HubDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CollectionsController(HubDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Collections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollection()
        {
            return await _context.Collection.ToListAsync();
        }

        // GET: api/Collections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {
            var collection = await _context.Collection.FindAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        // PUT: api/Collections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, Collection collection)
        {
            if (id != collection.Id)
            {
                return BadRequest();
            }

            _context.Entry(collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(id))
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

        // POST: api/Collections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<IQueryable<Object>> PostCollection([FromForm] Collection collection)
        {

            if (collection.CImage != null)
            {
                string imageName = await SaveImage(collection.CImage);
                collection.CollectionImage = imageName;
            }
            _context.Collection.Add(collection);
            await _context.SaveChangesAsync();
            var CID = collection.Id;

            var res = (from c in _context.Collection
                       where c.Id == CID
                       select new
                       {
                           c.Id,
                           c.CollectionName,
                           c.Aviliablefrom,
                           c.AviliableTill,
                           c.CollectionImage,
                           c.Status, 
                           c.UserId
                       }); ;
            return res;
        }

        // DELETE: api/Collections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _context.Collection.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }

            _context.Collection.Remove(collection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectionExists(int id)
        {
            return _context.Collection.Any(e => e.Id == id);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string dirPath = "Uploads/E-commerce/ProductCollection";
            string imageName = "product_collection_" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            string dir = Path.Combine(_hostEnvironment.ContentRootPath, dirPath);
            string filePath = dir + "/" + imageName;
            string fileUrl = dirPath + "/" + imageName;

            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return fileUrl;
        }

        [NonAction]
        public void DeleteImage(string imagePath)
        {
            if (imagePath != null)
            {
                var filePath = Path.Combine(_hostEnvironment.ContentRootPath, imagePath);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Organization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Formatting;

namespace Hub.Controllers.OrganizationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgsController : ControllerBase
    {
        private readonly HubDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public OrgsController(HubDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Orgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Org>>> GetOrg()
        {
            return await _context.Org.ToListAsync();
        }

        // GET: api/Orgs/5
        [HttpGet("{id}")]
        public IQueryable<Object> GetOrg(int id)
        {
            //var org = await _context.Org.FindAsync(id);

            //var org = await _context.Org.Include(a => a.ModuleCategory).Select(
            //  a => new
            //  {
            //      ids = a.Ids,
            //      moduleCategoryName = a.ModuleCategory.ModuleCategoryName,
            //      moduleName = _context.Module.Where(m => m.Ids.Equals(a.ModuleCategory.ModuleId)).Select(m => new
            //                   {
            //                       moduleName = m.ModuleName
            //                   })
            //   });
            //var org = await _context.Org.Include(o => o.ModuleCategory).FirstOrDefaultAsync(o => o.Ids == id);

            var org = (from o in _context.Org
                       join c in _context.ModuleCategory on o.ModuleCategoryId equals c.Ids
                       join m in _context.Module on c.ModuleId equals m.Ids
                       where o.Ids == id
                       select new Org());
                       //select new
                       //{
                       //    o.Ids,
                       //    o.Id,
                       //    o.OrgName,
                       //    o.ModuleCategoryId,
                       //    o.serviceType,
                       //    o.organizationType,
                       //    o.Logo,
                       //    o.Status,
                       //    o.ShortDesc,
                       //    o.LongDesc,
                       //    o.SecondEmail,
                       //    o.SecondPhone,
                       //    o.OrgImg,
                       //    o.BannerImg,
                       //    o.EventRegos,
                       //    o.Facilities,
                       //    o.Fees,
                       //    c.ModuleId,
                       //    m.ModuleName
                       //});

            //if (org == null)
            //{
            //    return NotFound();
            //}

            return org;
        }

        // GET: api/Orgs/users/101
        [HttpGet("users/{id}")]
        public IQueryable<Object> GetUserOrg(string id)
        {
            var org = (from o in _context.Org
                       join c in _context.ModuleCategory on o.ModuleCategoryId equals c.Ids
                       join m in _context.Module on c.ModuleId equals m.Ids
                       where o.Id == id
                       select new
                       {
                           o.Ids,
                           o.Id,
                           o.OrgName,
                           o.ModuleCategoryId,
                           o.serviceType,
                           o.organizationType,
                           o.Logo,
                           o.Status,
                           o.ShortDesc,
                           o.LongDesc,
                           o.SecondEmail,
                           o.SecondPhone,
                           o.OrgImg,
                           o.BannerImg,
                           o.EventRegos,
                           o.Facilities,
                           o.Fees,
                           c.ModuleId,
                           m.ModuleName
                       });

            return org;
        }

        // PUT: api/Orgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IQueryable<Object>> PutOrg(int id, [FromForm]Org org)
        {
            //if (id != org.Ids)
            //{
            //    return BadRequest();
            //}
            var old = (from o in _context.Org
                       where o.Ids == id
                       select new
                       {
                           o.Logo
                       }).ToList();

            if (org.ImageFile != null)
            {
                DeleteImage(old.First().Logo);
                org.Logo = await SaveImage(org.ImageFile);
            }

           //if (org.OrgImageFiles != null)
            //{
              //  org.Logo = await SaveImage(org.ImageFile);
            //}

            _context.Entry(org).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrgExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            var res = (from o in _context.Org
                       join c in _context.ModuleCategory on o.ModuleCategoryId equals c.Ids
                       join m in _context.Module on c.ModuleId equals m.Ids
                       where o.Ids == id
                       select new
                       {
                           o.Ids,
                           o.Id,
                           o.OrgName,
                           o.ModuleCategoryId,
                           o.serviceType,
                           o.organizationType,
                           o.Logo,
                           o.Status,
                           o.ShortDesc,
                           o.LongDesc,
                           o.SecondEmail,
                           o.SecondPhone,
                           o.OrgImg,
                           o.BannerImg,
                           o.EventRegos,
                           o.Facilities,
                           o.Fees,
                           c.ModuleId,
                           m.ModuleName
                       });

            //return NoContent();
            return res;
        }

        // POST: api/Orgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IQueryable<Object>> PostOrg([FromForm]Org org)
        {
            if (org.ImageFile != null)
            {
                org.Logo = await SaveImage(org.ImageFile);
            }

            _context.Org.Add(org);
            await _context.SaveChangesAsync();

            var res = (from o in _context.Org
                       join c in _context.ModuleCategory on o.ModuleCategoryId equals c.Ids
                       join m in _context.Module on c.ModuleId equals m.Ids
                       where o.Ids == org.Ids
                       select new
                       {
                           o.Ids,
                           o.Id,
                           o.OrgName,
                           o.ModuleCategoryId,
                           o.serviceType,
                           o.organizationType,
                           o.Logo,
                           o.Status,
                           o.ShortDesc,
                           o.LongDesc,
                           o.SecondEmail,
                           o.SecondPhone,
                           o.OrgImg,
                           o.BannerImg,
                           o.EventRegos,
                           o.Facilities,
                           o.Fees,
                           c.ModuleId,
                           m.ModuleName
                       });
            //return CreatedAtAction("GetOrg", new { id = org.Ids }, org);
            return res;
        }

        // DELETE: api/Orgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrg(int id)
        {
            var org = await _context.Org.FindAsync(id);
            if (org == null)
            {
                return NotFound();
            }

            _context.Org.Remove(org);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrgExists(int id)
        {
            return _context.Org.Any(e => e.Ids == id);
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            string filePath = "Uploads/Orgs/" + imageName;
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, filePath);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return filePath;
        }

        [NonAction]
        public void DeleteImage(string imagePath)
        {
            var filePath = Path.Combine(_hostEnvironment.ContentRootPath, imagePath);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }
    }
}

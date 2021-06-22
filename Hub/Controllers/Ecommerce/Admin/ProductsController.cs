using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Data;
using Hub.Models.Ecommerce.Admin;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;

namespace Hub.Controllers.Ecommerce.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly HubDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(HubDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IQueryable<Object>> PostProduct([FromForm]Product product)
        {
            //_context.Product.Add(product);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);


            var pID = 0;
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var prod = new Product
                    {
                        UserId = product.UserId,
                        ProductTitle = product.ProductTitle,
                        Description = product.Description,
                        ProductStatus = product.ProductStatus,
                        VendorId = product.VendorId,
                        EcomCategoryId = product.EcomCategoryId
                    };

                    _context.Product.Add(prod);
                    await _context.SaveChangesAsync();
                    pID = prod.Id;


                    var ProductImage = new ProductImage
                    {
                        ProductId = pID,
                        ProductImages = "",
                        Alt = ""
                    };

                    if (product.ProImages.Count > 0)
                    {
                        string images = "";
                        string alts = "";
                        int count = 0;
                        foreach (IFormFile file in product.ProImages)
                        {
                            count++;
                            alts += product.ProductTitle + " " + count.ToString() + ",";

                            images += await SaveImage(pID, file) + ",";
                        }
                        if (images != "")
                        {
                            ProductImage.ProductImages = images.TrimEnd(',');
                            ProductImage.Alt = alts.TrimEnd(',');
                        }
                    }

                    _context.ProductImage.Add(ProductImage);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch(SqlException ex)
                {
                    transaction.Rollback();

                    throw;
                }
            }
                    

            var res = (from p in _context.Product
                       where p.Id == pID
                       select new
                       {
                           p.Id,
                           p.ProductTitle
                       }); ;
            return res;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        [NonAction]
        public async Task<string> SaveImage(int PID, IFormFile imageFile)
        {
            string dirPath = "Uploads/Products/" + PID.ToString();
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
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

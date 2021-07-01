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
using Newtonsoft.Json;

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

        struct ProVariant
        {
            public string sku { get; set; }
            public string barcode { get; set; }
            public string compareAtPrice { get; set; }
            public string price { get; set; }
            public string costPrice { get; set; }
            public string quantity { get; set; }
            public string option { get; set; }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IQueryable<Object>> PostProduct([FromForm] Product product)
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

                    // product images
                    if (product.ProImages.Count > 0)
                    {
                        var ProductImage = new ProductImage
                        {
                            ProductId = pID,
                            ProductImages = "",
                            Alt = ""
                        };
                        string images = "";
                        string alts = "";
                        int count = 0;

                        foreach (IFormFile file in product.ProImages)
                        {
                            count++;
                            alts += product.ProductTitle + " " + count.ToString() + ",";

                            images += await SaveImage(pID, file) + ",";
                        }
                        ProductImage.ProductImages = images.TrimEnd(',');
                        ProductImage.Alt = alts.TrimEnd(',');

                        _context.ProductImage.Add(ProductImage);
                        await _context.SaveChangesAsync();
                    }

                    // product variants
                    // if single product
                    if (product.ProSingle != null)
                    {
                        var variants = JsonConvert.DeserializeObject<ProVariant>(product.ProSingle);


                        var variant = new ProductVariant
                        {
                            ProductId = pID,
                            Sku = variants.sku,
                            Barcode = variants.barcode,
                            CompareAtPrice = decimal.Parse(variants.compareAtPrice),
                            Price = decimal.Parse(variants.price),
                            CostPrice = decimal.Parse(variants.costPrice),
                            Option = variants.option
                        };
                        _context.ProductVariant.Add(variant);
                        await _context.SaveChangesAsync();
                        var varId = variant.Id;

                        // inventory
                        var inventory = new Inventory
                        {
                            ProductVariantId = varId,
                            Available = int.Parse(variants.quantity)
                        };
                        _context.Inventory.Add(inventory);
                        await _context.SaveChangesAsync();
                    }
                    // if product has many variants
                    else
                    {
                        foreach (string varnt in product.ProVariants)
                        {
                            var variants = JsonConvert.DeserializeObject<ProVariant>(varnt);
                            var variant = new ProductVariant
                            {
                                ProductId = pID,
                                Sku = variants.sku,
                                Barcode = variants.barcode,
                                CompareAtPrice = decimal.Parse(variants.compareAtPrice),
                                Price = decimal.Parse(variants.price),
                                CostPrice = decimal.Parse(variants.costPrice),
                                Option = variants.option
                            };
                            _context.ProductVariant.Add(variant);
                            await _context.SaveChangesAsync();
                            var varId = variant.Id;

                            // inventory
                            var inventory = new Inventory
                            {
                                ProductVariantId = varId,
                                Available = int.Parse(variants.quantity)
                            };
                            _context.Inventory.Add(inventory);
                            await _context.SaveChangesAsync();
                        }
                    }


                    transaction.Commit();
                }
                catch (SqlException ex)
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
            string imageName = "product_" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
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

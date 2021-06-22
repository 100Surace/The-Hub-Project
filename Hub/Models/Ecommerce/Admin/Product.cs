using Hub.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public HubUser User { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(200)]
        public string ProductTitle { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Description { get; set; }

        public int EcomCategoryId { get; set; }
        public EcomCategory EcomCategory { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(30)]
        public string ProductStatus { get; set; }


        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Editable(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        [Editable(false)]
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Collection> Collections { get; set; }  //many to many relation between product and collection

        public ICollection<ProductImage> ProductImages { get; set; }

        [NotMapped]
        public IFormFileCollection ProImages { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }

    }
}

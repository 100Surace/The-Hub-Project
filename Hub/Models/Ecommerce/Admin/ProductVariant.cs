using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ProductImage ProductImage { get; set; }
        [NotMapped]
        public IFormFile PImage { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(40)]
        public string Sku { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(40)]
        public string Barcode { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Option { get; set; }  //concanated option saved here

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CompareAtPrice { get; set; }   //Sale Price

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }   //Selling price

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPrice { get; set; }   //cost price


        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Editable(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Inventory> Inventories { get; set; }

    }
}

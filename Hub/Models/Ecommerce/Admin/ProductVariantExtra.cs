using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class ProductVariantExtra
    {
        [Key]
        public int Id { get; set; }

        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(10)]
        public string WeightUnit { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }


        [Editable(false),DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Editable(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}

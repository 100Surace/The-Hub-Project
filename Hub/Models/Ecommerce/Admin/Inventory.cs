using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }


        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }

        [Required]
        public int Available { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Editable(false)]
        public string Event { get; set; } //Details of inventory movement


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Editable(false)]
        public string AdjustedBy { get; set; }  //person who adjusted it


        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        [Editable(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public ICollection<InventoryLocation> InventoryLocations { get; set; }
    }
}

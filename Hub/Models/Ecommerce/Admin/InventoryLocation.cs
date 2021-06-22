using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class InventoryLocation
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required,StringLength(150)]
        public string StoreName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(200)]
        public string Address1 { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(100)]
        public string Address2 { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(80)]
        public string City { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(80)]
        public string Region { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string Country { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required, DefaultValue(false)]
        public bool Status { get; set; } = false;

        [Editable(false),DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        public ICollection<Inventory> Inventories { get; set; }
    }
}

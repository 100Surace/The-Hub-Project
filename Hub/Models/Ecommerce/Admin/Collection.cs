using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(200)]
        public string CollectionName { get; set; }


        [DataType(DataType.Date)]
        public DateTime Aviliablefrom { get; set; }


        [DataType(DataType.Date)]
        public DateTime AviliableTill { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string CollectionImage { get; set; }
        [NotMapped]
        public IFormFile CImage { get; set; }


        [Required, DefaultValue(true)]
        public bool Status { get; set; } = true;


        [Editable(false),DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; }

    }
}

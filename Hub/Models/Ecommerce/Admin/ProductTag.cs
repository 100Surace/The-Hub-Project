using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class ProductTag
    {
        [Key]
        public int Id { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Tags { get; set; }


    }
}

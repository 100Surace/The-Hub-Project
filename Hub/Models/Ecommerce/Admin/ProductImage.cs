using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Ecommerce.Admin
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string ProductImages { get; set; }

        public string Alt { get; set; } //Image Details

 
        [Editable(false),DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    }
}

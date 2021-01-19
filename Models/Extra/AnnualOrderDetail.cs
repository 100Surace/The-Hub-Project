using Hub.Models.Advertisement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class AnnualOrderDetail
    {
        [Key]
        public int AnnualOrderDetailId { get; set; }

        [Required]
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int AnnualId { get; set; }
        public Annual Annual { get; set; }


        [Required, Display(Name = "Total Anuual Price")]
        public double Price { get; set; }
    }

}

using Hub.Models.Advertisement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class AdvOrderDetail
    {
        [Key]
        public int AdvOrderDetailId { get; set; }

        [Required]
        public int OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; }


        [Required]
        public int AdvId { get; set; }

        public Adv Adv { get; set; }

        public double Price { get; set; }
    }

}

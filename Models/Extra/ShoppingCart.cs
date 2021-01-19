using Hub.Models.Advertisement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class ShoppingCart
    {
       

            public ShoppingCart()
            {
                Count = 1;
            }

            [Key]
            public int ShoppingCartId { get; set; }

            public string Id { get; set; }  // auto pull the ID of the current signed in user 
            [ForeignKey("Id")]
            public HubUser HubUser { get; set; }

            public int? AnnualId { get; set; }
            public Annual Annual { get; set; }

            public int? AdvId { get; set; } //nullable 
            public Adv Adv { get; set; }


            public int? CouponId { get; set; } //nullable
            public Coupon Coupon { get; set; }


            [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
            public int Count { get; set; }

            [NotMapped]
            public double Price { get; set; }

        }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class OrderHeader
    {

        [Key]
        public int OrderHeaderId { get; set; }

        public string Id { get; set; }  // auto pull the ID of the current signed in user 
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public Double OrderTotal { get; set; }

        public string CouponCode { get; set; }  // from shoppingcart to check code of coupon used for the purchasess

        public DateTime PaymentDate { get; set; }

        public string TransactionId { get; set; }

        public string TransactionType { get; set; }

    }
}

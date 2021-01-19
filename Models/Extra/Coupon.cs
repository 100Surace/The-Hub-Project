using System.ComponentModel.DataAnnotations;

namespace Hub.Models.Extra
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }


        [Required, StringLength(50), Display(Name = "Coupon Name")]
        public string CouponName { get; set; }


        [Required, StringLength(50), Display(Name = "Coupon Code")]
        public string CouponCode { get; set; }


        [Required, Display(Name = "Discount Percentage")]
        public double DiscountPercentage { get; set; }


        [Required,]
        public bool Status { get; set; } = false;  // For controling Specific Coupon type to enable and disable






    }
}
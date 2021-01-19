using Hub.Models.Organization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hub.Models.Advertisement
{
    public class OrgFee
    {
        [Key]
        public int OrgFeeId { get; set; }

        public int ModuleId { get; set; } // fee will be created based on each module type 
        public Module Module { get; set; }


        [Required, StringLength(150, MinimumLength = 2), Display(Name = "Fee Name")]
        public string OrgFeeName { get; set; }


        [Required, DataType(DataType.Currency), Display(Name = "Fee Price")] // price is per module per day 
        public double OrgFeePrice { get; set; }
        //if feature is on sale control of normal price and saleprice can be altered by true/false
        public bool OnSale { get; set; }
        [DataType(DataType.Currency), Display(Name = "Sale Fee Price")] // price is per module per day 
        public double OrgSaleFeePrice { get; set; }



        [Required, StringLength(500, MinimumLength = 2), Display(Name = "Fee Detail")]
        public string OrgFeeDetail { get; set; }



        [Required, Display(Name = "Maximum Advertisement Count")] // this will be used to restricet the total number of specific Adv type to be purchased
        public int MaxCount { get; set; }


        public ICollection<Adv> Advs { get; set; }
    }


}
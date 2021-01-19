using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Advertisement
{
    public class Adv
    {
        [Key]
        public int AdvId { get; set; }


        public string Id { get; set; }  // auto pull the ID of the current signed in user 
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }

        public int OrgFeeId { get; set; }

        public OrgFee OrgFee { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;  //date the Adv was applied for 



        [Required, Display(Name = "Advertisement Start Date")]
        [DataType(DataType.Date)]
        // start date of the Adv
        public DateTime AdvStartDate { get; set; }



        [Required, Display(Name = "Advertisement End Date")]  //End date of the Adv
        [DataType(DataType.Date)]
        public DateTime AdvEndDate { get; set; }



        [StringLength(500, MinimumLength = 4), Display(Name = "Advertisement Highlight Text")]  // Main text user will input to display on the Adv Banner Area
        public string AdvText { get; set; }



        [Display(Name = "Advertisement Banner Image"), StringLength(100)]  // single image when user upload second  the exising file needs to be overwrite 
        public string AdvBannerImg { get; set; }



        [Required, DataType(DataType.Currency), Display(Name = "Total Price")]  // This will be the total count of  all the selected OrgFee from AdvOrg Fee table 
        public double AdvFee { get; set; }



        [Required, Display(Name = "Advertisement Status")]  // By default all the Advstatus will be false untill the user has paid that Specific fee  once its verified will be enabled for display
        public bool ADVStatus { get; set; } = false;

    }
}

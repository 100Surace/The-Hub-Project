using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Advertisement
{
    public class Annual
    {
        // Note: we need to short by Date on expire date to get latest annual Id. 

        [Key]
        public int AnnualId { get; set; }


        public int OrgFeeId { get; set; } //inserted by sumesh need to check as annual fee will also depends on module type
        public OrgFee OrgFee { get; set; }



        public string Id { get; set; }     // this has to pull current signed in user 
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }


        [Required, DataType(DataType.DateTime), Display(Name = "Annual Fee Payment Date")] //the day fee is paid
        public DateTime PaidDate { get; set; }


        [Required, DataType(DataType.DateTime), Display(Name = "Next Payment Start Date")]  /// if fee is paid in advance this will caluclate when will be the next payment date without hampering current year
        public DateTime StartDate { get; set; }


        [Required, DataType(DataType.DateTime), Display(Name = "Next Payment End Date")]  // due date for that payment 
        public DateTime EndDate { get; set; }


        [ScaffoldColumn(false)]
        public DateTime AnnualCreatedDate { get; set; } = DateTime.UtcNow;  // date when  user applied for annual fee



        [Required, Display(Name = "Annual Status")]  //by default all the Org user will be inactive unless the value is set to ture after fee is paid
        public Boolean Status { get; set; } = false;


    }
}

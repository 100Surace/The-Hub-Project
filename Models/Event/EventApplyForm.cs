using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hub.Models.Event
{
    public class EventApplyForm
    {
        [Key]
        public int EventApplyId { get; set; }


        public string Id { get; set; }   // auto pull signed in user details hidden field cannot be overwritten
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }


        public int EventRegoId { get; set; }  // auto pull the ID of the EventRego the user has selected 
        public EventRego EventRego { get; set; }



        [Required, Display(Name = "First Name"), StringLength(15, MinimumLength = 2)] // auto pull signed in user details but can be overwritten
        public string FirstName { get; set; }



        [Display(Name = "Middle Name"), StringLength(15, MinimumLength = 2)] // auto pull signed in user details but can be overwritten
        public string MiddleName { get; set; }



        [Required, Display(Name = "Last Name"), StringLength(15, MinimumLength = 2)]// auto pull signed in user details but can be overwritten
        public string LastName { get; set; }



        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone Number")] // auto pull signed in user details but can be overwritten
        public string Contact { get; set; }



        [Required, DataType(DataType.EmailAddress), Display(Name = "Email Address")]  // auto pull signed in user details but can be overwritten
        public string Email { get; set; }



        [Required]
        public int NumOfPerson { get; set; }   //increase in this increase the price 



        [Required, Display(Name = "Total Event Fee")]
        public double TotalFee { get; set; } // increase the total fee if the number of person increase



        [ScaffoldColumn(false)]
        public DateTime EventApplyDate { get; set; } = DateTime.UtcNow;

    }
}
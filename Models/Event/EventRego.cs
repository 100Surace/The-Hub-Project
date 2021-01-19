using Hub.Models.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Event
{
    public class EventRego
    {
        [Key]
        public int EventRegoId { get; set; }


        public int OrgId { get; set; }  // auto pull signed in Org details but cannot be overwritten and hidden field
        public Org Org { get; set; }



        [Required, StringLength(100, MinimumLength = 2), Display(Name = "Event Name")]
        public string EventName { get; set; }



        [Required, StringLength(500, MinimumLength = 2), Display(Name = "Short Description")]
        public string ShortDesc { get; set; }



        [StringLength(2000, MinimumLength = 2), Display(Name = "Long Description")]
        public string LongDesc { get; set; }



        [Required, Display(Name = "Event Start Date")]
        public DateTime EventStartDate { get; set; }



        [Required, Display(Name = "Event End Date")]
        public DateTime EventEndDate { get; set; }



        [Display(Name = "Event Guest"), StringLength(500, MinimumLength = 3)]  // make this multi line field when user press enter should give them next line
        public string EventGuest { get; set; }



        [Required, Display(Name = "Event Country"), StringLength(100, MinimumLength = 2)]  // bring the country drop down 
        public string EventCountry { get; set; }



        [Required, Display(Name = "Event Address"), StringLength(200, MinimumLength = 5)]   // use the street address validator 
        public string EventAddress { get; set; }



        [Required, Display(Name = "Event City"), StringLength(100, MinimumLength = 2)]
        public string EventCity { get; set; }



        [Required, Display(Name = "Event State"), StringLength(50, MinimumLength = 2)]
        public string EventState { get; set; }



        [Required, Display(Name = "Event Zip/Postal Code")]  // use the postalcode validator
        public int EventZip { get; set; }



        [Display(Name = "Event Image "), StringLength(100)] //single image file when user uploads the second one it should overwrite the first one 
        public string EventImage { get; set; }



        [Required, DataType(DataType.Currency), Display(Name = "Event Fees")]
        public double EventFee { get; set; }



        [Display(Name = "Event Award"), StringLength(200, MinimumLength = 2)]
        public string EventAward { get; set; }



        [ScaffoldColumn(false)]
        public DateTime EventRegisterDate { get; set; } = DateTime.UtcNow;

        // Causing HubDBContext error - Tom
        public int MaxPerson { get; set; }


        public ICollection<EventApplyForm> EventApplyForms { get; set; }
    }

}

using Hub.Models.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.OrganizationFeature
{
    public class Rating
    {

        [Key]
        public int RatingId { get; set; }


        public int OrgId { get; set; }
        public Org Org { get; set; }


        [Required, Display(Name = "My Rating")]   // this will be displayed in term of thes stars when user clicks on start the value must be saved here 
        public double RatingValue { get; set; }


        [Display(Name = "Rater"), StringLength(100)]  // pulled the current signed in user id
        public string Rater { get; set; }


        [ScaffoldColumn(false)]
        public DateTime RateddDate { get; set; } = DateTime.UtcNow;  // auto fill rated date and time 

    }
}

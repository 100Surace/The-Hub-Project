using Hub.Models.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.OrganizationFeature
{
    public class Facility
    {

        [Key]
        public int FacilityId { get; set; }


        public int OrgId { get; set; }
        public Org Org { get; set; }



        [Required, StringLength(100, MinimumLength = 5), Display(Name = "Facility Name")]
        public string FacilityName { get; set; }



    }
}

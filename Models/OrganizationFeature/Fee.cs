using Hub.Models.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.OrganizationFeature
{
    public class Fee
    {
        [Key]
        public int FeeId { get; set; }

        public int OrgId { get; set; }
        public Org Org { get; set; }


        [Required, StringLength(50, MinimumLength = 2), Display(Name = "Fee Name")]
        public string FeeName { get; set; }


        [Required, DataType(DataType.Currency), Display(Name = "Fee Price")]
        public double FeePrice { get; set; }



    }
}

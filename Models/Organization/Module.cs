using Hub.Models.Advertisement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Organization
{
    public class Module
    {
        [Key]
        public int Ids { get; set; }

        [Required, StringLength(20, MinimumLength = 2), Display(Name = "Module Name")]
        public string ModuleName { get; set; }


        public ICollection<ModuleCategory> ModuleCategories { get; set; }  //one module will have multiple module category 


        public ICollection<OrgFee> OrgFees { get; set; }  // one module will have multiple orgfee type 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Organization
{
    public class ModuleCategory
    {
        [Key]
        public int Ids { get; set; }


        [Display(Name = "Select The Module")]
        public int ModuleId { get; set; }
        public Module Module { get; set; }



        [Required, StringLength(20, MinimumLength = 2), Display(Name = "Module Category Name")]
        public string ModuleCategoryName { get; set; }



        public ICollection<Org> Orgs { get; set; }  //one module will have multiple organization  
    }
}

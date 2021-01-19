using Hub.Models.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Controllers.Info
{
    public class NewsRegister
    {
        [Key]
        public int NewsId { get; set; }


        public int OrgId { get; set; }
        public Org Org { get; set; }


        [Required, StringLength(250, MinimumLength = 2), Display(Name = "News Title")]
        public string NewsTitle { get; set; }


        [Required, StringLength(2000, MinimumLength = 2), Display(Name = "News Details")]
        public string NewsDesc { get; set; }


        [StringLength(200), Display(Name = "News Image")]  // only one image can be uplaoaded here if the user uploads new image previous image needs to be overwrited 
        public string Image { get; set; }


        [StringLength(200), Display(Name = "Upload News Document")]  //this field needs to be validated user can oly upload PDF file or Word File  Max size 5mb  
        public string Attachment { get; set; }


        [DataType(DataType.Url), Display(Name = "News Link")]
        public string NewsLink { get; set; }


        [Required, ScaffoldColumn(false)]
        public DateTime PostDate { get; set; } = DateTime.UtcNow;



    }
}

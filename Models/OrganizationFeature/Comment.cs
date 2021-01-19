using Hub.Models.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.OrganizationFeature
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }

        // When clicked comment under the view of organization this should auto populate depending on the organization
        public int OrgId { get; set; }
        public Org Org { get; set; }

        [Required, Display(Name = "Commentor Name")]  // auto pull the current signed in user Name 
        public string Commentor { get; set; }



        [StringLength(500, MinimumLength = 5), Display(Name = "Please Comment")]
        public string CommentDetail { get; set; }



        [Display(Name = "Post Date"), ScaffoldColumn(false)]
        public DateTime PostDate { get; set; } = DateTime.UtcNow;  // To display commented date


        public ICollection<CommentReply> CommentReplies { get; set; }


    }
}

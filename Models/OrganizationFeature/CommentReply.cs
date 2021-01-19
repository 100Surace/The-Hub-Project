using System;
using System.ComponentModel.DataAnnotations;

namespace Hub.Models.OrganizationFeature
{
    public class CommentReply
    {
        [Key]
        public int CommentReplyId { get; set; }


        public int CommentId { get; set; }  //when clicked on reply under comment auto pull the current comment ID of the respective comments
        public Comment Comment { get; set; }


        [Display(Name = "Commentor"), StringLength(100)]    //auto pull current signed in user id  (display name on view tho)
        public string Commentor { get; set; }



        [Required, StringLength(800, MinimumLength = 2), Display(Name = "Reply")]
        public string ReplyCommentDetail { get; set; }



        [ScaffoldColumn(false)]
        public DateTime PostDate { get; set; } = DateTime.UtcNow;  //Display comment replied date auto post


    }
}
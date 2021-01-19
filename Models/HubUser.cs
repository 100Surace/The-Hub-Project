using Hub.Models.Advertisement;
using Hub.Models.Event;
using Hub.Models.Extra;
using Hub.Models.Organization;
using Hub.Models.OrganizationFeature;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models
{
    public class HubUser :IdentityUser
    {

        [PersonalData]
        [Required, StringLength(30, MinimumLength = 3), Display(Name = "Street Address")]
        public string Address { get; set; }


        [PersonalData]
        [Required, StringLength(20, MinimumLength = 3), Display(Name = "City")]
        public string City { get; set; }


        [PersonalData]
        [Required, StringLength(20, MinimumLength = 3), Display(Name = "State/Province")]
        public string State { get; set; }


        [PersonalData]
        [Required, DataType(DataType.PostalCode), Display(Name = "Zip/Postal Code")]
        public int Zip { get; set; }

        [PersonalData]
        [Required, StringLength(20, MinimumLength = 3), Display(Name = "Country")]
        public string Country { get; set; }

        [PersonalData]
        [Required, Display(Name = "User Status")]
        public Boolean UserStatus { get; set; } = false;



        public ICollection<WatchList> WatchList { get; set; }


        public ICollection<Adv> Advs { get; set; }

        public ICollection<UserDetail> UserDetails { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<CommentReply> CommentReplies { get; set; }

        public ICollection<EventApplyForm> EventApplyForm { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Organization
{
    public class UserDetail
    {
        [Key]
        public int Ids { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }

        [Required, StringLength(20, MinimumLength = 2), Display(Name = "Your First Name")]
        public string FirstName { get; set; }



        [StringLength(20, MinimumLength = 2), Display(Name = "Your Middle Name")]
        public string MiddleName { get; set; }



        [Required, StringLength(20, MinimumLength = 2), Display(Name = "Your Last Name")]
        public string LastName { get; set; }


        [Required, DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        public enum gender
        {
            Male,
            Female,
            Other
        }

        [Required, Display(Name = "Gender")]
        public gender Gender { get; set; }


        [ScaffoldColumn(false)]
        public DateTime UserDetailsCreatedDate { get; set; } = DateTime.UtcNow;  // user details filled date 

        public string ProfilePicture { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models
{
    public class HubUser: IdentityUser<Guid>
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required,StringLength(50)]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string ProfileImage { get; set; }
        [NotMapped]
        public IFormFile PImage { get; set; }


        [Required, DefaultValue(false)]
        public bool IsCompany { get; set; } = false;


        [Required, DefaultValue(true)]
        public bool Status { get; set; } = true;


        public ICollection<HubAddress> HubAddresses { get; set; }

        public ICollection<CompanyUser> CompanyUsers { get; set; }


    }
}

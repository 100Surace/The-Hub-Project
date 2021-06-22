using Hub.Models.Admin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models
{
    public class CompanyProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public HubUser User { get; set; }

        [Required]
        public int ModuleCatgoryId { get; set; }
        public ModuleCategory ModuleCategory { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(20)]
        public string ServiceType { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(20)]
        public string OrganizationType { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(100)]
        public string CompanyName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(300)]
        public string ShortDescription { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string LongDescription { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string BannerImage { get; set; }
        [NotMapped]
        public IFormFile BImage { get; set; }

        [Required, DefaultValue(false)]
        public bool Status { get; set; } = false;

        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Editable(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public ICollection<CompanyUser> CompanyUsers { get; set; }
    }
}

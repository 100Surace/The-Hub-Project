using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models
{
    public class CompanyUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public HubUser User { get; set; }

        public int CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }


        [Required, StringLength(15)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string CompanyRole { get; set; }


        [Required, DefaultValue(true)]
        public bool Status { get; set; } = true;


        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Editable(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models
{
    public class HubAddress
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(60)]
        public string AddressName { get; set; }

        [Required]
        public string UserId { get; set; }
        public HubUser User { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(100)]
        public string Address1 { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(100)]
        public string Address2 { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string City { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string Region { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(50)]
        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

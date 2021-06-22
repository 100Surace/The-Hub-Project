using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Admin
{
    public class ModuleCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ModuleId { get; set; }
        public Module Module { get; set; }

        [Required,StringLength(80)]
        public string ModuleCategoryName { get; set; }

        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

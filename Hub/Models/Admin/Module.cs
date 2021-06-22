using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Admin
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string ModuleName { get; set; }

        [Editable(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<ModuleCategory> ModuleCategories { get; set; }
    }
}

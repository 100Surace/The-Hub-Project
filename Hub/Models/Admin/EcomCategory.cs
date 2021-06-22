using Hub.Models.Ecommerce.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Admin
{
    public class EcomCategory
    {
        [Key]
        public int Id { get; set; }  //make this recursive surace 6/2/2021

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required, StringLength(50)]
        public string CategoryName { get; set; }


        [ForeignKey(nameof(EcomCategory))]
        public int? ParentcategoryId { get; set; }
        public EcomCategory ParentEcomCategory { get; set; } //nav.prop to parent 
        public ICollection<EcomCategory> EcomCategories { get; set; } //nav. prop to children 

        public ICollection<Product> Products { get; set; }
    }
}

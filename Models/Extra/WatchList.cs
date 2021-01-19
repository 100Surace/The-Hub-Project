using Hub.Controllers.Info;
using Hub.Models.Advertisement;
using Hub.Models.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class WatchList
    {
        [Key]
        public int WatchListId { get; set; }


        public string Id { get; set; }  //Auto pull current signed in user ID
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }


        public int? EventRegoId { get; set; }  //nullable can be empty 
        public EventRego EventRego { get; set; }


        public int? NewsId { get; set; }  // nullable can be empty 
        public NewsRegister NewsRegister { get; set; }


        public int? AdvId { get; set; } // nullable can be empty 
        public Adv Adv { get; set; }

    }
}

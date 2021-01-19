using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class CashPayment
    {
        [Key]
        public int CashPaymentId { get; set; }


        [Display(Name = "Receiver")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }

        // to check and fill in the data based on orderheaderid given to each order
        public string RefFromOrderHeader { get; set; }



        public DateTime CashPaidDate { get; set; }
    }

}

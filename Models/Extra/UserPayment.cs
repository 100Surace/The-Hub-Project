using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Models.Extra
{
    public class UserPayment
    {

        [Key]
        public int UserPaymentId { get; set; }


        public string Id { get; set; }  // auto pull the ID of the current signed in user 
        [ForeignKey("Id")]
        public HubUser HubUser { get; set; }


        public string PaymentType { get; set; }


        [DataType(DataType.Url)]
        public string PaymentUrl { get; set; }


        [StringLength(100)]
        public string BankAccount { get; set; }

    }
}

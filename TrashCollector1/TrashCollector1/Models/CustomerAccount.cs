using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector1.Models
{
    public class CustomerAccount
    {
        [Key]
        public int CustomerAccountId { get; set; }


        [ForeignKey("Customer")]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public double MoneyOwed { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public string WeeklyPickUpDay { get; set; }
        public bool CurrentlySuspended { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector1.Models
{
    public class SuspendAccount
    {
        [Key]
        public int id { get; set; }

                     
        [Display(Name = "Account Suspend Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AccountSuspendDate { get; set; }

        [Display(Name = "Account Suspend End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AccountSuspendEndDate { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    
        public string ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }





    }
}

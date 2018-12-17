using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        
        public bool? IsConfirmed { get; set; }
        //Regular pickup
        [Display(Name = "Pickup Day of Week")]
        public DayOfWeek PickupDayOfWeek { get; set; }
        public string Time { get; set; }
      
        [Display(Name = "Description")]
        public String Description { get; set; }

        //special pickup
        [Display(Name = "Special Pickup Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SpecialPickupDate { get; set; }

        //Suspend Account
        [Display(Name = "Account Suspend Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AccountSuspendDate { get; set; }

        [Display(Name = "Account Suspend End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AccountSuspendEndDate { get; set; }
        [Display(Name = "Was trash collected?")]
        public bool PickupCompleted { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

       


    }
}
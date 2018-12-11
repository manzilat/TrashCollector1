using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector1.Models
{
    public class SpecialPickup
    {
        [Key]
        [Display(Name = "Special Pickup ")]
        public bool PickupActive { get; set; }

        [Display(Name = "Special Pickup Day of Week")]
        public DayOfWeek PickupDayOfWeek { get; set; }

        [Display(Name = "Special Pickup Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickupStartDate { get; set; }

        [Display(Name = "Special Pickup End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickupEndDate { get; set;
        }
        [Display(Name = "Price per Special Pickup")]
        public double PickupPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
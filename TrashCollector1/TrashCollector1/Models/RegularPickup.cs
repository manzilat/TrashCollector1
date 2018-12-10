using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector1.Models
{
    public class RegularPickup
    {
        [Key]
        [Display(Name = "Usual Pickup ")]
        public bool PickupActive { get; set; }

        [Display(Name = "Usual Pickup Day of Week")]
        public DayOfWeek PickupDayOfWeek { get; set; }

        [Display(Name = "Usual Pickup Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickupStartDate { get; set; }

        [Display(Name = "Usual Pickup End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickupEndDate { get; set; }

        [Display(Name = "Price per Usual Pickup")]
        public double PickupPrice { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
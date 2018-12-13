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
        public int Id { get; set; }



        [Display(Name = "Pickup Day of Week")]
        public DayOfWeek PickupDayOfWeek { get; set; }

        
        public string Time { get; set; }
        public string PickupAddress { get; set; }
        public string Zip { get; set; }
        [Display(Name = "Description")]
        public String Description { get; set; }

       

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
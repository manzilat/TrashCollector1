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
        public int id { get; set; }             
        [Display(Name = "Special Pickup Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickupDate { get; set; }

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
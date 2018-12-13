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
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("RegularPickup")]
        public int? RegularPickupId { get; set; }
        public RegularPickup RegularPickup { get; set; }

        [ForeignKey("SpecialPickup")]
        public int? SpecialPickupId { get; set; }
        public SpecialPickup SpecialPickup { get; set; }

        [ForeignKey("SuspendAccount")]
        public int? SuspendAccoutId { get; set; }
        public SuspendAccount SuspendAccount { get; set; }


    }
}
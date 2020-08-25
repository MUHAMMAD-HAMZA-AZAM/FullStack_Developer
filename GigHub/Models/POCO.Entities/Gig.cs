using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models.POCO.Entities
{
    public class Gig
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        //public string  Artist_Id { get; set; }

        [Required]
        public virtual ApplicationUser Artist { get; set; }

        //public byte Genre_Id { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }
    }
}
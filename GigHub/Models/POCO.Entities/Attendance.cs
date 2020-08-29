using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace GigHub.Models.POCO.Entities
{
    public class Attendance
    {
        
        [Key]
        [Column(Order =1)]
        public int GigId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }


        public virtual Gig Gig { get; set; }
        public virtual ApplicationUser Attendee { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub.Models.POCO.Entities
{
    public class Following
    {
        [Key]
        [Column(Order =1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }

        public virtual ApplicationUser Follower { get; set; }
        public virtual ApplicationUser Followee { get; set; }
    }
}
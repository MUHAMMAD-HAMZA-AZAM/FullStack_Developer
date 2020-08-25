using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models.POCO.Entities
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public virtual ICollection<Gig> GetGigs { get; set; }
    }
    //Genre means a type of art, literature, or music characterized by a specific form,
    //    content, and style.For example, literature has four main genres: poetry, drama, fiction, 
    //    and non-fiction.
}
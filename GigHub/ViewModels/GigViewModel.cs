using GigHub.Models.POCO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.ViewModels
{
    
    public class GigViewModel
    {
        public GigViewModel()
        {
            GenreList = new List<Genre>();
            GigsList = new List<Gig>();
        }

        [Required(ErrorMessage =("* Venue is Required"))]
        public string Venue { get; set; }

        [Required(ErrorMessage = ("* Gig Date is Required"))]
        public string Date { get; set; }

        [Required(ErrorMessage = ("* Gig Time is Required"))]
        public string Time { get; set; }
        public IEnumerable<Genre> GenreList { get; set; }

        [Required(ErrorMessage = ("* Select a Genre"))]
        public byte SelectedGenreId { get; set; }

        public List<Gig> GigsList { get; set; }

    }
}
using GigHub.Models;
using GigHub.Models.POCO.Entities;
using GigHub.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GigViewModel _gigViewModel;
        private readonly Gig _gig;
       
        public GigsController()
        {
            _context = new ApplicationDbContext();
            _gigViewModel = new GigViewModel();

            _gig = new Gig();
        }
        // GET: Gigs
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.Authorize]
        [HttpGet]
        public ActionResult AddGig()
        {
            _gigViewModel.GenreList = _context.Genres.ToList();

            return View(_gigViewModel);
        }

        [System.Web.Mvc.Authorize]
        [HttpPost]
        public ActionResult AddGig(GigViewModel gigViewModel)
        {
            if (ModelState.IsValid)
            {

                //We Can compare User.Identity.GetUserId() Function in LinQ Method !!
                // Because this Method is Purely a C Sharp Code !!!
                //    var artist = _context.Users.Where(u => u.Id == User.Identity.GetUserId());

                var artistId = User.Identity.GetUserId();

                //In the following code, we use the Single method which takes one predicate as a parameter.
                //Using that predicate we specify our condition which is going to return only one element from the sequence.

                var artist = _context.Users.Single(u => u.Id == artistId);
                var genre = _context.Genres.Single(g => g.Id == gigViewModel.SelectedGenreId);
               
                 _gig.Venue = gigViewModel.Venue;
                _gig.Artist = artist;
                _gig.Genre= genre;
                    _gig.DateTime = DateTime.Parse(string.Format("{0} {1}", gigViewModel.Date, gigViewModel.Time));
                    _context.Gigs.Add(_gig);
                    _context.SaveChanges();
                    return RedirectToAction("Index","Home");

            }
            return View();
        }

    }
}
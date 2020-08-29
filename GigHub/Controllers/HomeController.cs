using GigHub.Models;
using GigHub.Models.POCO.Entities;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly GigViewModel _gigViewModel;
        

        public HomeController()
        {
            _applicationDbContext = new ApplicationDbContext();
            _gigViewModel = new GigViewModel();
        }

        [Authorize]
        public ActionResult Index()
        {
            var artistId = User.Identity.GetUserId();
            _gigViewModel.GigsList = _applicationDbContext.Gigs.Include(g=> g.Genre).Where(g => g.Artist.Id == artistId).ToList();
            //var upcomingGigs = _applicationDbContext.Gigs
            //    .Include(g => g.Artist)
            //    .Where(g => g.DateTime > DateTime.Now);
            return View(_gigViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
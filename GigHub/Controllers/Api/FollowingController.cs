using GigHub.DTO_s;
using GigHub.Models;
using GigHub.Models.POCO.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingController : ApiController
    {
        ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO followingdto)
        {
            var UserId = User.Identity.GetUserId();
            var IsExist = _context.Followings.Any(f => f.FollowerId == UserId && f.FolloweeId == followingdto.followeeId);
            if (IsExist == true)
            {
                return BadRequest("Following Already Exists !!! ");
            }
            else
            {
                var following = new Following
                {
                    FollowerId=UserId,
                    FolloweeId= followingdto.followeeId

                };
                _context.Followings.Add(following);
                _context.SaveChanges();

                return Ok();
            }
        }
    }
}

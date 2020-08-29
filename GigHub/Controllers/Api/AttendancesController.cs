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
    public class AttendancesController : ApiController
    {
        ApplicationDbContext _context;
        
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO atttendanceDTO)
        {
            var attendeeId = User.Identity.GetUserId();
            var IsExist = _context.Attendances.Any(a => a.AttendeeId == attendeeId && a.GigId == atttendanceDTO.GigId);
            if (IsExist == true)
            {
                return BadRequest("This Attendance Already Exists !!! ");
            }
            else
            {
                var attendance = new Attendance
                {
                    GigId = atttendanceDTO.GigId,
                    AttendeeId = attendeeId

                };
                _context.Attendances.Add(attendance);
                _context.SaveChanges();

                return Ok();
            }
        }
    }
}

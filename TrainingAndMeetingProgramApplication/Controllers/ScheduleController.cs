using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace TrainingAndMeetingProgramApplication.Controllers
{
    public class ScheduleController : ApiController
    {
        private TrainingAndMeetingEntities db = new DAL.TrainingAndMeetingEntities();

        // POST: api/Schedule
        [ResponseType(typeof(Schedule))]
        public HttpResponseMessage PostSchedule([FromBody]ScheduleM s)
        {
            Schedule shc = new Schedule();
                var availableRooms = db.RoomDetails
                                    .Where(m => m.Schedules.All(r => r.EndTime <= s.StartTime || r.StartTime >= s.EndTime))
                                    .Where(r => r.RoomId != shc.RoomId)
                                    .Select(r => new { r.RoomId, r.RoomName });    //return all avilable rooms according to strat time and end time
                var result1 = Request.CreateResponse(HttpStatusCode.OK, availableRooms);
                return result1;
            }
    }
}

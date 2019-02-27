using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;

namespace TrainingAndMeetingProgramApplication.Controllers
{
    public class TrainingsAttendeesController : ApiController
    {
        private TrainingAndMeetingEntities db = new TrainingAndMeetingEntities();

        
        // GET: api/TrainingsAttendees/5
        [ResponseType(typeof(TrainingsAttendee))]
        public IHttpActionResult GetTrainingsAttendee(int id)
        {
            TrainingsAttendee trainingsAttendee = db.TrainingsAttendees.Find(id);
            if (trainingsAttendee == null)
            {
                return NotFound();
            }

            return Ok(trainingsAttendee);
        }

      

        // POST: api/TrainingsAttendees
        [ResponseType(typeof(TrainingsAttendee))]
        public IHttpActionResult PostTrainingsAttendee(TrainingsAttendee trainingsAttendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainingsAttendees.Add(trainingsAttendee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainingsAttendee.Id }, trainingsAttendee);
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingsAttendeeExists(int id)
        {
            return db.TrainingsAttendees.Count(e => e.Id == id) > 0;
        }
    }
}
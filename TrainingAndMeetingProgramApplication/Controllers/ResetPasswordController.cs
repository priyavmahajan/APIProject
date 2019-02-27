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
using Models;

namespace TrainingAndMeetingProgramApplication.Controllers
{
    public class ResetPasswordController : ApiController
    {
        private TrainingAndMeetingEntities db = new TrainingAndMeetingEntities();
        [HttpPut]
        // Put: api/ResetPassword/5
        [ResponseType(typeof(User))]
        public IHttpActionResult PutUser(int id,[FromBody]ResetPasswordM resetPassword)
        {
            try
            {
                var existinguser = db.Users.Where(s => s.UserId == id).FirstOrDefault<User>();
                if (existinguser != null)
                {
                    existinguser.Password = resetPassword.Password;
                    db.SaveChanges();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {

                throw new Exception("password can't be updated", e);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}
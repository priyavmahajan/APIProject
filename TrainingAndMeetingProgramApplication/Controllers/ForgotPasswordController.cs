using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Description;

namespace TrainingAndMeetingProgramApplication.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        private TrainingAndMeetingEntities db = new TrainingAndMeetingEntities();


        // POST: api/ForgotPassword
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser([FromBody]ForgotPasswordM forgotPassword) //bind userRegistration model class
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User users = new User();   //user entity
            users.Email = forgotPassword.Email;
            string code = db.Users.Where(s => s.Email == forgotPassword.Email).Select(s => s.EmailLink).FirstOrDefault();
            users.EmailLink = code;
            using (MailMessage mm = new MailMessage("priyavmahajan16@gmail.com", users.Email))  // use mail message class
                {
                    mm.Subject = "Account Activation";
                    string body = "Hello " + users.FirstName + ",";
                    body += "<br /><br />Please click the following link to Reset your password";
                    body += "<br /><a href = 'http://localhost:50544/api/ForgotPassword/VeryFiyAccount/" + code + "'>Click here to activate your account.</a>";  //append activation code with verify account url
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";   //use smtp host of gmail
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("priyavmahajan16@gmail.com", "swami@pilu");   //credential of mail senders mail account
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;   //smtp post number
                    smtp.Send(mm);
                }
                return CreatedAtRoute("DefaultApi", new { id = users.UserId }, users);
            }
        [HttpGet]
        public string VeryFiyAccount(string activationCode)
        {
            string str = "";
            db.Configuration.ValidateOnSaveEnabled = false;
           
           var value = db.Users.Where(a => a.EmailLink == activationCode).FirstOrDefault();
            if (value != null)
            {
                str = "Dear user, you are able to reset the password";
            }
            else
            {
                str = "Dear user, you are not allowed to reset your password";
            }
            return str;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

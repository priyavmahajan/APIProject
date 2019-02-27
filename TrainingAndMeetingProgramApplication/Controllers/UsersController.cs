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
    public class UsersController : ApiController
    {
        private TrainingAndMeetingEntities db = new TrainingAndMeetingEntities();


        // POST: api/Users
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser([FromBody]UserRegistrationModel userRegisteartionModel) //bind userRegistration model class
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User users = new User();   //user entity
            users.FirstName = userRegisteartionModel.FirstName;
            users.LastName = userRegisteartionModel.LastName;
            users.Email = userRegisteartionModel.Email;
            users.Password = userRegisteartionModel.Password;
            Random random = new Random();   //random class object use to generate random string
            string code = random.Next().ToString();     //var code get random generated string 
            users.EmailLink = code;      //save random generated string into db
            users.UpdatedAt = DateTime.Now;
            users.CreatedAt = DateTime.Now;
            users.RoleId = 2;
            db.Users.Add(users);
            db.SaveChanges();

            using (MailMessage mm = new MailMessage("priyavmahajan16@gmail.com", users.Email))  // use mail message class
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + users.FirstName + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = 'http://localhost:50544/api/Users/VeryFiyAccount/" + code + "'>Click here to activate your account.</a>";  //append activation code with verify account url
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
        [Route("VeryFiyAccount/{id}")]
        public IHttpActionResult VeryfiyUserAccount(string id)
        {
            string str = "";
            try
            {
                str = VeryFiyAccount(id);    //verify user account by id
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });   //to cheack httpstatus
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            return Ok(str);
        }
        [HttpGet]
        public string VeryFiyAccount(string activationCode)
        {
            string str = "";
            db.Configuration.ValidateOnSaveEnabled = false;
            var value = db.Users.Where(a => a.EmailLink == activationCode).FirstOrDefault();
            if (value != null)
            {
                value.IsActive = true;
                db.SaveChanges();
                str = "Dear user, Your email successfully activated now you can able to login";
            }
            else
            {
                str = "Dear user, Your email not activated";
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

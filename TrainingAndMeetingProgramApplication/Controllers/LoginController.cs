using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace TrainingAndMeetingProgramApplication.Controllers
{
    public class LoginController : ApiController
    {
        private TrainingAndMeetingEntities db = new TrainingAndMeetingEntities();
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginRequest login)        {            var loginResponse = new LoginResponse { };            LoginRequest loginrequest = new LoginRequest { };            loginrequest.Email = login.Email;            loginrequest.Password = login.Password;            IHttpActionResult response;            HttpResponseMessage responseMsg = new HttpResponseMessage();

            if (login != null)
            {
                var result = db.Users.Where(a => a.Email == login.Email && a.Password == login.Password).FirstOrDefault();  // to check data with database

                string token = createToken(loginrequest.Email);
                return Ok<string>(token);            }            else            {
                // if credentials are not valid send unauthorized status code in response
                loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;                response = ResponseMessage(loginResponse.responseMsg);                return response;            }        }        private string createToken(string username)        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(1);
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {              new Claim(ClaimTypes.Name, username)
              //new Claim(ClaimTypes.NameIdentifier,userId.ToString())

            });            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";            var now = DateTime.UtcNow;            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token = (JwtSecurityToken)
tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:61574", audience: "http://localhost:61574",
subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);            var tokenString = tokenHandler.WriteToken(token);            return tokenString;        }

       
    }
}

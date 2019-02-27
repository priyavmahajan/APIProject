using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Login
    {
       
    }
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
    }

    public class LoginResponse
    {
        public LoginResponse()
        {

            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
            
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }

    }
}

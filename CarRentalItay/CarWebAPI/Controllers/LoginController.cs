using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarWebAPI.Models;

namespace CarWebAPI.Controllers
{
    public class LoginController : ApiController
    {
        CarRentSystemEntities db = new CarRentSystemEntities();

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [Route("api/Login/createlogin")]
        [HttpPost]
        public object createlogin(Registration Lgi)
        {
            try
            {


                User loginUser = new User();
                if (loginUser.ID==0)
                {
                    loginUser.FirstName = Lgi.FirstName;
                    loginUser.LastName = Lgi.LastName;
                    loginUser.UserName = Lgi.UserName;
                    loginUser.DateOfBirth = Lgi.DateOfBirth;
                    loginUser.Gender = Lgi.Gender;
                    loginUser.Email = Lgi.Email;
                    loginUser.UserPassword = Lgi.UserPassword;
                    loginUser.IsAdmin = Lgi.IsAdmin;

                    db.Users.Add(loginUser);
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };

                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("api/Login/UserLogin")]
        [HttpPost]
        public Response Login(Login Lg)
        {
            User currentUser;
            try
            {
                currentUser = db.Users.Where(x => x.UserName == Lg.userName && x.UserPassword == Lg.userPassword).FirstOrDefault();

                var userId = currentUser.ID;
                if (currentUser != null)
                {
                    if (currentUser != null && currentUser.IsAdmin == true)
                    {
                        return new Response { Status = "success admin", Message = "admin", LoginUserId = userId };

                    }
                    else if (currentUser != null && currentUser.IsAdmin == false)
                    {
                        return new Response { Status = "success user", Message = "user", LoginUserId = userId };

                    }
                    else  return new Response { Status = "fail", Message = "not valid user | pass" };

                }
                else { return new Response { Status = "failed", Message = "user or pass incorrect" }; }
            }
            catch (Exception)
            {

                return new Response { Status = "failed", Message = "user/pass not valid" };
            }

        }
        [Route("api/Login/UserType")]
        [HttpPost]
        public Response Type(Login Lg)
        {
            User currentUser;
            try
            {
                currentUser = db.Users.Where(x => x.UserName == Lg.userName && x.UserPassword == Lg.userPassword && x.IsAdmin == true).FirstOrDefault();
                if (currentUser != null && currentUser.IsAdmin == true)
                {
                    return new Response { Status = "admin", Message = "admin"};

                }
                else if (currentUser != null && currentUser.IsAdmin == false)
                {
                    return new Response { Status = "user", Message = "user" };

                }
                else return new Response { Status = "fail", Message = "not valid user | pass" };

            }
            catch (Exception)
            {

                throw;
            }

        }



        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}

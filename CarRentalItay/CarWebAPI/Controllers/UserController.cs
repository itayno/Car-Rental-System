using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Net.Http.Handlers;
using Newtonsoft.Json;
using CarWebAPI.Models;

namespace CarWebAPI.Controllers
{
    [RoutePrefix("api/user")]

    public class UserController : ApiController
    {
        // GET: api/User
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        CarRentSystemEntities db = new CarRentSystemEntities();


        // GET: api/User/find
        [HttpGet]
        [Route("find")]
        public HttpResponseMessage GetAll()
        {


            try
            {

                var UsersEntitiesOriginal = db.Users.ToList();


                var userEntities = UsersEntitiesOriginal.Select(p => new UserEntity()
                {
                    id = p.ID,
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    userName = p.UserName,
                    dateOfBirth = p.DateOfBirth ?? DateTime.Today,
                    gender = p.Gender,
                    email = p.Email,
                    userPassword = p.UserPassword,
                    isAdmin = p.IsAdmin ?? false,
                    image = p.Image

                });


                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(userEntities));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;

            }
            catch (Exception )
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

        // POST: api/User
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage create(UserEntity userEntity)
        {
            try
            {
                DateTime date1 = new DateTime(2015, 12, 25);
                var response = new HttpResponseMessage(HttpStatusCode.OK);

                var user = new User()
                {
                    ID = userEntity.id,
                    FirstName = userEntity.firstName,
                    LastName = userEntity.lastName,
                    UserName = userEntity.userName,
                    DateOfBirth = userEntity.dateOfBirth,
                    Gender = userEntity.gender,
                    Email = userEntity.email,
                    UserPassword = userEntity.userPassword,
                    IsAdmin = userEntity.isAdmin,
                    Image = userEntity.image


                };

                db.Users.Add(user);
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // PUT: api/User/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage update(UserEntity user)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var currentUser = db.Users.SingleOrDefault(p => p.ID == user.id);



                currentUser.ID = user.id;
                currentUser.FirstName = user.firstName;
                currentUser.LastName = user.lastName;
                currentUser.UserName = user.userName;
                //currentUser.DateOfBirth = user.dateOfBirth;
                //currentUser.Gender = user.gender;
                currentUser.Email = user.email;
                currentUser.UserPassword = user.userPassword;
                currentUser.IsAdmin = user.isAdmin;
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // DELETE: api/User/5
        [HttpDelete]
        [Route("delete/{userId}")]
        public HttpResponseMessage Delete(int userId)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var user = db.Users.SingleOrDefault(p => p.ID == userId);



                db.Users.Remove(user);
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }
    }
}

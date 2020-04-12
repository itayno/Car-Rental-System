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
    [RoutePrefix("api/carrentaldetail")]

    public class CarRentalDetailController : ApiController
    {
        // GET: api/CarRentalDetail
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        CarRentSystemEntities db = new CarRentSystemEntities();


        // GET: api/CarRentalDetail/5
        [HttpGet]
        [Route("find")]
        public HttpResponseMessage GetAll()
        {


            try
            {

                var CarRentalDetailsOriginal = db.CarRentalDetails.ToList();


                var rentalEntities = CarRentalDetailsOriginal.Select(p => new CarRentalDetailEntity()
                {
                    id = p.ID,
                    startDate = p.StartDate,
                    returnDate = p.ReturnDate,
                    actualReturnDate = p.ActualReturnDate,
                    //userId = int.Parse(p.UserID.ToString()),
                    userId = p.UserID ?? 1,
                    carNumber = p.CarNumber,
                    //isActive = p.IsActive,
                    

                });


                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(rentalEntities));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;

            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

        // POST: api/CarRentalDetail
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage create(CarRentalDetailEntity rentalEntity)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var rentalDetail = new CarRentalDetail()
                {
                    //id = rentalEntity.id,
                    StartDate = rentalEntity.startDate,
                    ReturnDate = rentalEntity.returnDate,
                    ActualReturnDate = rentalEntity.actualReturnDate,
                    UserID = rentalEntity.userId,
                    CarNumber = rentalEntity.carNumber,
                    IsActive = rentalEntity.isActive


                };

                db.CarRentalDetails.Add(rentalDetail);
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // PUT: api/CarRentalDetail/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage update(CarRentalDetailEntity rentalDetail)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var currentRental = db.CarRentalDetails.SingleOrDefault(p => p.ID == rentalDetail.id);



                currentRental.ID = rentalDetail.id;
                currentRental.StartDate = rentalDetail.startDate;
                currentRental.ReturnDate = rentalDetail.returnDate;
                currentRental.ActualReturnDate = rentalDetail.actualReturnDate;
                currentRental.CarNumber = rentalDetail.carNumber;
                currentRental.IsActive = rentalDetail.isActive;
                
                
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // DELETE: api/CarRentalDetail/5
        [HttpDelete]
        [Route("delete/{CarRentalDetailId}")]
        public HttpResponseMessage Delete(int CarRentalDetailsID)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var rentalDetails = db.CarRentalDetails.SingleOrDefault(p => p.ID == CarRentalDetailsID);



                db.CarRentalDetails.Remove(rentalDetails);
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

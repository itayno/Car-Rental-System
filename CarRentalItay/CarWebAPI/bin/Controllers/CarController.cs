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
using CarWebAPI.Parsing;

namespace CarWebAPI.Controllers
{
    [RoutePrefix("api/car")]

    public class CarController : ApiController
    {
        // GET: api/Car
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        CarRentSystemEntities db = new CarRentSystemEntities();


        // GET: api/Car/5
        [HttpGet]
        [Route("find")]
        public HttpResponseMessage GetAll()
        {
            try
            {

                var CarsOriginal = db.Cars.ToList();


                var carEntities = CarsOriginal.Select(p => new CarEntity()
                {
                    carNumber = p.CarNumber,
                    carType = p.CarType ?? int.MinValue,
                    isAvailable = p.IsAvailable,
                    isUndamaged = p.IsUndamaged,
                    mileage = p.Mileage ?? int.MinValue,
                    //isActive = p.IsActive,
                    carTypeObject =  CarTypeEntityParsing.typeObjector(p.CarType1),
                    branchObject = BranchParsing.typeObjector(p.Branch)




                });


                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(carEntities));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;

            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }
        [HttpGet]
        [Route("find/{carNumber}")]
        public HttpResponseMessage GetByID(string carNumber)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var CarsOriginal = db.Cars.ToList();
                var currentCar = CarsOriginal.Where(p => p.CarNumber == carNumber).FirstOrDefault();

                response.Content = new StringContent(JsonConvert.SerializeObject(currentCar));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST: api/Car
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage create(CarEntity carEntity)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var car = new Car()
                {
                    //id = rentalEntity.id,
                    CarNumber = carEntity.carNumber,
                     CarType = carEntity.carType,
                     IsAvailable = carEntity.isAvailable,
                     IsUndamaged = carEntity.isUndamaged,
                     Mileage = carEntity.mileage,
                     BranchID = carEntity.branchId,
                     Image = carEntity.image


                };

                db.Cars.Add(car);
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // PUT: api/Car/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage update(CarEntity carEntity)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var currentCar = db.Cars.SingleOrDefault(p => p.CarNumber == carEntity.carNumber);



                currentCar.CarNumber = carEntity.carNumber;
                currentCar.CarType = carEntity.carType;
                currentCar.IsAvailable = carEntity.isAvailable;
                currentCar.IsUndamaged = carEntity.isUndamaged;
                currentCar.Mileage = carEntity.mileage;
                //currentCar.BranchID = carEntity.branchId;
                currentCar.Image = carEntity.image;


                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }
        [HttpPut]
        [Route("updateAvailable/{carNumber}")]
        public HttpResponseMessage updateAvailable(string carNumber)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var currentCar = db.Cars.SingleOrDefault(p => p.CarNumber == carNumber);


                currentCar.IsAvailable = false;
                


                db.SaveChanges();
                return response;
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: api/Car/5
        [HttpDelete]
        [Route("delete/{carNumber}")]
        public HttpResponseMessage Delete(string carNumber)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var car = db.Cars.SingleOrDefault(p => p.CarNumber == carNumber);



                db.Cars.Remove(car);
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

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
    [RoutePrefix("api/cartype")]

    public class CarTypeController : ApiController
    {
        // GET: api/CarType
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        CarRentSystemEntities db = new CarRentSystemEntities();


        // GET: api/CarType/5
        [HttpGet]
        [Route("find")]
        public HttpResponseMessage GetAll()
        {


            try
            {

                var carTypeOriginal = db.CarTypes.ToList();


                var typeEntities = carTypeOriginal.Select(p => new CarTypeEntity()
                {
                    id = p.ID,
                    manufacturer = p.Manufacturer,
                    model = p.Model,
                    dailyCost = p.DailyCost,
                    dailyLatePenalty = p.DailyLatePenalty,
                    manufacturingYear = p.ManufacturingYear,
                    gearType = p.GearType


                });


                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(typeEntities));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;

            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

        // POST: api/CarType
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage create(CarTypeEntity TypeEntity)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var carType = new CarType()
                {
                    ID = TypeEntity.id,
                    Manufacturer = TypeEntity.manufacturer,
                    Model = TypeEntity.model,
                    DailyCost = TypeEntity.dailyCost,
                    DailyLatePenalty = TypeEntity.dailyLatePenalty,
                    ManufacturingYear = TypeEntity.manufacturingYear,
                    GearType = TypeEntity.gearType

                };

                db.CarTypes.Add(carType);
                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // PUT: api/CarType/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage update(CarTypeEntity TypeEntity)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var currentType = db.CarTypes.SingleOrDefault(p => p.ID == TypeEntity.id);



                currentType.ID = TypeEntity.id;
                currentType.Manufacturer = TypeEntity.manufacturer;
                currentType.Model = TypeEntity.model;
                currentType.DailyCost = TypeEntity.dailyCost;
                currentType.DailyLatePenalty = TypeEntity.dailyLatePenalty;
                currentType.ManufacturingYear = TypeEntity.manufacturingYear;
                currentType.GearType = TypeEntity.gearType;


                db.SaveChanges();
                return response;

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // DELETE: api/CarType/5
        [HttpDelete]
        [Route("delete/{carTypeID}")]
        public HttpResponseMessage Delete(int carTypeID)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var type = db.CarTypes.SingleOrDefault(p => p.ID == carTypeID);



                db.CarTypes.Remove(type);
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

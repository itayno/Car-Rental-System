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
    [RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {
        //CarRentSystemEntities db = new CarRentSystemEntities();
        // GET: api/Branch
        //public IEnumerable<Branch> Get()
        //{
        //    return db.Branches.ToList();
        //}
        CarRentSystemEntities db = new CarRentSystemEntities();
      
        [HttpGet]
        [Route("find")]
        public HttpResponseMessage GetAll()
        {
            

                try
                {

                    var branchEntitiesOriginal = db.Branches.ToList();


                    var branchEntities = branchEntitiesOriginal.Select(p => new BranchEntity()
                    {
                        id = p.id,
                        Branchaddress = p.BranchAddress,
                        BranchName = p.BranchName,
                        LattitudeX = int.Parse(p.LatitudeX.ToString()),
                        LongttitudeY = int.Parse(p.LongitudeY.ToString()),
                    });


                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(branchEntities));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;

                }
                catch (Exception e)
                {

                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            
        }

        

        // POST: api/Branch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Branch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Branch/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIForEmployee.Controllers
{
    //[Authorize]
    public class AuthController : ApiController
    {
        [Route("api/GetAuth")]
        public void GetAuth()
        {
            //return true;
        }

        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello REST API", "I am Authorized" };
        }

        // GET api/WebApi/5  
        public string Get(int id)
        {
            return "Hello Authorized API with ID = " + id;
        }

        // POST: api/Auth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}

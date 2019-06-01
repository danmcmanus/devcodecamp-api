using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DevCodeCamp.Api.Filters;

namespace DevCodeCamp.Api.Controllers
{
    [Authorize]
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [JwtAuthentication]
        [Route("get")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

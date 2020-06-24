using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PersonaController : ApiController
    {
        // GET: api/Persona

        public HttpResponseMessage Get()
        {
            try {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(" ");
                return response;
            }
            catch
            { 
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

           
        }

        // GET: api/Persona/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Persona
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Persona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Persona/5
        public void Delete(int id)
        {
        }
    }
}

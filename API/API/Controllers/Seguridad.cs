using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using API.Models;

namespace API.Controllers
{
    public class Seguridad: DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken Token)
        {
                bool validacionKEY = false;
                HeaderRQ rq = new HeaderRQ(); 

            try
            {
               
                var checkApiKeyExist = request.Headers.TryGetValues("X-Key", out rq.key);
                var checkApiRoutExist = request.Headers.TryGetValues("X-Route", out rq.rout);
                var checkApiSignatureExist = request.Headers.TryGetValues("X-Signature", out rq.signature);


                    if (checkApiKeyExist & checkApiRoutExist & checkApiSignatureExist)
                    {
                        if (authenticated(request.Method.ToString(), rq.rout.First().ToString()))
                         {

                        validacionKEY = true;
                      
                        var response = await base.SendAsync(request, Token);
                        return response;
                         }


                        if(unauthenticated(request.Method.ToString(), rq.rout.First().ToString()))
                         {
                        var response = await base.SendAsync(request, Token);
                        return response;
                         }

                }
                return request.CreateResponse(HttpStatusCode.NotFound, "NotFound:(");
            }
            catch
            {
                if (!validacionKEY)
                    return request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden :(");
                else
                    return request.CreateResponse(HttpStatusCode.NotFound, "NotFound:(");
            }
         
        }

        private bool authenticated(string verbo, string metodo)
        {
            if (verbo == "POST" && metodo =="message")
            {
                return true;

            }
            else if (verbo == "GET" && metodo == "message")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool unauthenticated(string verbo, string metodo)
        {
            if (verbo == "PUT" && metodo == "credential")
            {
                return true;

            }else
            {
                return false;
            }
        }

    }
}
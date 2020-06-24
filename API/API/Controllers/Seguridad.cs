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
                    string apiKeyClient = checkApiKeyExist.ToString();
                    string apiRoutClient = checkApiRoutExist.ToString();


          

                   
                    //return request.CreateResponse(HttpStatusCode.OK, "key :" + rq.key.First() + " rout:" + rq.rout.First()+" signature:"+rq.signature.First()+"hs:"+GetHash(rq.key.First(), rq.rout.First()));


                    validacionKEY = true;

                    var response = await base.SendAsync(request, Token);
                    return response;
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

        private static String GetHash(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
      

    }
}
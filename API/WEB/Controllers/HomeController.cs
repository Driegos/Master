using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.com.gt/api/Persona/");
            client.DefaultRequestHeaders.Add("X-Key", "2");
            client.DefaultRequestHeaders.Add("X-Route", "message");
            client.DefaultRequestHeaders.Add("X-Signature", "123132");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = client.GetAsync(Id).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //response.Content.ReadAsStringAsync().Result.ToString()

                ViewBag.id = response.Content.ReadAsStringAsync().Result.ToString();

            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
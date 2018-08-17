using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Leo.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        [HttpPost]
        public ActionResult Upload(string stream)
        {
            var root = HttpContext.Server.MapPath("~/App_Data");
            var files = Request.Files;
            var filenames = Request.Files.AllKeys;
            foreach (var filename in filenames)
            {
                var content = files[filename];
                content.SaveAs($"{root}/{filename}");
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            Response.End();
            return View();
        }
    }
}
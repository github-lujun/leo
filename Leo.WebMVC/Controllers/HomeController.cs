using Leo.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
            using (var context = new LeoDbContext())
            {
                var state = context.Entry(new Persons() { }).State;
                var person = context.Set<Persons>().FirstOrDefault();
                state = context.Entry(person).State;
                person = context.Set<Persons>().Find("2");
                if (person == null)
                {
                    person = new Persons()
                    {
                        Id = "2",
                        Name = "leo",
                        age = 24
                    };
                    context.Entry(person).State = EntityState.Added;
                    context.SaveChanges();
                    person = new Persons()
                    {
                        Id = "3",
                        Name = "lu",
                        age = 22
                    };
                    context.Entry(person).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    person = new Persons
                    {
                        Id = "2",
                        Name = "jack",
                        age = 26,
                    };
                    state = context.Entry(person).State;
                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                    person = context.Set<Persons>().Find("3");
                    if (person != null)
                    {
                        context.Entry(person).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                }
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
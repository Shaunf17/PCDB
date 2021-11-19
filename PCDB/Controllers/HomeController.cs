using PCDB.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Component> components = new List<Component>()
            {
                new CPU() { Name = "hello world" },
                new CPUCooler() { Name = "Cooler 4000" },
                new Case() { Name ="CAse" }
            };
            return View(components);
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
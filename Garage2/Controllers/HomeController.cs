using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garage2.DAL;
using Garage2.Models;

namespace Garage2.Controllers {
    public class HomeController : Controller {
        private VehicleDBContext db = new VehicleDBContext();

        private int NrOfSpots = 18;
        private int PricePerHour = 60;

        public ActionResult Index() {
            ViewBag.FreeSpots = FreeSpots();
            ViewBag.PricePerHour = PricePerHour;

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private int FreeSpots() {
            return NrOfSpots - db.Vehicles.Count();
        }
    }
}
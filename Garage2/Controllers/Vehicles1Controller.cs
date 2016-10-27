using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.DAL;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class Vehicles1Controller : Controller
    {
        private VehicleDBContext db = new VehicleDBContext();

        private int NrOfSpots = 18;
        private int PricePerHour = 60;

        // GET: Vehicles1
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);

            ViewBag.FreeSpots = FreeSpots();


            return View(vehicles.ToList());
        }

        public ActionResult Statistics() {
            Statistics statistics = new Statistics();
            var vehicles = db.Vehicles.Where(v => true);
            List<TimeSpan> duration = new List<TimeSpan>();

            // Count number of cars
            statistics.NrOfCars = vehicles.Where(v => v.VehicleType.Type == "Bil").Count();

            // Count number of busses
            statistics.NrOfBusses = vehicles.Where(v => v.VehicleType.Type == "Buss").Count();

            // Count number of boats
            statistics.NrOfBoats = vehicles.Where(v => v.VehicleType.Type == "Båt").Count();

            // Count number of airplanes
            statistics.NrOfAirplanes = vehicles.Where(v => v.VehicleType.Type == "Flygplan").Count();

            // Count number of motorcycles
            statistics.NrOfMotorcycles = vehicles.Where(v => v.VehicleType.Type == "Motorcykel").Count();

            // Count number of wheels in the garage
            statistics.NrOfWheels = vehicles.Select(v => v.Tyres).Sum();

            // Count total price for all vehicles in the garage
            foreach (var vehicle in vehicles) {
                duration.Add(DateTime.Now - vehicle.CheckInTime);
            }

            var totalTime = TimeSpan.Zero;
            foreach (TimeSpan currentValue in duration) {
                totalTime = totalTime + currentValue;
            }

            //int pricePerHour = 60;
            statistics.PriceAllVehicles = ((totalTime.Days * 24 + totalTime.Hours) * PricePerHour) + (totalTime.Minutes % PricePerHour);

            return View(statistics);
        }

        // GET: Receipt
        public ActionResult Receipt(Vehicle vehicle) {
            if (vehicle == null) {
                return HttpNotFound();
            }
            VehicleType vehicleType = db.VehicleTypes.Find(vehicle.VehicleTypeId);
            Member member = db.Members.Find(vehicle.MemberId);
            Receipt receipt = new Receipt();

            receipt.Type = vehicleType.Type;
            receipt.RegNr = vehicle.RegNr;
            receipt.Member = member.Name;
            receipt.ParkingTime = vehicle.ParkingTime;
            receipt.Price = vehicle.Price;

            return View(receipt);
        }

        // GET: Vehicles1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles1/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type");

            if (GarageIsFull()) {
                return RedirectToAction("FullGarage");
            } else {
                ViewBag.FreeSpots = FreeSpots();
                return View();
            }
        }

        // POST: Vehicles1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNr,Color,CheckInTime,Tyres,Brand,Model,SpotNr,MemberId,VehicleTypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CheckInTime = DateTime.Now;
                vehicle.SpotNr = NextFreeSpot();
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,Color,CheckInTime,Tyres,Brand,Model,SpotNr,MemberId,VehicleTypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Receipt", vehicle);
        }

        // GET: Vehicles/SearchVehicles
        public ActionResult SearchVehicles() {
            return View();
        }

        // Post: Vehicles/SearchVehicles
        [HttpPost]
        public ActionResult SearchVehicles(QueryObj queryObj) {
            return RedirectToAction("SearchResult", queryObj);
        }

        // GET: Vehicles
        public ActionResult SearchResult(QueryObj queryObj) {
            var query = db.Vehicles.Where(v => true);

            if (queryObj.Type != null) {
                query = query.Where(v => v.VehicleType.Type == queryObj.Type);
            }

            if (queryObj.RegNr != null) {
                query = query.Where(v => v.RegNr.ToLower().StartsWith(queryObj.RegNr.ToLower()));
            }

            if (queryObj.Color != null) {
                query = query.Where(v => v.Color.ToLower().StartsWith(queryObj.Color.ToLower()));
            }

            if (queryObj.Brand != null) {
                query = query.Where(v => v.Brand.ToLower().StartsWith(queryObj.Brand.ToLower()));
            }

            return View(query.OrderBy(v => v.RegNr).ToList()); // Always sort by regnr
        }

        private int NextFreeSpot() {
            var query = db.Vehicles.Where(v => v != null);
            for (int i = 1; i < this.NrOfSpots + 1; i++) {
                if (!query.Where(v => v.SpotNr == i).Any())
                    return i;
            }
            return 0; // if the garage is full
        }

        private int FreeSpots() {
            return NrOfSpots - db.Vehicles.Count();
        }

        private bool GarageIsFull() {
            return (FreeSpots() < 1);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

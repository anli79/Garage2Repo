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

namespace Garage2.Controllers {
    public class VehiclesController : Controller {
        private VehicleDBContext db = new VehicleDBContext();

        public int NrOfSpots { get { return 100; } }



        // GET: Vehicles
        public ActionResult Index(string sort) {
            var model = db.Vehicles.OrderBy(m => m.RegNr);

            if (sort == "type") {
                model = model.OrderBy(m => m.Type);
            }

            if (sort == "regnr") {
                model = model.OrderBy(m => m.RegNr);
            }

            if (sort == "color") {
                model = model.OrderBy(m => m.Color);
            }

            return View(model.ToList());
        }

        // GET: Receipt
        public ActionResult Receipt(Vehicle vehicle) {
            if (vehicle == null) {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null) {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNr,Color,CheckInTime,Tyres,Brand,Model")] Vehicle vehicle) {
            if (ModelState.IsValid) {
                vehicle.CheckInTime = DateTime.Now;
                vehicle.SpotNr = NextFreeSpot();
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null) {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNr,Color,CheckInTime,Tyres,Brand,Model")] Vehicle vehicle) {
            if (ModelState.IsValid) {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null) {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
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
        // public ActionResult SearchVehicles([Bind(Include = "Id,Type,RegNr,Color,CheckInTime,Tyres,Brand,Model")] Vehicle vehicle) {
        public ActionResult SearchVehicles(QueryObj queryObj) {
            // return RedirectToAction("Index");
            return RedirectToAction("SearchResult", queryObj);
        }

        // GET: Vehicles
        public ActionResult SearchResult(string sort, QueryObj queryObj) {
            var query = db.Vehicles.Where(v => true);
        
            if (queryObj.Type != null) {
                query = query.Where(v => v.Type == queryObj.Type);
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

        public int NextFreeSpot() {
            for (int i=1; i < this.NrOfSpots+1; i++) {
                if (db.Vehicles.Where(v => v.SpotNr == i).FirstOrDefault() == null) {
                    return i;
                }
            }
            return 0; // if the garage is full
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

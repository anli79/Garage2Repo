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
    public class VehiclesController : Controller
    {
        private VehicleDBContext db = new VehicleDBContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Receipt
        public ActionResult Receipt(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null) {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Details/5
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

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNr,Color,CheckInTime,Tyres,Brand,Model")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CheckInTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
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
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNr,Color,CheckInTime,Tyres,Brand,Model")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
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

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt(id);
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult SearchResult(QueryObj queryObj) {
            var query = db.Vehicles.ToList();

            if (queryObj.Type != null) {
                query = query.Where(v => v.Type == queryObj.Type).ToList();
            }

            if (queryObj.RegNr != null) {
                query = query.Where(v => v.RegNr.ToLower().StartsWith(queryObj.RegNr.ToLower())).ToList();
            }

            if (queryObj.Color != null) {
                query = query.Where(v => v.Color.ToLower().StartsWith(queryObj.Color.ToLower())).ToList();
            }

            if (queryObj.Brand != null) {
                query = query.Where(v => v.Brand.ToLower().StartsWith(queryObj.Brand.ToLower())).ToList();
            }

            return View(query);
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

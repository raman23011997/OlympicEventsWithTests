using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using olympicEvents.Models;

namespace Assignment2.Controllers
{
    
    public class EventsDetailsController : Controller
    {
        private OlympicEventsModel db = new OlympicEventsModel();

        // GET: EventsDetails
        public ViewResult Index()
        {     
         
            return View(db.EventsDetails);
        }

        // GET: EventsDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsDetail eventsDetail = db.EventsDetails.Find(id);
            if (eventsDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventsDetail);
        }
        [Authorize (Roles ="user")]
        // GET: EventsDetails/Create
        public ActionResult Create()
        {
            ViewBag.eventID = new SelectList(db.Events, "eventID", "Name");
            return View();
        }

        // POST: EventsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "event_detailID,eventID,Name,Description,Age_InYears")] EventsDetail eventsDetail)
        {
            if (ModelState.IsValid)
            {
                db.EventsDetails.Add(eventsDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.eventID = new SelectList(db.Events, "eventID", "Name", eventsDetail.eventID);
            return View(eventsDetail);
        }
        [Authorize(Roles = "user")]
        // GET: EventsDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsDetail eventsDetail = db.EventsDetails.Find(id);
            if (eventsDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.eventID = new SelectList(db.Events, "eventID", "Name", eventsDetail.eventID);
            return View(eventsDetail);
        }

        // POST: EventsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "event_detailID,eventID,Name,Description,Age_InYears")] EventsDetail eventsDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.eventID = new SelectList(db.Events, "eventID", "Name", eventsDetail.eventID);
            return View(eventsDetail);
        }
        [Authorize(Roles = "user")]
        // GET: EventsDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsDetail eventsDetail = db.EventsDetails.Find(id);
            if (eventsDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventsDetail);
        }

        // POST: EventsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsDetail eventsDetail = db.EventsDetails.Find(id);
            db.EventsDetails.Remove(eventsDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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

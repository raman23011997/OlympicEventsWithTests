using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using olympicEvents.Models;
using Assignment2.Models;
using Assignment2.Controllers;

namespace Assignment2.Controllers
{
  
    public class EventsController : Controller
    {
        private IEventsControllerRepo db;

        public EventsController(IEventsControllerRepo db)
        {
            this.db = db;

        }
        public EventsController(){
            this.db = new  EFEventsControllerRepo();

            }

		// GET: Events
		public ViewResult Index()
		{
			return View(db.Events.ToList());
		}
		// GET: Events/Details/5
		public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            // Event @event = db.Events.Find(id);
            Event events = db.Events.SingleOrDefault(a => a.eventID == id);

            if (events == null)
            {
                return View("Error"); ;
            }
            return View(events);
        }

        //// GET: Events/Create
        [Authorize(Roles = "user")]
        public ActionResult Create()
        {
            return View("Create");
        }

        //// POST: Events/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "eventID,Name,Description,Participation_Percent")] Event events)
        {

			if (ModelState.IsValid)
			{
				//db.Events.Add(events);
				//db.SaveChanges();
			
				db.save(events);
				return RedirectToAction("Index");
			}
			
				
			
			
				return View("Create", events);
			
        }

        [Authorize(Roles = "user")]
        // GET: Events/Edit/5
        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            //Event @event = db.Events.Find(id);
            Event @event= db.Events.SingleOrDefault(a => a.eventID == id);
            
            if (@event == null)
            {
                return View("Error");
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventID,Name,Description,Participation_Percent")] Event @event)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(@event).State = EntityState.Modified;
                //db.SaveChanges();
                db.save(@event);
                return RedirectToAction("Index");
            }
            return View("Edit",@event);
        }
        [Authorize(Roles = "user")]
        // GET: Events/Delete/5
        public ViewResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //Event @event = db.Events.Find(id);
            Event @event = db.Events.SingleOrDefault(a => a.eventID == id);
            if (@event == null)
            {
                return View("Error");
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public	ActionResult DeleteConfirmed(int? id)
        {
			//Event @event = db.Events.Find(id);
			//db.Events.Remove(@event);
			//db.SaveChanges();
			if (id == null)
			{
				return View("Error");
			}
            Event @event = db.Events.SingleOrDefault(a => a.eventID == id);
			if (@event == null)
			{
				return View("Error");
			}
            db.delete(@event);

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

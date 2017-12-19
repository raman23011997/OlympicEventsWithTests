using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using olympicEvents.Models;

namespace Assignment2.Models
{
    public class EFEventsControllerRepo : IEventsControllerRepo
        
    {
        OlympicEventsModel db = new OlympicEventsModel();
        public IQueryable<Event> Events{ get { return db.Events;  }
        }
        public IQueryable<EventsDetail> eventsDetail
        {
            get { return db.EventsDetails; }
        }

        public void delete(Event events)
        {
            db.Events.Remove(events);
            db.SaveChanges();
        }

        public Event save(Event events)
        {
            if (events.eventID == 0)
            {
                db.Events.Add(events);
            }
            else
            {
                db.Entry(events).State = System.Data.Entity.EntityState.Modified;
            }
            return events;
                db.SaveChanges();
        }
    }
}

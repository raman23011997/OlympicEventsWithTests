using olympicEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
   public interface IEventsControllerRepo
    {
       
        IQueryable<Event> Events { get; }

        IQueryable<EventsDetail> eventsDetail { get; }

        Event save(Event events);
        void delete(Event events);

    }
}

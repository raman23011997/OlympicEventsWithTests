using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2;
using Assignment2.Controllers;
using Moq;
using Assignment2.Models;
using olympicEvents.Models;

namespace Assignment2.Tests.Controllers

{



	[TestClass]
	public class EventsControllerTest

	{
		EventsController Controller;
		Mock<IEventsControllerRepo> mockdata;
		 List<Event> events;

		[TestInitialize]
		public void TestInitialize()
		{
			mockdata = new Mock<IEventsControllerRepo>();

			events = new List<Event>
			{
				new Event { eventID = 1, Name = "as", Description = " skjn", Participation_Percent = 75}
			};
			
			mockdata.Setup(a => a.Events).Returns(events.AsQueryable());
			
			Controller = new EventsController(mockdata.Object);
		}
		[TestMethod]
		public void Index()
		{ 
			var view = (List<Event>)Controller.Index().Model;

			CollectionAssert.AreEqual(events, view);
		}

		[TestMethod]
		public void Detailsvalid()
		{
			var valid = (Event)Controller.Details(1).Model;

			Assert.AreEqual(events.ToList()[0], valid);
		}
		[TestMethod]
		public void DetailsInvalid()
		{
			var valid = (Event)Controller.Details(1111).Model;

			Assert.IsNull(valid);
		}

		[TestMethod]
		public void Detailsnull()
		{
			int? id = null;
			var valid = Controller.Details(id);

			Assert.AreEqual("Error", valid.ViewName);
		}
		[TestMethod]
		public void Editvalid()
		{
			var valid = (Event)Controller.Edit(1).Model;

			Assert.AreEqual(events.ToList()[0], valid);
		}
		[TestMethod]
		public void EditInvalid()
		{
			var valid = (Event)Controller.Edit(1111).Model;

			Assert.IsNull(valid);
		}

		[TestMethod]
		public void Editnull()
		{
			int? id = null;

			var valid = Controller.Edit(id);

			Assert.AreEqual("Error", valid.ViewName);
		}
		[TestMethod]
		public void Deletevalid()
		{
			var valid = (Event)Controller.Delete(1).Model;

			Assert.AreEqual(events.ToList()[0], valid);
		}
		[TestMethod]
		public void DeleteInvalid()
		{
			var valid = (Event)Controller.Delete(1111).Model;

			Assert.IsNull(valid);
		}

		[TestMethod]
		public void Deletenull()
		{
			int? id = null;

			var valid = Controller.Delete(id);

			Assert.AreEqual("Error", valid.ViewName);
		}
		[TestMethod]
		public void CreateReturnView()

		{

			ViewResult valid = Controller.Create() as ViewResult;

			Assert.IsNotNull("Create", valid.ViewName);
		}
		[TestMethod]
		public void CreateValidEvent()
		{
			Event events = new Event
			{
				eventID = 1,
				Name = "as",
				Description = "as",
				Participation_Percent = 89

			};

			RedirectToRouteResult valid = (RedirectToRouteResult)Controller.Create(events);

			Assert.AreEqual("Index", valid.RouteValues["action"]);
		}
		[TestMethod]
		public void CreateInValidEvent()
		{
			Controller.ModelState.AddModelError("Key", "Exception");

			Event events = new Event
			{
				eventID = 1,
				Name = "as",
				Description = "as",
				Participation_Percent = 89
	
			};

			ViewResult valid = Controller.Create(events) as ViewResult;

			Assert.AreEqual("Create", valid.ViewName);
		}
		[TestMethod]
		public void DeleteConfirmedValidId()
		{
			RedirectToRouteResult ValidDeleteId = (RedirectToRouteResult)Controller.DeleteConfirmed(1);
			Assert.AreEqual("Index", ValidDeleteId.RouteValues["action"]);
		}
		[TestMethod]
		public void DeleteConfirmedInvalidId()
		{
			ViewResult InValidDeleteId = Controller.DeleteConfirmed(1111) as ViewResult;
			Assert.AreEqual("Error", InValidDeleteId.ViewName);
		}
		[TestMethod]
		public void DeleteConfirmedNoId()
		{
			int? a= null;
			ViewResult NoId = Controller.DeleteConfirmed(a) as ViewResult;
			Assert.AreEqual("Error", NoId.ViewName);
		}
		[TestMethod]
		public void EditSaveValid()
		{
			// arrange  
			Event a = events.ToList()[0];

			// act
			RedirectToRouteResult actual = (RedirectToRouteResult)Controller.Edit(a);

			// assert
			Assert.AreEqual("Index", actual.RouteValues["action"]);
		}

		[TestMethod]
        public void EditSaveInvalid()
        {
            // arrange
            Controller.ModelState.AddModelError("key", "error message");

            Event events = new Event
            {
                 eventID = 4,
                 Name = "event 4",
                 Description = "kdc",
				  Participation_Percent=56
            };

            // act - cast the return type as ViewResult
            ViewResult actual = (ViewResult)Controller.Edit(events);

            // assert
            Assert.AreEqual("Edit", actual.ViewName);
           
        }

	}
}


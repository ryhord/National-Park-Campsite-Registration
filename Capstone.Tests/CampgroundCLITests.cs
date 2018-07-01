using System;
using System.Collections.Generic;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class CampgroundCLI_Tests
	{


		[TestMethod]
		public void IsCampgroundOpen_Test()
		{
			List<Campground> campgrounds = new List<Campground>();
			CampgroundCLI cli = new CampgroundCLI();

			Campground cg = new Campground();
			cg.CampgroundId = 1;
			cg.ParkId = 1;
			cg.Name = "Blue Stone";
			cg.OpenFrom = 3;
			cg.OpenTo = 10;
			cg.DailyFee = 5.00M;
			campgrounds.Add(cg);

			string fromDate = "2018-06-20";
			string toDate = "2018-06-25";
			int userChoice = 1;

			bool isOpen = cli.IsCampgroundOpen(fromDate, toDate, userChoice, campgrounds);

			Assert.IsTrue(isOpen);
		}

		[TestMethod]
		public void SearchForAvailableReservationsWithinCampground_Test()
		{

		}

		[TestMethod]
		public void CheckDateDays_Test()
		{

			CampgroundCLI cli = new CampgroundCLI();

			string stringFromDate = "2018-06-20";
			string stringToDate = "2018-06-25";

			int numberOfDays = cli.CheckDateDays(stringFromDate, stringToDate);

			Assert.AreEqual(5, numberOfDays);
		}

		[TestMethod]
		public void BookReservation()
		{ }

	}
}

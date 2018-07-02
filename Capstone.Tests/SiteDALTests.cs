using System;
using System.Collections.Generic;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class SiteDALTests : CampgroundDBTests
	{
		private SiteDAL dal = new SiteDAL(ConnectionString);

		[TestMethod]
		public void GetAvailableSitesByCampground_Test()
		{

			int campgroundId = 1;
			string fromDate = "2018-08-10";
			string toDate = "2018-08-15";
			int numOfDays = 5;
			List<Site> availableSites = dal.GetAvailableSitesByCampground(campgroundId, fromDate, toDate, numOfDays);
			// expected 1 result
			int actualAvailableSites = availableSites.Count;
			int expectedAvailableSites = 2;
			Assert.AreEqual(expectedAvailableSites, actualAvailableSites);
		}
	}
}

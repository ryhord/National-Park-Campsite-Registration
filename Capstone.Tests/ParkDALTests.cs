using System;
using System.Collections.Generic;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class ParkDALTests : CampgroundDBTests
	{
		private ParkDAL dal = new ParkDAL(ConnectionString);

		[TestMethod]
		public void GetAllParks_Test()
		{
			List<Park> parks = new List<Park>(dal.GetAllParks());

			Assert.AreEqual(2, parks.Count);
		}
	}
}

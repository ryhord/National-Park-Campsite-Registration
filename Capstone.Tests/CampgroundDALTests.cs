using System;
using System.Collections.Generic;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class CampgroundDALTests : CampgroundDBTests
	{
		private CampgroundDAL dal = new CampgroundDAL(ConnectionString);

		[DataTestMethod]
		[DataRow(1, 1)]
		[DataRow(2, 2)]
		public void GetCampgrounds_Test(int id, int expectedResult)
		{
			List<Campground> campgrounds = new List<Campground>(dal.GetAllCampgrounds(id));

			Assert.AreEqual(expectedResult, campgrounds.Count);
		}
	}
}

using System;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class ReservationDAL_Tests : CampgroundDBTests
	{

		private ReservationDAL dal = new ReservationDAL(ConnectionString);

		[TestMethod]
		public void CreateReservation_Test()
		{
			Reservation res = new Reservation();
			res.ReservationId = 60;
			res.SiteId = 6;
			res.Name = "Ryan";
			res.FromDate = Convert.ToDateTime("2019-06-20");
			res.ToDate = Convert.ToDateTime("2019-06-23");

			Assert.AreEqual(60, dal.CreateReservation(res));



		}
	}
}

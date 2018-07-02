using System;
using System.Data.SqlClient;
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
			res.SiteId = 6;
			res.Name = "Ryan";
			res.FromDate = Convert.ToDateTime("2019-06-20");
			res.ToDate = Convert.ToDateTime("2019-06-23");

			int initialNumberOfReservations = 0;
			int finalNumberOfReservations = 0;

			try
			{
				// Create a connection
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();

					SqlCommand check = new SqlCommand("SELECT COUNT(reservation_id) AS numOfReservations FROM reservation " +
						"WHERE ((reservation.from_date BETWEEN @fromDate AND @toDate) " +
						"OR (reservation.to_date BETWEEN @fromDate AND @toDate)) " +
						"AND site_id = @site_id " +
						"GROUP BY reservation_id;", conn);
					check.Parameters.AddWithValue("@fromDate", res.FromDate);
					check.Parameters.AddWithValue("@toDate", res.ToDate);
					check.Parameters.AddWithValue("@site_id", res.SiteId);

					SqlDataReader reader = check.ExecuteReader();

					while (reader.Read())
					{
						initialNumberOfReservations = Convert.ToInt32(reader["numOfReservations"]);
					}


					reader.Close();
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}


			dal.CreateReservation(res);

			try
			{
				// Create a connection
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();

					SqlCommand check = new SqlCommand("SELECT COUNT(reservation_id) AS numOfReservations FROM reservation " +
						"WHERE ((reservation.from_date BETWEEN @fromDate AND @toDate) " +
						"OR (reservation.to_date BETWEEN @fromDate AND @toDate)) " +
						"AND site_id = @site_id " +
						"GROUP BY reservation_id;", conn);
					check.Parameters.AddWithValue("@fromDate", res.FromDate);
					check.Parameters.AddWithValue("@toDate", res.ToDate);
					check.Parameters.AddWithValue("@site_id", res.SiteId);

					SqlDataReader reader = check.ExecuteReader();

					while (reader.Read())
					{
						finalNumberOfReservations = Convert.ToInt32(reader["numOfReservations"]);
					}


					reader.Close();
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}

			Assert.AreEqual((initialNumberOfReservations + 1), finalNumberOfReservations);
		}

	}
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
	public class ReservationDAL
	{
		private readonly string connectionString;

		public ReservationDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		public int CreateReservation(Reservation newReservation)
		{
			int rowsAffected = 0;
			int	reservationId = 0;

			try
			{
				// Create a connection
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand check = new SqlCommand("SELECT COUNT(reservation_id) AS numOfReservations FROM reservation " +
						"WHERE ((reservation.from_date BETWEEN @fromDate AND @toDate) " +
						"OR (reservation.to_date BETWEEN @fromDate AND @toDate)) " +
						"AND site_id = @site_id " +
						"GROUP BY reservation_id;", conn);
					check.Parameters.AddWithValue("@fromDate", newReservation.FromDate);
					check.Parameters.AddWithValue("@toDate", newReservation.ToDate);
					check.Parameters.AddWithValue("@site_id", newReservation.SiteId);

					SqlDataReader reader = check.ExecuteReader();

					while (reader.Read())
					{
						if (Convert.ToInt32(reader["numOfReservations"]) > 0)
						{
							return rowsAffected;
						}
					}
					reader.Close();

					SqlCommand cmd = new SqlCommand("INSERT INTO reservation(site_id, name, from_date, to_date) VALUES(@site_id, @name, @fromdate, @todate);", conn);
					cmd.Parameters.AddWithValue("@site_id", newReservation.SiteId);
					cmd.Parameters.AddWithValue("@name", newReservation.Name);
					cmd.Parameters.AddWithValue("@fromDate", newReservation.FromDate);
					cmd.Parameters.AddWithValue("@toDate", newReservation.ToDate);

					// Execute the command
					rowsAffected = cmd.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						SqlCommand cmd2 = new SqlCommand("SELECT reservation_id FROM reservation WHERE name = @name AND site_id = @site_id;", conn);
						cmd2.Parameters.AddWithValue("@name", newReservation.Name);
						cmd2.Parameters.AddWithValue("@site_id", newReservation.SiteId);

						SqlDataReader reader2 = cmd2.ExecuteReader();

						while (reader2.Read())
						{
							reservationId = Convert.ToInt32(reader2["reservation_id"]);
						}
						return reservationId;
					}
					else
					{
						return rowsAffected;
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return rowsAffected;
		}
	}
}

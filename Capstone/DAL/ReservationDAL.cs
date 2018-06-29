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

					SqlCommand cmd = new SqlCommand("INSERT INTO reservation(site_id, name, from_date, to_date) VALUES(@site_id, @name, @fromdate, @todate);", conn);
					cmd.Parameters.AddWithValue("@name", newReservation.Name);
					cmd.Parameters.AddWithValue("@fromDate", newReservation.FromDate);
					cmd.Parameters.AddWithValue("@toDate", newReservation.ToDate);

					// Execute the command
					rowsAffected = cmd.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						SqlCommand cmd2 = new SqlCommand("SELECT reservation.reservation_id FROM reservation WHERE reservation.name = @name;", conn);

						SqlDataReader reader = cmd2.ExecuteReader();

						reservationId = Convert.ToInt32(reader["reservation_id"]);
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

				Console.WriteLine(ex.Message); ;
			}

			return rowsAffected;
		}
	}
}

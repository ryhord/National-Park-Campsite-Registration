using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

//namespace Capstone.DAL
//{
//	public class ReservationDAL
//	{
//		private readonly string connectionString;

//		public ReservationDAL(string databaseConnectionString)
//		{
//			connectionString = databaseConnectionString;
//		}

//		//public List<Reservation> GetReservationsByCampground(int id)
//		//{
//		//	List<Reservation> reservations = new List<Reservation>();
//		//	try
//		//	{
//		//		using (SqlConnection conn = new SqlConnection(connectionString))
//		//		{
//		//			conn.Open();

//		//			SqlCommand cmd = new SqlCommand($"SELECT * FROM reservation WHERE site_id = {id};", conn);

//		//			SqlDataReader reader = cmd.ExecuteReader();

//		//			// Loop through each row
//		//			while (reader.Read())
//		//			{
//		//				// Create a Park
//		//				Reservation reservation = new Reservation();
//		//				reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
//		//				reservation.Name = Convert.ToString(reader["name"]);
//		//				reservation.Location = Convert.ToString(reader["location"]);
//		//				reservation.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
//		//				reservation.Area = Convert.ToInt32(reader["area"]);
//		//				reservation.Visitors = Convert.ToInt32(reader["visitors"]);
//		//				reservation.Description = Convert.ToString(reader["description"]);

//		//				parks.Add(park);
//		//			}
//		//		}
//		//	}
//		//	catch (SqlException ex)
//		//	{

//		//		Console.WriteLine(ex.Message);
//		//	}

//		//	return parks;
//		//}
//	}
//	}
//}


//SELECT*
//FROM reservation
//WHERE(reservation.from_date between '2018-06-21' and '2018-06-23') OR(reservation.to_date between '2018-06-21' and '2018-06-23');

//SELECT site.*
//FROM site
//INNER JOIN reservation ON site.site_id = reservation.site_id
//WHERE NOT EXISTS (SELECT*
//FROM reservation
//WHERE (reservation.from_date between '2018-06-21' and '2018-06-23') OR(reservation.to_date between '2018-06-21' and '2018-06-23'));

//SELECT*
//FROM site
//INNER JOIN campground ON site.campground_id = campground.campground_id
//WHERE site.campground_id = '2'; -- AND campground.

//SELECT site.*
//FROM site
//WHERE NOT EXISTS (SELECT*
//FROM reservation
//WHERE (reservation.from_date between '2018-06-21' and '2018-06-23') OR(reservation.to_date between '2018-06-21' and '2018-06-23'));

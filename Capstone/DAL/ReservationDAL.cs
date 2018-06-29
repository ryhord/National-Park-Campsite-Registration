using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
	//public class ReservationDAL
	//{
	//	private readonly string connectionString;

	//	public ReservationDAL(string databaseConnectionString)
	//	{
	//		connectionString = databaseConnectionString;
	//	}

	//	public int CreateReservation()
	//	{
	//		int reservationId = 0;
	//		try
	//		{
	//			// Create a connection
	//			using (SqlConnection conn = new SqlConnection(connectionString))
	//			{
	//				conn.Open();

	//				SqlCommand cmd = new SqlCommand("INSERT INTO reservation(name) VALUES(@name);", conn);
	//				cmd.Parameters.AddWithValue("@name", newDepartment.Name);

	//				// Execute the command
	//				rowsAffected = cmd.ExecuteNonQuery();

	//			}
	//		}
	//		catch (SqlException ex)
	//		{

	//			Console.WriteLine(ex.Message); ;
	//		}
	//		return rowsAffected;
	//	}
	//}
}

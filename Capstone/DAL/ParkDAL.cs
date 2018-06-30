using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
	public class ParkDAL
	{
		private readonly string connectionString;

		public ParkDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		public List<Park> GetAllParks()
		{
			List<Park> parks = new List<Park>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand("SELECT * FROM park ORDER BY name;", conn);

					SqlDataReader reader = cmd.ExecuteReader();

					// Loop through each row
					while (reader.Read())
					{
						// Create a Park
						Park park = new Park();
						park.ParkId = Convert.ToInt32(reader["park_id"]);
						park.Name = Convert.ToString(reader["name"]);
						park.Location = Convert.ToString(reader["location"]);
						park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
						park.Area = Convert.ToInt32(reader["area"]);
						park.Visitors = Convert.ToInt32(reader["visitors"]);
						park.Description = Convert.ToString(reader["description"]);

						parks.Add(park);
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return parks;
		}

		public Park GetParkById(int parkId)
		{
			Park park = new Park();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand($"SELECT * FROM park WHERE park_id = {parkId};", conn);

					SqlDataReader reader = cmd.ExecuteReader();

					// Loop through each row
					while (reader.Read())
					{
						// Create a Park
						park.ParkId = Convert.ToInt32(reader["park_id"]);
						park.Name = Convert.ToString(reader["name"]);
						park.Location = Convert.ToString(reader["location"]);
						park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
						park.Area = Convert.ToInt32(reader["area"]);
						park.Visitors = Convert.ToInt32(reader["visitors"]);
						park.Description = Convert.ToString(reader["description"]);
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return park;
		}
	}
}

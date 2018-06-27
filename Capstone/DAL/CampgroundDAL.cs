using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
	public class CampgroundDAL
	{
		private readonly string connectionString;

		public CampgroundDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		public List<Object> GetAllCampgrounds(int id)
		{
			List<Object> campgrounds = new List<Object>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand($"SELECT * FROM campground WHERE park_id = {id};", conn);

					SqlDataReader reader = cmd.ExecuteReader();

					// Loop through each row
					while (reader.Read())
					{
						// Create a Park
						Campground cg = new Campground();
						cg.CampgroundId = Convert.ToInt32(reader["campground_id"]);
						cg.ParkId = Convert.ToInt32(reader["park_id"]);
						cg.Name = Convert.ToString(reader["name"]);
						cg.OpenFrom = Convert.ToInt32(reader["open_from_mm"]);
						cg.OpenTo = Convert.ToInt32(reader["open_to_mm"]);
						cg.DailyFee = Convert.ToDecimal(reader["daily_fee"]);

						campgrounds.Add(cg);
					}
				}
			}
			catch (SqlException ex)
			{

				Console.WriteLine(ex.Message);
			}

			return campgrounds;
		}
	}
}

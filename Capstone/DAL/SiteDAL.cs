using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
	public class SiteDAL
	{
		private readonly string connectionString;

		public SiteDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		public List<Object> GetAvailableSitesByCampground(int id, string fromDate, string toDate)
		{
			List<Object> availableSites = new List<Object>();
			//try
			//{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand($"SELECT * FROM site " +
						$"WHERE site.campground_id = {id} " +
						$"AND site.site_id NOT IN " +
						$"(SELECT site.site_id FROM reservation " +
						$"INNER JOIN site ON reservation.site_id = site.site_id " +
						$"INNER JOIN campground ON site.campground_id = campground.campground_id WHERE campground.campground_id = {id} " +
						$"AND ((reservation.from_date between '{fromDate}' and '{toDate}') " +
						$"OR(reservation.to_date between '{fromDate}' and '{toDate}')));", conn);

					SqlDataReader reader = cmd.ExecuteReader();

					// Loop through each row
					while (reader.Read())
					{
						// Create a Park
						Site site = new Site();
						site.SiteId = Convert.ToInt32(reader["site_id"]);
						site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
						site.SiteNumber = Convert.ToInt32(reader["site_number"]);
						site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
						site.IsAccessible = Convert.ToBoolean(reader["accessible"]);
						site.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
						site.HasUtilities = Convert.ToBoolean(reader["utilities"]);

						availableSites.Add(site);
					}
				}
			//}
			//catch (SqlException ex)
			//{

			//	Console.WriteLine(ex.Message);
			//}

			return availableSites;
		}
	}
}

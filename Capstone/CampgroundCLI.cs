using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
	public class CampgroundCLI
	{
		const string DatabaseConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Campground;Integrated Security=True";

		public void RunProgram()
		{
			List<Park> parks = GetAllParks();
			Console.WriteLine("Q) Quit");
			Console.WriteLine();
			Console.Write("Please make a selection: ");
			string input = Console.ReadLine().ToLower();

			if (input == "q")
			{
				return;
			}
			else
			{
				try
				{
					GetParkInfo(parks[int.Parse(input) - 1].ParkId);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Idiot");
				}

			}

		}

		public void GetParkInfo(int parkId)
		{
			ParkDAL dal = new ParkDAL(DatabaseConnectionString);

			Console.WriteLine($"{dal.GetParkById(parkId)}");
		}

		public List<Park> GetAllParks()
		{
			ParkDAL dal = new ParkDAL(DatabaseConnectionString);

			List<Park> parks = dal.GetAllParks();

			Console.WriteLine("Select a park for further details");
			for (int i = 1; i <= parks.Count; i++)
			{
				Console.WriteLine($"{i}) {parks[i - 1].Name}");
			}

			return parks;
		}

		//public void GetAllCampgrounds()
		//{
		//	CampgroundDAL dal = new CampgroundDAL(DatabaseConnectionString);

		//	List<Campground> campgrounds = dal.GetAllCampgrounds();

		//	Console.WriteLine();
		//	Console.WriteLine("Here are all the available campgrounds");
		//	foreach (Campground cg in campgrounds)
		//	{
		//		Console.WriteLine(cg);
		//	}
		//}
	}
}

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
			List<Object> campgrounds = new List<Object>();
			Console.WriteLine("Q) Quit");
			Console.WriteLine();
			Console.Write("Please make a selection: ");
			string input = Console.ReadLine().ToLower();

			int selectedParkID = parks[int.Parse(input) - 1].ParkId;

			if (input == "q")
			{
				return;
			}
			else
			{
				try
				{
					
					GetParkInfo(selectedParkID);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Idiot");
				}
			}
			int parkInfoSubmenuChoice = ParkInfoSubmenu();
			int campgroundInfoSubmenuChoice = 0;
			switch (parkInfoSubmenuChoice)
			{
				case 1:
					campgrounds = CampgroundsInSelectedPark(selectedParkID);
					PrintAllListItems(campgrounds);
					campgroundInfoSubmenuChoice = CampgroundInfoSubmenu();
					break;
				case 2:
					break;
				case 3:
					break;
			}

		}


		public void GetParkInfo(int parkId)
		{
			ParkDAL dal = new ParkDAL(DatabaseConnectionString);


			Console.WriteLine($"{dal.GetParkById(parkId)}");
		}

		public int ParkInfoSubmenu()
		{
			Console.WriteLine("Select a Command ");
			Console.WriteLine("1) View Campgrounds");
			Console.WriteLine("2) Search for Reservation");
			Console.WriteLine("3) Return to Previous Screen");
			Console.Write("> ");
			int choice = int.Parse(Console.ReadLine());
			return choice;
		}

		public List<Object> CampgroundsInSelectedPark(int parkId)
		{
			CampgroundDAL dal = new CampgroundDAL(DatabaseConnectionString);
			List<Object> campgrounds = dal.GetAllCampgrounds(parkId);

			return campgrounds;
		}

		public int CampgroundInfoSubmenu()
		{
			Console.WriteLine("Select a Command ");
			Console.WriteLine("1) Search for available reservation");
			Console.WriteLine("2) Return to Previous Screen");
			Console.Write("> ");
			int choice = int.Parse(Console.ReadLine());
			return choice;
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

		public void PrintAllListItems(List<Object> list)
		{
			for (int i = 1; i <= list.Count; i++)
			{
				Console.WriteLine($"{i}) {list[i - 1].ToString()}"); 

			}
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

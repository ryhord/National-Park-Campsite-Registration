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

		List<Campground> campgrounds = new List<Campground>();
		List<Object> parks = new List<Object>();

		public void RunProgram()
		{
			List<Park> parks = GetAllParks();
			
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

			while (true)
			{
				int parkInfoSubmenuChoice = ParkInfoSubmenu();
				int campgroundInfoSubmenuChoice = 0;
				switch (parkInfoSubmenuChoice)
				{
					case 1:
						CampgroundsInSelectedPark(selectedParkID);
						PrintAllCampgrounds(campgrounds);
						campgroundInfoSubmenuChoice = CampgroundInfoSubmenu();

						switch (campgroundInfoSubmenuChoice)
						{
							case 1:
								Console.WriteLine("Which campground? (Enter 0 to cancel)");
								int campgroundChoice =  Convert.ToInt32(Console.ReadLine());
								Console.WriteLine("Enter the start date for your reservation.. (YYYY-MM-DD)");
								string fromDate = Console.ReadLine();
								Console.WriteLine("Enter the end date for your reservation.. (YYYY-MM-DD)");
								string toDate = Console.ReadLine();
								int campgroundId = campgrounds[campgroundChoice - 1].CampgroundId;
								List<Object> availableSites = GetAvailableSitesByCampGround(campgroundId, fromDate, toDate);
								PrintAllListItems(availableSites);
								break;
							case 2:
								break;
						}
						break;

					case 2:
						break;
					case 3:
						break;
				}
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

		public void CampgroundsInSelectedPark(int parkId)
		{
			CampgroundDAL dal = new CampgroundDAL(DatabaseConnectionString);
			campgrounds = dal.GetAllCampgrounds(parkId);

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

		public List<Object> GetAvailableSitesByCampGround(int campgroundId, string fromDate, string toDate)
		{
			SiteDAL dal = new SiteDAL(DatabaseConnectionString);

			List<Object> availableSites = dal.GetAvailableSitesByCampground(campgroundId, fromDate, toDate);

			return availableSites;
		}

		public void PrintAllListItems(List<Object> list)
		{
			for (int i = 1; i <= list.Count; i++)
			{
				Console.WriteLine($"{i}) {list[i - 1].ToString()}"); 

			}
		}

		public void PrintAllCampgrounds(List<Campground> list)
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

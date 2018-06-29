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
		List<Site> availableSites = new List<Site>();

		public void RunProgram()
		{
			while (true)
			{
				bool isRunningSubmenu = true;
				int selectedParkID = 0;
				Console.WriteLine("Select a park for further details");
				List<Park> parks = GetAllParks();
				Console.WriteLine("Q) Quit");
				Console.WriteLine();
				Console.Write("Please make a selection: ");
				string input = Console.ReadLine().ToLower();

				// SelectingParkToGetInfoAbout
				switch (input)
				{
					case "q":
						return;
					case "1":
					case "2":
					case "3":
						Console.Clear();
						selectedParkID = parks[int.Parse(input) - 1].ParkId;
						GetParkInfo(selectedParkID);
						Console.WriteLine("");
						break;
					default:
						Console.Clear();
						Console.WriteLine("The command provided was not a valid command, please try again.");
						Console.WriteLine("");
						break;
				}

				// selectedParkID used to get relevant submenu
				while (isRunningSubmenu)
				{
					int parkInfoSubmenuChoice = ParkInfoSubmenu();
					int campgroundInfoSubmenuChoice = 0;
					switch (parkInfoSubmenuChoice)
					{

						// viewing campgrounds in the selectedParkId
						case 1:
							Console.Clear();
							CampgroundsInSelectedPark(selectedParkID);
							PrintAllListItems(campgrounds.ToArray());
							Console.WriteLine();

							campgroundInfoSubmenuChoice = CampgroundInfoSubmenu();
							switch (campgroundInfoSubmenuChoice)
							{
								// Searching For Avilable Reservations within the campground of choice
								case 1:
									SearchForAvailableReservationsWithinCampground();
									break;

								// return to previousScreen
								case 2:
									break;
							}
							break;

						// Search for Reservation from the first Menu
						case 2:
							// DOESNT DO ANYTHING YET. TALK ABOUT HOW AND WHERE TO SEARCH
							Console.WriteLine("What is the name the reservation is under?");
							string name = Console.ReadLine();
							SearchForReservation(name);
							Console.WriteLine("");
							campgroundInfoSubmenuChoice = CampgroundInfoSubmenu();
							break;

						case 3:
							isRunningSubmenu = false;
							break;
					}
				}
			}
		}

		private bool IsCampgroundOpen(string fromDate, string toDate, int campgroundChoice)
		{
			int campgroundOpenFromMonth = campgrounds[campgroundChoice - 1].OpenFrom;
			int campgroundOpenToMonth = campgrounds[campgroundChoice - 1].OpenTo;

			string[] fromDateValues = fromDate.Split('-');
			string[] toDateValues = toDate.Split('-');

			int fromMonthNumber = Convert.ToInt32(fromDateValues[1]);
			int toMonthNumber = Convert.ToInt32(toDateValues[1]);

			if (fromMonthNumber < campgroundOpenFromMonth ||
				fromMonthNumber > campgroundOpenToMonth ||
				toMonthNumber > campgroundOpenToMonth ||
				toMonthNumber < campgroundOpenFromMonth)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		private void SearchForAvailableReservationsWithinCampground()
		{
			while (true)
			{
				Console.WriteLine("Which campground? (Enter 0 to cancel)");
				int campgroundChoice = Convert.ToInt32(Console.ReadLine());

				if (campgroundChoice == 0)
				{
					break;
				}
				if (campgroundChoice > campgrounds.Count)
				{
					Console.WriteLine("The number you entered is not associated with a campsite.");
					break;
				}

				Console.WriteLine("Enter the start date for your reservation: (YYYY-MM-DD)");
				string fromDate = Console.ReadLine();

				Console.WriteLine("Enter the end date for your reservation: (YYYY-MM-DD)");
				string toDate = Console.ReadLine();
				int numberOfDaysBooked = CheckDateDays(fromDate, toDate);

				if (!IsCampgroundOpen(fromDate, toDate, campgroundChoice))
				{
					Console.WriteLine("This campground is not open for all of the days listed in your stay");
					break;
				}

				if (numberOfDaysBooked < 0)
				{
					Console.Clear();
					Console.WriteLine("Your start date cannot come after your end date");
					Console.WriteLine();
					break;
				}

				int campgroundId = campgrounds[campgroundChoice - 1].CampgroundId;
				GetAvailableSitesByCampGround(campgroundId, fromDate, toDate, numberOfDaysBooked);

				if (availableSites.Count == 0)
				{
					Console.WriteLine("There are no sites available during this date range.");
					Console.Write("Would you like to try again? Y/N > ");
					string userInput = Console.ReadLine().ToUpper();
					if (userInput == "Y" || userInput == "N")
					{
						if (userInput == "N")
						{
							break;
						}
					}
					else
					{
						Console.WriteLine("Idiot");
					}
				}
				else
				{
					Console.WriteLine("Results matching your search criteria");
					Console.WriteLine("Site Id".PadRight(10) + "Max Occupancy".PadRight(15) +
						"Wheelchair Access?".PadRight(20) + "Max RV Length".PadRight(18) + "Utilities".PadRight(15) +
						"Total Cost");
					PrintAllListItems(availableSites.ToArray());
					BookReservation(fromDate, toDate);

					break;
				}
			}
		}

		private void SearchForReservation(string name)
		{
			throw new NotImplementedException();
		}

		public void BookReservation(string fromDate, string toDate)
		{
			Reservation reservation = new Reservation();
			bool isListedSite = false;

			ReservationDAL dal = new ReservationDAL(DatabaseConnectionString);

			Console.WriteLine("Enter the site number that should be reserved? (Enter 0 to cancel)");
			int siteIdForReservation = Convert.ToInt32(Console.ReadLine());

			foreach (Site site in availableSites)
			{
				if (site.SiteId == siteIdForReservation)
				{
					Console.WriteLine("What name should the reservation be made under?");
					string name = Console.ReadLine();

					reservation.SiteId = siteIdForReservation;
					reservation.Name = name;
					reservation.FromDate = Convert.ToDateTime(fromDate);
					reservation.ToDate = Convert.ToDateTime(toDate);

					int reservationId = dal.CreateReservation(reservation);

					if (reservationId == 0)
					{
						Console.WriteLine("Failed to complete reservation.");
					}
					else
					{
						Console.WriteLine($"Your reservation is complete.  Reservation id is {reservationId}.");
					}

					isListedSite = true;
					break;
				}
	
			}
			if (!isListedSite)
			{
				Console.WriteLine($"Site {siteIdForReservation} is not an available selection.");
			}
		}

		public int CheckDateDays(string stringFromDate, string stringToDate)
		{
			DateTime fromDate;
			DateTime.TryParse(stringFromDate, out fromDate);
			DateTime toDate;
			DateTime.TryParse(stringToDate, out toDate);
			return (toDate - fromDate).Days;
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
			Console.WriteLine("3) Return to Park Selection Screen");
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

			for (int i = 1; i <= parks.Count; i++)
			{
				Console.WriteLine($"{i}) {parks[i - 1].Name}");
			}

			return parks;
		}

		public void GetAvailableSitesByCampGround(int campgroundId, string fromDate, string toDate, int numberOfDaysBooked)
		{
			SiteDAL dal = new SiteDAL(DatabaseConnectionString);

			availableSites = dal.GetAvailableSitesByCampground(campgroundId, fromDate, toDate, numberOfDaysBooked);
		}

		public void PrintAllListItems(Object[] array)
		{
			for (int i = 1; i <= array.Length; i++)
			{
				Console.WriteLine($"{i}) {array[i - 1].ToString()}");
			}
		}
	}
}

﻿using System;
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

				switch (input)
				{
					case "q":
						return;
					case "1":
					case "2":
					case "3":
						selectedParkID = parks[int.Parse(input) - 1].ParkId;
						GetParkInfo(selectedParkID);
						break;
					default:
						Console.Clear();
						Console.WriteLine("The command provided was not a valid command, please try again.");
						Console.WriteLine("");
						break;
				}


				while (isRunningSubmenu)
				{
					int parkInfoSubmenuChoice = ParkInfoSubmenu();
					int campgroundInfoSubmenuChoice = 0;
					switch (parkInfoSubmenuChoice)
					{
						case 1:
							CampgroundsInSelectedPark(selectedParkID);
							PrintAllListItems(campgrounds.ToArray());
							campgroundInfoSubmenuChoice = CampgroundInfoSubmenu();

							switch (campgroundInfoSubmenuChoice)
							{
								case 1:
									while (true)
									{
										Console.WriteLine("Which campground? (Enter 0 to cancel)");
										int campgroundChoice = Convert.ToInt32(Console.ReadLine());

										if (campgroundChoice == 0)
										{
											break;
										}

										Console.WriteLine("Enter the start date for your reservation: (YYYY-MM-DD)");
										string fromDate = Console.ReadLine();

										Console.WriteLine("Enter the end date for your reservation: (YYYY-MM-DD)");
										string toDate = Console.ReadLine();
										int numberOfDaysBooked = CheckDateDays(fromDate, toDate);

										if(numberOfDaysBooked < 0)
										{
											Console.WriteLine("Your start date cannot come after your end date");
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
											PrintAllListItems(availableSites.ToArray());
											break;
										}
									}
									break;

								case 2:
									break;
							}

							break;

						case 2:

							break;

						case 3:
							isRunningSubmenu = false;
							break;
					}
				}
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

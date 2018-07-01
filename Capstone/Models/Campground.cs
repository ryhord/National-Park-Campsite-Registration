using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
	public class Campground
	{
		public int CampgroundId { get; set; }
		public int ParkId { get; set; }
		public string Name { get; set; }
		public int OpenFrom { get; set; }
		public int OpenTo { get; set; }
		public decimal DailyFee { get; set; }

		public override string ToString()
		{
			string openFromMonth = ToStringMonth(OpenFrom);
			string openToMonth = ToStringMonth(OpenTo);

			return Name.PadRight(35) + openFromMonth.PadRight(15) + openToMonth.PadRight(15) + DailyFee.ToString("C").PadLeft(10);
		}

		public string ToStringMonth(int monthInt)
		{
			string stringMonth = "";
			switch (monthInt)
			{
				case 1:
					stringMonth = "January";
					break;
				case 2:
					stringMonth = "February";
					break;
				case 3:
					stringMonth = "March";
					break;
				case 4:
					stringMonth = "April";
					break;
				case 5:
					stringMonth = "May";
					break;
				case 6:
					stringMonth = "June";
					break;
				case 7:
					stringMonth = "July";
					break;
				case 8:
					stringMonth = "August";
					break;
				case 9:
					stringMonth = "September";
					break;
				case 10:
					stringMonth = "October";
					break;
				case 11:
					stringMonth = "November";
					break;
				case 12:
					stringMonth = "December";
					break;
			}
			return stringMonth;

		}
	}
}

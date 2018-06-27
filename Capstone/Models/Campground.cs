﻿using System;
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
			return Name.PadRight(30) + OpenFrom.ToString().PadRight(10) + OpenTo.ToString().PadRight(10) + DailyFee.ToString("C").PadLeft(15);
		}
	}
}

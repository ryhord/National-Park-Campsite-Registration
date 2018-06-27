﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
	public class Park
	{
		public int ParkId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public DateTime EstablishDate { get; set; }
		public int Area { get; set; }
		public int Visitors { get; set; }
		public string Description { get; set; }

		public override string ToString()
		{
			return ParkId.ToString().PadRight(6) + Name.PadRight(30) + Location.PadRight(10) + EstablishDate.ToString().PadRight(10) + Area.ToString("N").PadLeft(15) + Visitors.ToString("N").PadLeft(15) + '\n' + Description.ToString();
		}
	}
}

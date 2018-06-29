using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
	public class Site
	{
		public int SiteId { get; set; }
		public int CampgroundId { get; set; }
		public int SiteNumber { get; set; }
		public int MaxOccupancy { get; set; }
		public bool IsAccessible { get; set; }
		public int MaxRvLength { get; set; }
		public bool HasUtilities { get; set; }
		public decimal TotalCost { get; set; }

		public override string ToString()
		{
			string output = $"{SiteId.ToString().PadRight(6)} {MaxOccupancy.ToString().PadRight(30)}";

			if (IsAccessible)
			{
				output += "Yes".PadRight(10);
			}
			else
			{
				output += "No".PadRight(10);
			}

			if (MaxRvLength == 0)
			{
				output += "N/A".PadRight(10);
			}
			else
			{
				output += MaxRvLength.ToString().PadRight(10);
			}

			if (HasUtilities)
			{
				output += "Yes".PadRight(10);
			}
			else
			{
				output += "N/A".PadRight(10);
			}

			output += $"{TotalCost.ToString("C").PadRight(10)}";

			return output;
		}
	}
}

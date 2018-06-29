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
			string output = $"{SiteId.ToString().PadRight(13)} {MaxOccupancy.ToString().PadRight(17)}";

			if (IsAccessible)
			{
				output += "Yes".PadRight(15);
			}
			else
			{
				output += "No".PadRight(15);
			}

			if (MaxRvLength == 0)
			{
				output += "N/A".PadRight(15);
			}
			else
			{
				output += MaxRvLength.ToString().PadRight(15);
			}

			if (HasUtilities)
			{
				output += "Yes".PadRight(17);
			}
			else
			{
				output += "N/A".PadRight(17);
			}

			output += $"{TotalCost.ToString("C").PadRight(15)}";

			return output;
		}
	}
}

using System;
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
			return Name + " National Park\n" + "Location:\t\t" + Location + "\n" +
				"Established:\t\t" + EstablishDate.ToString() + "\n" + "Area:\t\t\t" +
				Area.ToString("N") + "sq km\n" + "Annual Visitors:\t"
				+ Visitors.ToString("N").PadLeft(5)	+ '\n' + Description.ToString();
		}
	}
}

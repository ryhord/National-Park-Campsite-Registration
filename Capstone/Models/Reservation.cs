using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
	public class Reservation
	{
		public int ReservationId { get; set; }
		public int SiteId { get; set; }
		public string Name { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public DateTime CreateDate { get; set; }

		//public override string ToString()
		//{
		//	return SiteId.ToString().PadRight(6) + Name.PadRight(30) + Location.PadRight(10) + EstablishDate.ToString().PadRight(10) + Area.ToString("N").PadLeft(15) + Visitors.ToString("N").PadLeft(15) + '\n' + Description.ToString();
		//}
	}
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
	public class ReservationDAL
	{
		
	}
}


//SELECT*
//FROM reservation
//WHERE(reservation.from_date between '2018-06-21' and '2018-06-23') OR(reservation.to_date between '2018-06-21' and '2018-06-23');

//SELECT site.*
//FROM site
//INNER JOIN reservation ON site.site_id = reservation.site_id
//WHERE NOT EXISTS (SELECT*
//FROM reservation
//WHERE (reservation.from_date between '2018-06-21' and '2018-06-23') OR(reservation.to_date between '2018-06-21' and '2018-06-23'));

//SELECT*
//FROM site
//INNER JOIN campground ON site.campground_id = campground.campground_id
//WHERE site.campground_id = '2'; -- AND campground.

//SELECT site.*
//FROM site
//WHERE NOT EXISTS (SELECT*
//FROM reservation
//WHERE (reservation.from_date between '2018-06-21' and '2018-06-23') OR(reservation.to_date between '2018-06-21' and '2018-06-23'));

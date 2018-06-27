using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
			CampgroundCLI cli = new CampgroundCLI();
			cli.RunProgram();
			Console.WriteLine("Thank you for using our Campground Reservation System!");
        }
    }
}

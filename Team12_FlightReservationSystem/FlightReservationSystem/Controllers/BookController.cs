using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Controllers
{
    public class BookController : Controller
    {
        
        public IActionResult SearchResults(string searchTerm, string searchTerm1, string searchTerm2) {


            FlightDAO flights= new FlightDAO();
            List<Flight> flightList = flights.SerachFlights(searchTerm, searchTerm1, searchTerm2);
            if (flightList.Count == 0)
            {
                ViewBag.SearchResultMessage =
                    "Oops! No Flights are available for the selected criteria! Please try again after changing criteria";
                //return View("Search");
            }
            return View("SearchResults", flightList);
        
        
        }

        public IActionResult Search() {


            return View();
        }
        public IActionResult PassengerDetails()
        {
            return View();
        }
    }
}

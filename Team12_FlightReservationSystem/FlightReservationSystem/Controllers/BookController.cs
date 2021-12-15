using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(string flightId, string source, string dest, string depDate, string arrDate, int cost)
        {
            Passenger model = new Passenger();
            {
                model.ID = flightId;
            }
            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }

    }
}

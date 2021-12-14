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
        public IActionResult Index()
        {

            HardcodeDataRepository hardcodeDataRepository = new HardcodeDataRepository();

            FlightDAO flightDAO = new FlightDAO();

            return View(flightDAO.GetAllFlights());
        }

        public IActionResult SearchResults(string searchTerm) {


            FlightDAO flights= new FlightDAO();
            List<Flight> flightList = flights.SerachFlights(searchTerm);

            return View("index", flightList);
        
        
        }

        public IActionResult SearchForm() {


            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}

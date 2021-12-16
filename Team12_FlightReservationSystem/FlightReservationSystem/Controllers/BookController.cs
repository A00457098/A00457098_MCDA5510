using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;


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
        //[HttpPost]
        public IActionResult Details(string Id)
        {
            TempData["flightId"] = Id;
            return View();
        }

        [Authorize]
        public IActionResult ReviewBooking(Passenger passenger)
        {
            TempData["Passenger"] = passenger;
            return View();
        }

        public bool validateCard (string CardType, string CardNumber)
        {
         
            bool cardValid = false;

            if ((CardType == "visa" && CardNumber[0] == '4') || CardType == "mastercard" && CardNumber[0] == '5'
                || (CardType == "mastercard" && CardNumber[0] == '3'))
            {
                cardValid = true;
            }
            else
            {
                cardValid = false;
            }

            return (cardValid); 
        }

        public bool validateZIP(string Country, string ZIP)
        {
            Regex canRegex = new Regex(@"^[a-zA-Z]\d[a-zA-Z][-\s]\d[a-zA-Z]\d$");
            Regex usaRegex = new Regex(@"^\d{5}$|^\d{9}$|^\d{5}-\d{4}$");

            bool zipValid = false;

            if ((Country == "Other") || (Country == "Canada" && canRegex.IsMatch(ZIP)) || (Country == "USA" && usaRegex.IsMatch(ZIP)))
            {
                zipValid = true;
            }
            else
            {
                zipValid = false;
            }

            return (zipValid);
        }
        public IActionResult PaymentCheck(string FirstName, string LastName, string CardType, string CardNumber,
            int CVV, string CardExpiryMonth, string CardExpiryYear, string StreetName, int StreetNumber,
            int UnitNumber, string City, string Province, string Country, string ZIP)
        {

            bool cardValid = validateCard(CardType, CardNumber);
            bool zipValid = validateZIP(Country, ZIP);

            if (cardValid && zipValid)
            {
                return View("Search");
            }
            else
            {   
                if (cardValid == false)
                {
                    ModelState.AddModelError(nameof(Payment.CardNumber), "Invalid Card Number");
                }
                if (zipValid == false)
                {
                    ModelState.AddModelError(nameof(Payment.ZIP), "Invalid ZIP Code");
                }
                ModelState.AddModelError(nameof(Payment.CardNumber), "Invalid Card Number or Card Type");
                return View("Payment");
            }

        }

            
        }
            

    }


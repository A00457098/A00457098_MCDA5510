using System;
using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace FlightReservationSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _context;

        public BookController(ApplicationDBContext context)
        {
            _context = context;
        }
        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFG0123456789HIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public IActionResult SearchResults(string searchTerm, string searchTerm1, string searchTerm2)
        {


            FlightDAO flights = new FlightDAO();
            List<Flight> flightList = flights.SerachFlights(searchTerm, searchTerm1, searchTerm2);
            if (flightList.Count == 0)
            {
                ViewBag.SearchResultMessage =
                    "Oops! No Flights are available for the selected criteria! Please try again after changing criteria";
                //return View("Search");
            }
            return View("SearchResults", flightList);
        }

        public IActionResult Search()
        {
            return View();
        }

        [Authorize]
        //[HttpPost]
        public IActionResult PassengerDetails(string Id)
        {
            TempData["flightId"] = Id;
            return View();
        }
        [Authorize]
        public IActionResult ReviewBooking(Passenger passenger)
        {
            var flightId = TempData["flightId"];
            TempData.Keep("flightId");

            using (var context = _context)
            {
                var flight = context.Flight.Find(flightId);

                TempData["Flight"] = JsonConvert.SerializeObject(flight);
            }

            TempData["Passenger"] = JsonConvert.SerializeObject(passenger);
            return View();
        }

        [Authorize]
        public IActionResult Payment()
        {
            return View();
        }
        [Authorize]
        public IActionResult CompleteBooking(string FirstName, string LastName, string CardType, string CardNumber,
            int CVV, string CardExpiryMonth, string CardExpiryYear, string StreetName, int StreetNumber,
            int UnitNumber, string City, string Province, string Country, string ZIP)
        {

            bool cardValid = validateCard(CardType, CardNumber);
            bool zipValid = validateZIP(Country, ZIP);

            if (cardValid && zipValid)
            {
                Flight flight = JsonConvert.DeserializeObject<Flight>(TempData["Flight"].ToString());
                Passenger passenger = JsonConvert.DeserializeObject<Passenger>(TempData["Passenger"].ToString());
                BookingHistory booking = new BookingHistory
                {
                    UserId = User.Identity?.Name,
                    PNR_Number = RandomString(),
                    Flight_Name = flight.Flight_Name,
                    Departure_City = flight.Departure_City,
                    Arrival_City = flight.Arrival_City,
                    Departure_Date = flight.Departure_Date,
                    Arrival_Date = flight.Arrival_Date,
                    Price = flight.Price,

                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    Birth_Date = passenger.Birth_Date,
                    Email = passenger.Email,
                    Phone_Num = passenger.Phone_Num,
                    Gender = passenger.Gender
                };
                _context.BookingHistory.Add(booking);
                _context.SaveChanges();
                ViewBag.Pnr = booking.PNR_Number;
                return View("CompleteBooking");
            }
            else
            {
                if (cardValid == false)
                {
                    ModelState.AddModelError(nameof(Models.Payment.CardNumber), "Invalid Card Number");
                }
                if (zipValid == false)
                {
                    ModelState.AddModelError(nameof(Models.Payment.ZIP), "Invalid ZIP Code");
                }
                ModelState.AddModelError(nameof(Models.Payment.CardNumber), "Invalid Card Number or Card Type");
                return View("Payment");
            }

        }

        [Authorize]
        public IActionResult ManageBookings()
        {
            var bookingsLst = _context.BookingHistory.Where(x => x.UserId == User.Identity.Name);
            if (!bookingsLst.Any())
            {
                ViewBag.NoBookingsMsg = "You do not have any bookings yet!";
            }
            return View(bookingsLst);
        }
        [Authorize]
        //[HttpPost]
        public IActionResult CancelBooking(string Pnr)
        {
            var booking = _context.BookingHistory.Find(Pnr);
            _context.BookingHistory.Remove(booking);
            _context.SaveChanges();
            ViewBag.BookingCancelledMsg = $"Booking has been cancelled for PNR: {Pnr}";
            return RedirectToAction("ManageBookings");
        }

        public IActionResult LookupPnr()
        {
            return View();
        }
        public IActionResult ViewBookingByPnr(BookingHistory Pnr)
        {
            var booking = _context.BookingHistory.Find(Pnr.PNR_Number);
            if (booking != null)
            {
                return View(booking);
            }
            else
            {
                ViewBag.WrongPnr = "Sorry! This PNR Does not exist";
                return View("LookupPNR");
            }
        }
        private bool validateCard(string CardType, string CardNumber)
        {

            bool cardValid = false;

            if ((CardType == "visa" && CardNumber[0] == '4') || CardType == "mastercard" && CardNumber[0] == '5'
                                                             || (CardType == "amex" && CardNumber[0] == '3'))
            {
                cardValid = true;
            }
            else
            {
                cardValid = false;
            }

            return (cardValid);
        }

        private bool validateZIP(string Country, string ZIP)
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
    }
}


using FlightReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data
{
    public class HardcodeDataRepository : FlightDataService
    {
        public List<Flight> GetAllFlights()
        {
            List<Flight> flightList = new List<Flight>();

            flightList.Add(new Flight { ID = "A324", Flight_Name = "AC384", Departure_City = "Halifax", Arrival_City = "Toronto", Departure_Date = "2021-12-18", Price = 620 });
            flightList.Add(new Flight { ID = "A325", Flight_Name = "AC324", Departure_City = "Seoul", Arrival_City = "Toronto", Departure_Date = "2021-12-10", Price = 620 });
            flightList.Add(new Flight { ID = "A326", Flight_Name = "AC344", Departure_City = "Newyork", Arrival_City = "Toronto", Departure_Date = "2021-12-12", Price = 620 });


            return flightList;
        }

        public Flight GetFlightID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Flight> SerachFlights(string searchTerm,string searchTerm1, string searchTerm2)
        {
            throw new NotImplementedException();
        }
    }
}

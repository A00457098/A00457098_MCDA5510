using FlightReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data
{
    interface FlightDataService
    {

        List<Flight> GetAllFlights();
        List<Flight> SerachFlights(string searchTerm);

        Flight GetFlightID(int id);

    }
}

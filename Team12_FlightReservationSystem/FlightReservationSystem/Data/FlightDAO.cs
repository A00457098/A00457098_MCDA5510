using FlightReservationSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data
{
    public class FlightDAO : FlightDataService
    {
        string connectionString = @"Data Source=dev.cs.smu.ca;Database=j_shinn;User ID=j_shinn;Password=A00407059!cda;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Flight> GetAllFlights()
        {
            List<Flight> foundFlights = new List<Flight>();

            string sqlStatement = "SELECT * FROM dbo.flight";

            using (SqlConnection connection = new SqlConnection(connectionString)) { // You can talk to DB in this curly brakets

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundFlights.Add(new Flight { ID = (string)reader[0], Flight_Name = (string)reader[1], Departure_City = (string)reader[2], Arrival_City = (string)reader[3], Departure_Date = (string)reader[4], Arrival_Date = (string)reader[5], Price = (int)reader[6] });
                    }

                }
                catch (Exception ex) 
                {

                    Console.WriteLine(ex.Message);

                }
            
            
            }

            return foundFlights;
        }

        public Flight GetFlightID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Flight> SerachFlights(string searchTerm)
        {
            List<Flight> foundFlights = new List<Flight>();

            string sqlStatement = "SELECT * FROM dbo.flight WHERE Arrival_City LIKE @Arrival_City";

            using (SqlConnection connection = new SqlConnection(connectionString))
            { // You can talk to DB in this curly brakets

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Arrival_City", '%' + searchTerm + '%');

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundFlights.Add(new Flight { ID = (string)reader[0], Flight_Name = (string)reader[1], Departure_City = (string)reader[2], Arrival_City = (string)reader[3], Departure_Date = (string)reader[4], Arrival_Date = (string)reader[5], Price = (int)reader[6] });
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }


            }

            return foundFlights;
        }
    }
}

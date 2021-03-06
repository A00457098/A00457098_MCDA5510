using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
        
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<BookingHistory> BookingHistory { get; set; }
    }
}

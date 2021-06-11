using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketBooking.Models;

namespace TicketBooking.DAL
{
    public class BookingContext : DbContext
    {
        public BookingContext() : base("BookingContext")
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FlightTravel> FlightTravels { get; set; }

        public DbSet<BookingRate> BookingRates { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
     
}
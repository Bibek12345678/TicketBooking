using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data.Entity;
=======
>>>>>>> 6fa131fbf2c176685444fdff46873adfa3ea511a
using System.Linq;
using System.Web;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.ViewModel;

namespace TicketBooking.Repository
{
<<<<<<< HEAD
    public class FlightTravelRepository : IFlighttravelRepository
    {
        private readonly BookingContext _context;
        public FlightTravelRepository(BookingContext context)
        {
            _context = context;
        }

        public int AddFlightTravel(FlightTravel flightTravelEntity)
        {
            using (var context = new BookingContext())
            {
                FlightTravel flight = new FlightTravel()
                {
                    FromLocation = flightTravelEntity.FromLocation,
                    ToLocation = flightTravelEntity.ToLocation
=======
    public class FlightTravelRepository
    {
        public int Create(FlightTravel model)
        {
            using(var context=new BookingContext())
            {
                FlightTravel flight = new FlightTravel()
                {
                    FromLocation = model.FromLocation,
                    ToLocation = model.ToLocation
>>>>>>> 6fa131fbf2c176685444fdff46873adfa3ea511a
                };
                context.FlightTravels.Add(flight);
                context.SaveChanges();
                return flight.ID;
            }
        }
<<<<<<< HEAD

        public void DeleteFlightTravel(int ID)
        {
            FlightTravel flightTravelEntity = _context.FlightTravels.Find(ID);
            _context.FlightTravels.Remove(flightTravelEntity);
            _context.SaveChanges();
        }
        public FlightTravel GetFlightTravelById(int ID)
        {
            return _context.FlightTravels.Find(ID);
        }

        public int UpdateFlightTravel(FlightTravel flightTravelEntity)
        {
            int result = -1;
            if(flightTravelEntity != null)
            {
                _context.Entry(flightTravelEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = flightTravelEntity.ID;

            }
            return result;
        }

       public IEnumerable<FlightTravelGridViewModel> GetAllFlightTravel()
        {
            {
                var location = _context.Locations.ToList();
                var result = (from c in _context.FlightTravels.ToList()
=======
        public List<FlightTravel> GetFlights()
        {
            using(var context=new BookingContext())
            {
                var location = context.Locations.ToList();
                var result = (from c in context.FlightTravels.ToList()
>>>>>>> 6fa131fbf2c176685444fdff46873adfa3ea511a
                              join fromLocation in location on c.FromLocation equals fromLocation.LocationID
                              join toLocation in location on c.ToLocation equals toLocation.LocationID
                              select new FlightTravelGridViewModel()
                              {
                                  Id = c.ID,
                                  FromLocation = c.FromLocation,
                                  ToLocation = c.ToLocation,
                                  FromLocationName = fromLocation.PlaceName,
                                  ToLocationName = toLocation.PlaceName
                              }).ToList();
<<<<<<< HEAD
                return result;

            }

        }
    }
    }
=======
            }
        }
    }
}
>>>>>>> 6fa131fbf2c176685444fdff46873adfa3ea511a

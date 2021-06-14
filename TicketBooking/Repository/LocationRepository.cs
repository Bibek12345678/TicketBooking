using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private BookingContext _context;
        public LocationRepository(BookingContext context)
        {
            _context = context;
        }

        public int AddLocation(Location locationEntity)
        {
            int result = -1;
            if(locationEntity != null)
            {
                _context.Locations.Add(locationEntity);
                _context.SaveChanges();
                result = locationEntity.LocationID;
            }
            return result;
        }

        public void DeleteLocation(int? LocationID)
        {
            Location locationEntity = _context.Locations.Find(LocationID);
            _context.Locations.Remove(locationEntity);
            _context.SaveChanges();
        }

        public IEnumerable<Location> GetAllLocation()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int? LocationID)
        {
            return _context.Locations.Find(LocationID);
        }

        public int UpdateLocation(Location locationEntity)
        {
            int result = -1;
            if(locationEntity != null)
            {
                _context.Entry(locationEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = locationEntity.LocationID;
            }
            return result;
=======
using System.Linq;
using System.Web;
using TicketBooking.Models;
using System.Data.Entity.ModelConfiguration;
using TicketBooking.DAL;

namespace TicketBooking.Repository
{
    public class LocationRepository
    {
        public int AddLocation(Location model)
        {
            using(var context=new BookingContext())
            {
                Location loc = new Location()
                {
                    PlaceName = model.PlaceName
                };
                context.Locations.Add(loc);
                context.SaveChanges();
                return loc.LocationID;
            }
        }
        public List<Location> GetLocation()
        {
            using(var context=new BookingContext())
            {
                var result = context.Locations.ToList();
                return result;
            }
>>>>>>> 6fa131fbf2c176685444fdff46873adfa3ea511a
        }
    }
}
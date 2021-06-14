using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Models;

namespace TicketBooking.Repository
{
   public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocation();
        Location GetLocationById(int? LocationID);
        int AddLocation(Location locationEntity);
        int UpdateLocation(Location locationEntity);
        void DeleteLocation(int? LocationID);

    }
}

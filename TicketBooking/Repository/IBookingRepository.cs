using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Models;

namespace TicketBooking.Repository
{
   public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBooking();
        Booking GetAllBookingById(int BookingID);
        int AddBooking(Booking bookingEntity);
        int UpdateBooking(Booking bookingEntity);
        void DeleteBooking(int BookingID);

    }
}

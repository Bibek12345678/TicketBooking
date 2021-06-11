
using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Models
{
    public class BookingRate
    {
        [Key]
        public int BookingRateID { get; set; }

        public decimal Rate { get; set; }

        public int FlightTravelID { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Gmail { get; set; }
       // public int BookingRateID { get; set; }
        public decimal Rate { get; set; }
        public int NoOfPerson { get; set; }
        public int FlightTravelID { get; set; }         
       // public int LocationID { get; set; }

        public int Total { get; set; }
       
  

    }
}
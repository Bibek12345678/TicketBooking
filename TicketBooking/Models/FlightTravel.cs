using System.ComponentModel.DataAnnotations;
namespace TicketBooking.Models
{
    public class FlightTravel
    {
        [Key]
        public int ID { get; set; }
        public int FromLocation { get; set; }
        public int ToLocation { get; set; }
        public int LocationID { get; set; }
       // public Location Location { get; set; }

    }
}
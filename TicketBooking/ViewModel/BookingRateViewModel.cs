
namespace TicketBooking.ViewModel
{
    public class BookingRateViewModel
    {
        public int Id { get; set; }

        public decimal Rate { get; set; }     
        
        public int FromLocation { get; set; }
        public int ToLocation { get; set; }
        public string FromLocationName { get; set; }
        public string ToLocationName { get; set; }
       // public string DestinationName { get; set; }

    }
}
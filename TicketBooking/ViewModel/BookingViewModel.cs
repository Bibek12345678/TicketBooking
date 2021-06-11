using System.ComponentModel.DataAnnotations;

namespace TicketBooking.ViewModel
{
    public class BookingViewModel
    {
        public const string BindProperty = "Id , Name , PhoneNo, Gmail, Rate , FlightTravelID";
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your Full name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Enter Phone No ")]        
        public string PhoneNo { get; set; }

        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string Gmail { get; set; }
        public int BookingRateID { get; set; }
        public decimal Rate { get; set; }             
        public int FlightTravelID { get; set; }
        public string DestinationName{ get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int NoOfPeople { get; set; }
        public decimal Total { get; set; }
    }
}